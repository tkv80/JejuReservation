using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using JejuReservation.Entity;
using JejuReservation.Manager;
using JejuReservation.Worker;

namespace JejuReservation.Frm
{
    public partial class JeolmulForm : Form
    {
        private readonly string _cookie;
        private readonly JeolmulWorker _worker = new JeolmulWorker();
        private bool _isRunReservation;
        private IList<Site> _sites;

        public JeolmulForm()
        {
            InitializeComponent();
            cbStay.Items.Add("1박2일");
            cbStay.Items.Add("2박3일");
            cbStay.Items.Add("3박4일");
            cbStay.SelectedIndex = 0;
            cbStay.SelectedIndexChanged += cbStay_SelectedIndexChanged;

            _cookie = JeolmulHttpClientManager.GetCoockie();
            _worker.ProgressChanged += worker_ProgressChanged;
            _worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        private void cbStay_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(cbStay.SelectedIndex + 1);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                _isRunReservation = !_isRunReservation;
                btnReservation.Text = @"예약걸기";
                gbSetting.Enabled = true;
            }
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (_worker.IsSuccess)
            {
                lbSuccessMessage.Text = e.UserState.ToString();
                _worker.IsSuccess = false;
            }

            if (txtLog.Lines.Count() <= 150)
            {
                txtLog.AppendText(e.UserState.ToString());
            }
            else
            {
                txtLog.Clear();
                txtLog.AppendText(e.UserState.ToString());
            }
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            if (!_isRunReservation)
            {
                if (chbAll.Checked)
                {
                    _worker.Sites = string.IsNullOrWhiteSpace(txtFilter.Text)
                        ? _sites
                        : _sites.Where(x => x.SiteName.Contains(txtFilter.Text)).ToList();
                }
                else
                {
                    _worker.Sites = new List<Site> {(Site) cbSite.SelectedItem};
                }

                _worker.Interval = Convert.ToInt16(udDelay.Value);
                _worker.Booking = new Booking
                {
                    Address = txtAddress.Text,
                    Name = txtName.Text,
                    People = (int) numCount.Value,
                    StartDate = dateTimePicker1.Value,
                    EndDate = dateTimePicker2.Value,
                    Email = txtEmail.Text,
                    Tel = txtTel.Text
                };

                _worker.RunWorkerAsync();

                _isRunReservation = !_isRunReservation;
                btnReservation.Text = @"예약취소";
                gbSetting.Enabled = false;
            }
            else
            {
                _worker.CancelAsync();
                _worker.IsSuccess = true;

                _isRunReservation = !_isRunReservation;
                btnReservation.Text = @"예약걸기";
                gbSetting.Enabled = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(cbStay.SelectedIndex + 1);

            string parameter = string.Format("wh_year={0}&wh_month={1}&x=34&y=11", dateTimePicker1.Value.Year,
                dateTimePicker1.Value.Month);
            IList<Site> result = JeolmulHttpClientManager.GetSites(parameter, _cookie);

            _sites = result;
            cbSite.DataSource = result;
            cbSite.ValueMember = "SiteNumber";
            cbSite.DisplayMember = "SiteName";
        }
    }
}