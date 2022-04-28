using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiamSatHeThongThuyTinh
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            txtPLCType.Enabled = false;
            txtPLCIP.Enabled = false;
            txtRack.Enabled = false;
            txtSlot.Enabled = false;
            txtTimePLC.Enabled = false;
            txtConStr.Enabled = false;
            txtTimeSQL.Enabled = false;
            txtNewPass.Enabled = false;
            txtConfirm.Enabled = false;
            btnSavePass.Enabled = false;
            btnSavePLC.Enabled = false;
            btnSaveSQL.Enabled = false;
            //
            txtConStr.Text = "server=DESKTOP-1GG0LVP\\SQLEXPRESS;database=DATN;user id=sa;pwd=123456";
            txtTimeSQL.Text = "1000";
            txtRack.Text = "0";
            txtSlot.Text = "1";
            txtTimeSQL.Text = "100";
            txtPLCIP.Text = "192.168.0.101";
            txtPLCType.Text = "CPUType.S7-1200";
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if(txtCheckPass.Text == Properties.Settings.Default.Pwd)
            {
                txtPLCType.Enabled = true;
                txtPLCIP.Enabled = true;
                txtRack.Enabled = true;
                txtSlot.Enabled = true;
                txtTimePLC.Enabled = true;
                txtConStr.Enabled = true;
                txtTimeSQL.Enabled = true;
                txtNewPass.Enabled = true;
                txtConfirm.Enabled = true;
                btnSavePLC.Enabled = true;
                btnSaveSQL.Enabled = true;
                btnSavePass.Enabled = true;
            }
        }

        private void btnSavePass_Click(object sender, EventArgs e)
        {
            if(txtNewPass.Text == txtConfirm.Text)
            {
                Properties.Settings.Default.Pwd = txtConfirm.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("Change Password successfully",
                                "Notify",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }
    }
}
