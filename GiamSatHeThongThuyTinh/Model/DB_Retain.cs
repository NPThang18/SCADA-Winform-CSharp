using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7.Net;

namespace GiamSatHeThongThuyTinh.Model
{
    public class DB_Retain
    {
        public int C_in_Visual1 { get; set; }
        public int C_in_Visual2 { get; set; }
        public int C_in_Mcal3 { get; set; }
        public int C_in_Multi3 { get; set; }
        public int C_in_OLTS { get; set; }
        public int C_in_M1 { get; set; }
        public int C_out_Visual1 { get; set; }
        public int C_out_Visual2 { get; set; }
        public int C_out_Mcal3 { get; set; }
        public int C_out_Multi3 { get; set; }
        public int C_out_OLTS { get; set; }
        public int C_out_M1 { get; set; }
        public int C_Error_Visual1 { get; set; }
        public int C_Error_Visual2 { get; set; }
        public int C_Error_Mcal3 { get; set; }
        public int C_Error_Multi3 { get; set; }
        public int C_Error_OLTS { get; set; }
        public int C_Error_M1 { get; set; }
        public int C_in_Total { get; set; }
        public int C_out_Total { get; set; }
        public int C_Error_Total { get; set; }
    }
}
