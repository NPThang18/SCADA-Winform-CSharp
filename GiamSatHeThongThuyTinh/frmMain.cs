using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GiamSatHeThongThuyTinh.Model;
using SymbolFactoryDotNet;


namespace GiamSatHeThongThuyTinh
{
    public partial class frmMain : Form
    {
        SQLAccess SQL = new SQLAccess();
        PLCAccess PLC = new PLCAccess();
        DB_Read DB_Read = new DB_Read();
        DB_Write DB_Write = new DB_Write();
        DB_Retain DB_Retain = new DB_Retain();
        DB_Efficiency DB_Efficiency = new DB_Efficiency();
        Form activeForm;
        int count_1h = 0;
        int count_8h = 0;
        int count_1h_ = 0;
        public frmMain()
        {
            InitializeComponent();
        }

        // Form Load Event
        private void frmMain_Load(object sender, EventArgs e)
        {
            btnVisual1.Visible = false;
            btnMcal3.Visible = false;
            btnMulti3.Visible = false;
            btnOLTS.Visible = false;
            btnM1.Visible = false;
            btnVisual2.Visible = false;
            ///
            ckConnect.Checked = false;
            picDashboard.Visible = true;
            picHistory.Visible = false;
            picSetting.Visible = false;
            picChart.Visible = false;
            lbMain.Text = "DashBoard";
            timer2.Enabled = true;
            timer2.Interval = 100;
            // Initial Value of progress
            ccPOLT.Minimum = 0;
            ccPOLT.Maximum = 100;
            ccPVisual1.Minimum = 0;
            ccPVisual1.Maximum = 100;
            ccPMcal3.Minimum = 0;
            ccPMcal3.Maximum = 100;
            ccPOLT.Minimum = 0;
            ccPOLT.Maximum = 100;
        }

        // Function to Open ChidlForm
        void openChidlForm(Form form)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            pnMain.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        // Chart Button
        private void button2_Click(object sender, EventArgs e)
        {
            openChidlForm(new frmChart());
            pnSide.Top = btnChart.Top;
            lbMain.Text = "Chart";
            picDashboard.Visible = false;
            picHistory.Visible = false;
            picSetting.Visible = false;
            picChart.Visible = true;
        }

        // Data Button
        private void btnData_Click(object sender, EventArgs e)
        {
            openChidlForm(new frmData());
            pnSide.Top = btnData.Top;
            lbMain.Text = "History";
            picDashboard.Visible = false;
            picHistory.Visible = true;
            picSetting.Visible = false;
            picChart.Visible = false;
        }

        // DashBoard Button
        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            pnSide.Top = btnDashBoard.Top;
            lbMain.Text = "DashBoard";
            picDashboard.Visible = true;
            picHistory.Visible = false;
            picSetting.Visible = false;
            picChart.Visible = false;
        }

        // Setting Button
        private void btnSetting_Click(object sender, EventArgs e)
        {
            openChidlForm(new frmSetting());
            pnSide.Top = btnSetting.Top;
            lbMain.Text = "Setting";
            picDashboard.Visible = false;
            picHistory.Visible = false;
            picSetting.Visible = true;
            picChart.Visible = false;
        }

        // Exit Button
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Timer to Read Data from PLC
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Đọc khối DB_Retain
            PLC.ReadClass(DB_Retain, 3);
            // Đọc khối DB_Read
            PLC.ReadClass(DB_Read, 1);
            // Read DB_Efficiency
            PLC.ReadClass(DB_Efficiency, 4);

            // Trạng thái của các đèn led

            Led_Status(stdRun, DB_Read.Led_Start);
            Led_Status(stdStop, DB_Read.Led_Stop);
            Led_Status(stdMcal3, DB_Read.Led_Start);
            Led_Status(stdMulti3, DB_Read.Led_Start);
            Led_Status(stdOLT, DB_Read.Led_Start);
            Led_Status(stdM1, DB_Read.Led_Start);
            // Đọc dữ liệu của khối Retain
            lbInput_Visual1.Text = DB_Retain.C_in_Visual1.ToString();
            lbError_Visual1.Text = DB_Retain.C_Error_Visual1.ToString();
            lbOutput_Visual1.Text = DB_Retain.C_out_Visual1.ToString();

            lbInput_Mcal3.Text = DB_Retain.C_in_Mcal3.ToString();
            lbError_Mcal3.Text = DB_Retain.C_Error_Mcal3.ToString();
            lbOutput_Mcal3.Text = DB_Retain.C_out_Mcal3.ToString();

            lbInput_Multi3.Text = DB_Retain.C_in_Multi3.ToString();
            lbError_Multi3.Text = DB_Retain.C_Error_Multi3.ToString();
            lbOutput_Multi3.Text = DB_Retain.C_out_Multi3.ToString();

            lbInput_OLT.Text = DB_Retain.C_in_OLTS.ToString();
            lbError_OLT.Text = DB_Retain.C_Error_OLTS.ToString();
            lbOutput_OLT.Text = DB_Retain.C_out_OLTS.ToString();

            lbInput_M1.Text = DB_Retain.C_in_M1.ToString();
            lbError_M1.Text = DB_Retain.C_Error_M1.ToString();
            lbOutput_M1.Text = DB_Retain.C_out_M1.ToString();

            lbInput_Visual2.Text = DB_Retain.C_in_Visual2.ToString();
            lbError_Visual2.Text = DB_Retain.C_Error_Visual2.ToString();
            lbOutput_Visual2.Text = DB_Retain.C_out_Visual2.ToString();

            lbTotal_Input.Text = DB_Retain.C_in_Total.ToString();
            lbTotal_Output.Text = DB_Retain.C_out_Total.ToString();
            lbTotal_Error.Text = DB_Retain.C_Error_Total.ToString();

            //Hiển thị dữ liệu lên circular Progress
            lbProgressVisual1.Text = DB_Efficiency.Visual1.ToString("0.0");
            lbProgressMcal3.Text = DB_Efficiency.Mcal3.ToString("0.0");
            lbProgressMulti3.Text = DB_Efficiency.Multi3.ToString("0.0");
            lbProgressOLT.Text = DB_Efficiency.OLTS.ToString("0.0");
            lbProgress_M1.Text = DB_Efficiency.M1.ToString("0.0");
            lbProgress_Visual2.Text = DB_Efficiency.Visual2.ToString("0.0");

            if (DB_Retain.C_in_Visual1 > 0)
                ccPVisual1.Value = (int)DB_Efficiency.Visual1;
            else
                lbProgressVisual1.Text = "0";
            if (DB_Retain.C_in_Mcal3 > 0)
                ccPMcal3.Value = (int)DB_Efficiency.Mcal3;
            else
                lbProgressMcal3.Text = "0";
            if (DB_Retain.C_in_Multi3 > 0)
                ccPMulti3.Value = (int)DB_Efficiency.Multi3;
            else
                lbProgressMulti3.Text = "0";
            if (DB_Retain.C_in_OLTS > 0)
                ccPOLT.Value = (int)DB_Efficiency.OLTS;
            else
                lbProgressOLT.Text = "0";
            if (DB_Retain.C_in_M1 > 0)
                ccPM1.Value = (int)DB_Efficiency.M1;
            else
                lbProgress_M1.Text = "0";
            if (DB_Retain.C_in_Visual2 > 0)
                ccPVisual2.Value = (int)DB_Efficiency.Visual2;
            else
                lbProgress_Visual2.Text = "0";
            if (DB_Retain.C_in_Total > 0)
            {
                ccPTotal.Value = (int)DB_Efficiency.Total;
                lbProgressTotal.Text = DB_Efficiency.Total.ToString("0.0");
            }
            else
            {
                ccPVisual1.Value = 0;
                ccPMcal3.Value = 0;
                ccPMulti3.Value = 0;
                ccPOLT.Value = 0;
                ccPM1.Value = 0;
                ccPVisual2.Value = 0;
                ccPTotal.Value = 0;
                lbProgressTotal.Text = "0";
            }
            // Alarm when efficiency less than standar
            if( DB_Efficiency.Visual1 > 80 && DB_Efficiency.Visual1 <90)
            {
                ccPVisual1.ProgressColor = Color.Yellow;
            } else if(DB_Efficiency.Visual1 <80)
            {
                ccPVisual1.ProgressColor = Color.Red;
            } else
            {
                ccPVisual1.ProgressColor = Color.FromArgb(50, 219, 95);
            }
            //
            if (DB_Efficiency.Mcal3 > 80 && DB_Efficiency.Mcal3 < 90)
            {
                ccPMcal3.ProgressColor = Color.Yellow;
            }
            else if (DB_Efficiency.Mcal3 < 80)
            {
                ccPMcal3.ProgressColor = Color.Red;
            }
            else
            {
                ccPMcal3.ProgressColor = Color.FromArgb(50, 219, 95);
            }
            //
            if (DB_Efficiency.Multi3 > 80 && DB_Efficiency.Multi3 < 90)
            {
                ccPMulti3.ProgressColor = Color.Yellow;
            }
            else if (DB_Efficiency.Multi3 < 80)
            {
                ccPMulti3.ProgressColor = Color.Red;
            }
            else
            {
                ccPMulti3.ProgressColor = Color.FromArgb(50, 219, 95);
            }
            //
            if (DB_Efficiency.OLTS > 80 && DB_Efficiency.OLTS < 90)
            {
                ccPOLT.ProgressColor = Color.Yellow;
            }
            else if (DB_Efficiency.OLTS < 80)
            {
                ccPOLT.ProgressColor = Color.Red;
            }
            else
            {
                ccPOLT.ProgressColor = Color.FromArgb(50, 219, 95);
            }
            //
            if (DB_Efficiency.M1 > 80 && DB_Efficiency.M1 < 90)
            {
                ccPM1.ProgressColor = Color.Yellow;
            }
            else if (DB_Efficiency.M1 < 80)
            {
                ccPM1.ProgressColor = Color.Red;
            }
            else
            {
                ccPM1.ProgressColor = Color.FromArgb(50, 219, 95);
            }
            //
            if (DB_Efficiency.Visual2 > 80 && DB_Efficiency.Visual2< 90)
            {
                ccPVisual2.ProgressColor = Color.Yellow;
            }
            else if (DB_Efficiency.Visual2 < 80)
            {
                ccPVisual2.ProgressColor = Color.Red;
            }
            else
            {
                ccPVisual2.ProgressColor = Color.FromArgb(50, 219, 95);
            }
            //
            if (DB_Efficiency.Total > 70 && DB_Efficiency.Total < 80)
            {
                ccPTotal.ProgressColor = Color.Yellow;
            }
            else if (DB_Efficiency.Total < 70)
            {
                ccPTotal.ProgressColor = Color.Red;
            }
            else
            {
                ccPTotal.ProgressColor = Color.FromArgb(50, 219, 95);
            }
            // Read Led Pittong and Led Qualify

            Led_Status(stdQualify_Visual1, DB_Read.Led_Visual1);
            Led_Status(stdQualify_Visual2, DB_Read.Led_Visual2);

            Led_Status(stdPittong_Mcal3, DB_Read.Pittong_MCal3);
            Led_Status(stdQualify_Mcal3, DB_Read.Led_Mcal3);

            Led_Status(stdPittong_Multi3, DB_Read.Pittong_Multi3);
            Led_Status(stdQualify_Multi3, DB_Read.Led_Multi3);

            Led_Status(stdPittong_OLT, DB_Read.Pittong_OLTS);
            Led_Status(stdQualify_OLT, DB_Read.Led_OLTS);

            Led_Status(stdPittong_M1, DB_Read.Pittong_M1);
            Led_Status(stdQualify_M1, DB_Read.Led_M1);



        }

        // Led Stauts
        void Led_Status(StandardControl std, bool value)
        {
            if (value)
                std.DiscreteValue1 = true;
            else
                std.DiscreteValue1 = false;
        }

        // Timer to check connection status with PLC
        private void timer2_Tick(object sender, EventArgs e)
        {
            lbDataTime1.Text = DateTime.Now.ToString("hh:mm:ss");
            lbDateTime2.Text = DateTime.Now.ToString("dd/MM/yyyy");
            if (PLC.CheckPLC())
            {
                stdStatus3.DiscreteValue1 = true;
                timer1.Enabled = true;
                timer1.Interval = 100;
                if (DB_Read.Led_Start)
                {
                    timer3.Enabled = true;
                    timer3.Interval = 1000;
                }
                else
                    timer3.Enabled = false;
            }
            else
            {
                stdStatus3.DiscreteValue1 = false;
                timer1.Enabled = false;
                timer3.Enabled = false;
                ResetValue(lbInput_Visual1);
                ResetValue(lbOutput_Visual1);
                ResetValue(lbInput_Mcal3);
                ResetValue(lbError_Mcal3);
                ResetValue(lbInput_Multi3);
                ResetValue(lbError_Multi3);
                ResetValue(lbInput_OLT);
                ResetValue(lbError_OLT);
                ResetValue(lbProgressOLT);
                ResetValue(lbProgressVisual1);
                ResetValue(lbProgressMulti3);
                ResetValue(lbTotal_Output);
                ResetValue(lbTotal_Error);
                ResetStandardControl(stdRun);
                ResetStandardControl(stdStop);
                ResetStandardControl(stdMcal3);
                ResetStandardControl(stdMulti3);
                ResetStandardControl(stdOLT);
                ResetStandardControl(stdM1);
                ccPVisual1.Value = 0;
                ccPMcal3.Value = 0;
                ccPOLT.Value = 0;
                ccPMulti3.Value = 0;
                ccPM1.Value = 0;
                ccPVisual2.Value = 0;
                ccPTotal.Value = 0;
            }
            if (PLC.CheckPLC() == false)
            {
                ckConnect.Checked = false;
            }
        }

        // Function resetValue
        void ResetValue(Label lb)
        {
            lb.Text = "0";
        }

        // Function resetStandardControl
        void ResetStandardControl(StandardControl std)
        {
            std.DiscreteValue1 = false;
        }

        // Start Button
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (PLC.CheckPLC())
            {
                PLC.Setbit("DB2.DBX0.0");
                PLC.Resetbit("DB2.DBX0.0");
            }
            else
                MessageBox.Show("PLC is not connected",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
        }

        // Stop Button
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (PLC.CheckPLC())
            {
                PLC.Setbit("DB2.DBX0.1");
                PLC.Resetbit("DB2.DBX0.1");
            }
            else
                MessageBox.Show("PLC is not connected",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
        }
        #region Error Simulation Button
        private void button2_Click_1(object sender, EventArgs e)
        {
            PLC.Setbit("DB2.DBX1.0");
            PLC.Resetbit("DB2.DBX1.0");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PLC.Setbit("DB2.DBX1.1");
            PLC.Resetbit("DB2.DBX1.1");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PLC.Setbit("DB2.DBX1.2");
            PLC.Resetbit("DB2.DBX1.2");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PLC.Setbit("DB2.DBX1.3");
            PLC.Resetbit("DB2.DBX1.3");
        }
        #endregion

        // Timer update data into SQL Server
        private void timer3_Tick(object sender, EventArgs e)
        {
            count_1h++;
            count_1h_++;
            count_8h++;
            try
            {
                // Update efficiency into database
                if (count_1h_ == 30)
                {
                    SQL.OpenSQL();
                    if (SQL.CheckSQL())
                    {
                        SQL.InsertEfficiency(DateTime.Now.ToString("yyyy-MM-dd"),
                                         DateTime.Now.ToString("hh:mm:ss"),
                                         Math.Round(DB_Efficiency.Visual1, 1),
                                         Math.Round(DB_Efficiency.Mcal3, 1),
                                         Math.Round(DB_Efficiency.Multi3, 1),
                                         Math.Round(DB_Efficiency.OLTS, 1),
                                         Math.Round(DB_Efficiency.M1, 1),
                                         Math.Round(DB_Efficiency.Visual2, 1),
                                         Math.Round(DB_Efficiency.Total, 1));
                    }
                    
                    SQL.CloseSQL();
                    count_1h_ = 0;
                }
                // Update ProductOfDay into database
                if (count_1h == 30)
                {
                    SQL.OpenSQL();
                    if (SQL.CheckSQL())
                    {
                        SQL.InserProductOfDay(DateTime.Now.ToString("yyyy-MM-dd"),
                                          DateTime.Now.ToString("hh:mm:ss"),
                                          DB_Retain.C_in_Total,
                                          DB_Retain.C_out_Total,
                                          DB_Retain.C_Error_Total,
                                          Math.Round(DB_Efficiency.Total, 1));
                    }
                    SQL.CloseSQL();
                    count_1h = 0;
                }
                // Update Product into database
                if (count_8h == 239)
                {
                    SQL.OpenSQL();
                    if (SQL.CheckSQL())
                    {
                        SQL.InsertProduct(DateTime.Now.ToString("yyyy-MM-dd"),
                                      DateTime.Now.ToString("hh:mm:ss"),
                                      DB_Retain.C_in_Total,
                                      DB_Retain.C_out_Total,
                                      DB_Retain.C_Error_Total,
                                      Math.Round(DB_Efficiency.Total, 1));
                    }
                    
                    SQL.CloseSQL();
                    count_8h = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Simulation
        private void ckSimulate_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSimulate.Checked)
            {
                PLC.Setbit("DB2.DBX2.5");
                ckSimulate.BackColor = Color.Green;
                btnVisual1.Visible = true;
                btnMcal3.Visible = true;
                btnMulti3.Visible = true;
                btnOLTS.Visible = true;
                btnM1.Visible = true;
                btnVisual2.Visible = true;
            }
            else
            {
                PLC.Resetbit("DB2.DBX2.5");
                ckSimulate.BackColor = Color.Gray;
                btnVisual1.Visible = false;
                btnMcal3.Visible = false;
                btnMulti3.Visible = false;
                btnOLTS.Visible = false;
                btnM1.Visible = false;
                btnVisual2.Visible = false;
            }
        }

        // Connection Button
        private void ckConnect_CheckedChanged(object sender, EventArgs e)
        {
            if (ckConnect.Checked)
            {
                PLC.OpenPLC();
                if (PLC.CheckPLC())
                {
                    MessageBox.Show("Connect Successfully",
                                    "Notify",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    ckConnect.Text = "DisConnect";
                    ckConnect.BackColor = Color.Green;
                }

                else
                    MessageBox.Show("Connect Failly",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

            }
            else
            {
                PLC.ClosePLC();
                MessageBox.Show("PLC is Disconnected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ckConnect.Text = "Connect";
                ckConnect.BackColor = Color.Gray;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (PLC.CheckPLC())
            {
                PLC.Setbit("DB2.DBX0.2");
                PLC.Resetbit("DB2.DBX0.2");
            }
        }
        void PressBtn(string address)
        {
            if (PLC.CheckPLC())
            {
                PLC.Setbit(address);
                PLC.Resetbit(address);
            } else
            {
                MessageBox.Show("PLC is disconnected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVisual1_Click(object sender, EventArgs e)
        {
            PressBtn("DB2.DBX1.1");
        }

        private void btnMcal3_Click(object sender, EventArgs e)
        {
            PressBtn("DB2.DBX1.2");
        }

        private void btnMulti3_Click(object sender, EventArgs e)
        {
            PressBtn("DB2.DBX1.3");
        }

        private void btnOLTS_Click(object sender, EventArgs e)
        {
            PressBtn("DB2.DBX1.4");
        }

        private void btnM1_Click(object sender, EventArgs e)
        {
            PressBtn("DB2.DBX1.5");
        }

        private void btnVisual2_Click(object sender, EventArgs e)
        {
            PressBtn("DB2.DBX1.6");
        }
    }
}
