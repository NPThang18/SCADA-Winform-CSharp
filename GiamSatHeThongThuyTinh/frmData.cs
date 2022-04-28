using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GiamSatHeThongThuyTinh.Model;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace GiamSatHeThongThuyTinh
{
    public partial class frmData : Form
    {
        SQLAccess SQL = new SQLAccess();
        public frmData()
        {
            InitializeComponent();
        }

        private void frmData_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            try
            {
                SQL.OpenSQL();
                SQL.QueryEfficiency(monthCalendar1.SelectionStart.ToString("yyyy-MM-dd"));
                SQL.CloseSQL();
                dgvData.DataSource = SQL.dt_percent;
                dgvData.Columns[0].Visible = false;
                dgvData.Columns[1].Width = 110;
                dgvData.Columns[2].Width = 110;
                dgvData.Columns[3].Width = 82;
                dgvData.Columns[4].Width = 82;
                dgvData.Columns[5].Width = 82;
                dgvData.Columns[6].Width = 82;
                dgvData.Columns[7].Width = 82;
                dgvData.Columns[8].Width = 82;
                dgvData.Columns[9].Width = 82;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Function export data to excel
        private void ExportToExcel(DataGridView dgv, string path, string fileName)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 15;
            for(int i = 1; i< dgv.Columns.Count; i++)
            {
                obj.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
            }
            for(int i = 0; i< dgv.Rows.Count; i++)
            {
                for(int j = 0; j<dgv.Columns.Count; j++)
                {
                    if(dgv.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(path + fileName + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case -1:
                    MessageBox.Show("Please Select table",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                    break;
                case 0:
                    try
                    {
                        SQL.OpenSQL();
                        SQL.QueryEfficiency(monthCalendar1.SelectionStart.ToString("yyyy-MM-dd"));
                        SQL.CloseSQL();
                        dgvData.DataSource = SQL.dt_percent;
                        dgvData.Columns[0].Visible = false;
                        dgvData.Columns[1].Width = 110;
                        dgvData.Columns[2].Width = 110;
                        dgvData.Columns[3].Width = 82;
                        dgvData.Columns[4].Width = 82;
                        dgvData.Columns[5].Width = 82;
                        dgvData.Columns[6].Width = 82;
                        dgvData.Columns[7].Width = 82;
                        dgvData.Columns[8].Width = 82;
                        dgvData.Columns[9].Width = 82;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 1:
                    try
                    {
                        SQL.OpenSQL();
                        SQL.QueryProductOfDay(monthCalendar1.SelectionStart.ToString("yyyy-MM-dd"));
                        SQL.CloseSQL();
                        dgvData.DataSource = SQL.dt_hour;
                        dgvData.Columns[0].Visible = false;
                        dgvData.Columns[1].Width = 120;
                        dgvData.Columns[2].Width = 120;
                        dgvData.Columns[3].Width = 138;
                        dgvData.Columns[4].Width = 138;
                        dgvData.Columns[5].Width = 138;
                        dgvData.Columns[6].Width = 138;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 2:
                    try
                    {
                        SQL.OpenSQL();
                        SQL.QueryProduct();
                        SQL.CloseSQL();
                        dgvData.DataSource = SQL.dt_day;
                        dgvData.Columns[0].Visible = false;
                        dgvData.Columns[1].Width = 120;
                        dgvData.Columns[2].Width = 120;
                        dgvData.Columns[3].Width = 138;
                        dgvData.Columns[4].Width = 138;
                        dgvData.Columns[5].Width = 138;
                        dgvData.Columns[6].Width = 138;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(txtPath.Text != "" && txtFileName.Text != "")
            {
                try
                {
                    ExportToExcel(dgvData, txtPath.Text, txtFileName.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else
            {
                MessageBox.Show("Bạn Chưa chọn nơi lưu", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case -1:
                    MessageBox.Show("Please Select table",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                    break;
                case 0:
                    try
                    {
                        SQL.OpenSQL();
                        SQL.QueryEfficiency(DateTime.Now.ToString("yyyy-MM-dd"));
                        SQL.CloseSQL();
                        dgvData.DataSource = SQL.dt_percent;
                        dgvData.Columns[0].Visible = false;
                        dgvData.Columns[1].Width = 110;
                        dgvData.Columns[2].Width = 110;
                        dgvData.Columns[3].Width = 82;
                        dgvData.Columns[4].Width = 82;
                        dgvData.Columns[5].Width = 82;
                        dgvData.Columns[6].Width = 82;
                        dgvData.Columns[7].Width = 82;
                        dgvData.Columns[8].Width = 82;
                        dgvData.Columns[9].Width = 82;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 1:
                    try
                    {
                        SQL.OpenSQL();
                        SQL.QueryProductOfDay(DateTime.Now.ToString("yyyy-MM-dd"));
                        SQL.CloseSQL();
                        dgvData.DataSource = SQL.dt_hour;
                        dgvData.Columns[0].Visible = false;
                        dgvData.Columns[1].Width = 120;
                        dgvData.Columns[2].Width = 120;
                        dgvData.Columns[3].Width = 138;
                        dgvData.Columns[4].Width = 138;
                        dgvData.Columns[5].Width = 138;
                        dgvData.Columns[6].Width = 138;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 2:
                    try
                    {
                        SQL.OpenSQL();
                        SQL.QueryProduct();
                        SQL.CloseSQL();
                        dgvData.DataSource = SQL.dt_day;
                        dgvData.Columns[0].Visible = false;
                        dgvData.Columns[1].Width = 120;
                        dgvData.Columns[2].Width = 120;
                        dgvData.Columns[3].Width = 138;
                        dgvData.Columns[4].Width = 138;
                        dgvData.Columns[5].Width = 138;
                        dgvData.Columns[6].Width = 138;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }
        }
    }
}
