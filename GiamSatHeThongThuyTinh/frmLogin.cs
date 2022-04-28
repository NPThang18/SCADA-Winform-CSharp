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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == Properties.Settings.Default.User && txtKey.Text == Properties.Settings.Default.Pwd)
                DialogResult = DialogResult.OK;
            else
                MessageBox.Show("User or Password is incorrect",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            
        }

        private void picVisibility_Click(object sender, EventArgs e)
        {
            txtKey.PasswordChar = default;
            picVisibility.Visible = false;
            picUnVisible.Visible = true;
        }

        private void picUnVisible_Click(object sender, EventArgs e)
        {
            txtKey.PasswordChar = '*';
            picVisibility.Visible = true;
            picUnVisible.Visible = false;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            picVisibility.Visible = true;
            picUnVisible.Visible = false;
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.PerformClick();
        }
    }
}
