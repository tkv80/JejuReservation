using System;
using System.Windows.Forms;

namespace JejuReservation.Frm
{
    public partial class StartFrm : Form
    {
        public StartFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new SeoqwipoForm().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new JeolmulForm().Show();
        }
    }
}