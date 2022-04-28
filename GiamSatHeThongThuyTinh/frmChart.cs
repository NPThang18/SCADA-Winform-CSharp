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


namespace GiamSatHeThongThuyTinh
{
    public partial class frmChart : Form
    {
        SQLAccess SQL = new SQLAccess();
        frmMain frmMain = new frmMain();
        public frmChart()
        {
            InitializeComponent();
        }
        private void frmChart_Load(object sender, EventArgs e)
        {
            ChartPercent.Series["ChartPercent"].Points.Clear();
            ChartPercent.Series["ChartPercent"].Points.AddXY("Mcal3", 1);
            ChartPercent.Series["ChartPercent"].Points.AddXY("Multi3", 1);
            ChartPercent.Series["ChartPercent"].Points.AddXY("OLT-S", 1);
            ChartPercent.Series["ChartPercent"].Points.AddXY("M1", 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductChart.Series["ProductChart"].Points.Clear();
            EfficiencyChart.Series["EfficiencyChart"].Points.Clear();
            SQL.OpenSQL();
            SQL.QueryProductOfDay(monthCalendar1.SelectionStart.ToString("yyyy-MM-dd"));
            SQL.CloseSQL();
            ProductChart.ChartAreas["ProductChart"].AxisX.Title = "TimeDate";
            ProductChart.ChartAreas["ProductChart"].AxisX.TitleForeColor = Color.FromArgb(165, 119, 11);
            ProductChart.ChartAreas["ProductChart"].AxisY.Title = "Product";
            ProductChart.ChartAreas["ProductChart"].AxisY.TitleForeColor = Color.FromArgb(165, 119, 11);

            EfficiencyChart.ChartAreas["EfficiencyChart"].AxisX.Title = "TimeDate";
            EfficiencyChart.ChartAreas["EfficiencyChart"].AxisY.Title = "Efficiency";
            EfficiencyChart.ChartAreas["EfficiencyChart"].AxisX.TitleForeColor = Color.FromArgb(165, 119, 11);
            EfficiencyChart.ChartAreas["EfficiencyChart"].AxisY.TitleForeColor = Color.FromArgb(165, 119, 11);
            try
            {
                for (int i = 0; i < SQL.dt_hour.Rows.Count; i++)
                {
                    ProductChart.Series["ProductChart"].Points.AddXY(i, SQL.dt_hour.Rows[i]["Total Output Product"]);
                }
                for (int i = 0; i < SQL.dt_hour.Rows.Count; i++)
                {
                    EfficiencyChart.Series["EfficiencyChart"].Points.AddXY(i, SQL.dt_hour.Rows[i]["Efficiency"]);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            lbDefectiveProduct.Text = "35";
            lbQulifiedProducts.Text = "204";
            lbTotalProducts.Text = "239";
        }
    }
}
