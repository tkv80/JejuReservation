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
    public partial class SeoqwipoForm : Form
    {
        private readonly SeoqwipoWorker _worker = new SeoqwipoWorker();
        private bool _isRunReservation;

        public SeoqwipoForm()
        {
            InitializeComponent();

            IList<Site> result = SeogwipoHttpClientManager.GetSites();

            cbSite.DataSource = result;
            cbSite.ValueMember = "SiteNumber";
            cbSite.DisplayMember = "SiteName";

            _worker.ProgressChanged += worker_ProgressChanged;
            _worker.RunWorkerCompleted += worker_RunWorkerCompleted;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!_isRunReservation)
            {
                var sites = SeogwipoHttpClientManager.GetSites();
                if (chbAll.Checked)
                {
                    _worker.Sites = string.IsNullOrWhiteSpace(txtFilter.Text)
                        ? sites
                        : sites.Where(x => x.SiteName.Contains(txtFilter.Text)).ToList();
                }
                else
                {
                    _worker.Sites = new List<Site> { (Site)cbSite.SelectedItem };
                }
                
                _worker.Interval = Convert.ToInt16(udDelay.Value);
                _worker.Booking = new Booking
                {
                    Address = txtAddress.Text,
                    Name = txtName.Text,
                    People = (int) numCount.Value,
                    StartDate = dateTimePicker1.Value,
                    EndDate = dateTimePicker2.Value,
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
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(1);
        }
    }
}