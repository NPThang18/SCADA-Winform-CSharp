using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GiamSatHeThongThuyTinh.Model
{
    public class SQLAccess
    {
        public DataTable dt_hour = new DataTable();
        public DataTable dt_day = new DataTable();
        public DataTable dt_percent = new DataTable();
        string Constr = "server=DESKTOP-1GG0LVP\\SQLEXPRESS;database=GiamSatHeThongThuyTinh;user id=sa;pwd=123456";
        SqlConnection sqlCon = null;
        public void OpenSQL()
        {
            if (sqlCon == null)
                sqlCon = new SqlConnection(Constr);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
        }
        public void CloseSQL()
        {
            if (sqlCon.State == ConnectionState.Open)
                sqlCon.Close();
        }
        public bool CheckSQL()
        {
            if (sqlCon.State == ConnectionState.Open)
                return true;
            else
                return false;
        }

        //ADO.NET
        public void InserProductOfDay(string day, string time, int input, int output, int Defects, double Efficiency)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into ProductOfDay values (@date, @time, @input, @output, @defects, @efficiency)";
            cmd.Parameters.Add("@date", SqlDbType.NVarChar).Value = day;
            cmd.Parameters.Add("@time", SqlDbType.NVarChar).Value = time;
            cmd.Parameters.Add("@input", SqlDbType.Int).Value = input;
            cmd.Parameters.Add("@output", SqlDbType.Int).Value = output;
            cmd.Parameters.Add("@defects", SqlDbType.Int).Value = Defects;
            cmd.Parameters.Add("@efficiency", SqlDbType.Real).Value = Efficiency;
            cmd.Connection = sqlCon;
            cmd.ExecuteNonQuery();
        }
        public void InsertProduct(string day, string time, int input, int output, int Defects, double Efficiency)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Product values (@date, @time, @input, @output, @defects, @efficiency)";
            cmd.Parameters.Add("@date", SqlDbType.NVarChar).Value = day;
            cmd.Parameters.Add("@time", SqlDbType.NVarChar).Value = time;
            cmd.Parameters.Add("@input", SqlDbType.Int).Value = input;
            cmd.Parameters.Add("@output", SqlDbType.Int).Value = output;
            cmd.Parameters.Add("@defects", SqlDbType.Int).Value = Defects;
            cmd.Parameters.Add("@efficiency", SqlDbType.Real).Value = Efficiency;
            cmd.Connection = sqlCon;
            cmd.ExecuteNonQuery();
        }
        public void InsertEfficiency(string day, string time, double visual1, double mcal3, double multi3, double olt ,double m1, double visual2, double total)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Efficiency values (@date,@time ,@visual1, @mcal3, @multi3, @olt, @m1, @visual2, @total)";
            cmd.Parameters.Add("@date", SqlDbType.NVarChar).Value = day;
            cmd.Parameters.Add("@time", SqlDbType.NVarChar).Value = time;
            cmd.Parameters.Add("@visual1", SqlDbType.Real).Value = visual1;
            cmd.Parameters.Add("@mcal3", SqlDbType.Real).Value = mcal3;
            cmd.Parameters.Add("@multi3", SqlDbType.Real).Value = multi3;
            cmd.Parameters.Add("@olt", SqlDbType.Real).Value = olt;
            cmd.Parameters.Add("@m1", SqlDbType.Real).Value = m1;
            cmd.Parameters.Add("@visual2", SqlDbType.Real).Value = visual2;
            cmd.Parameters.Add("@total", SqlDbType.Real).Value = total;
            cmd.Connection = sqlCon;
            cmd.ExecuteNonQuery();
        }
        public void QueryProductOfDay(string date)
        {
            using(SqlCommand cmd = new SqlCommand("select * from ProductOfDay where Date = @date", sqlCon))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@date", SqlDbType.NVarChar).Value = date; 
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt_hour.Clear();
                da.Fill(dt_hour);
            }
        }
        public void QueryProduct()
        {
            using (SqlCommand cmd = new SqlCommand("select * from Product", sqlCon))
            {
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt_day.Clear();
                da.Fill(dt_day);
            }
        }
        public void QueryEfficiency(string date)
        {
            using (SqlCommand cmd = new SqlCommand("select * from Efficiency where Date = @date", sqlCon))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@date", SqlDbType.NVarChar).Value = date;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt_percent.Clear();
                da.Fill(dt_percent);
            }
        }
        
    }
}
