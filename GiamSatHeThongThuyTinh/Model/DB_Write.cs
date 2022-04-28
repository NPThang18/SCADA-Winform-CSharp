using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7.Net;

namespace GiamSatHeThongThuyTinh.Model
{
    public class DB_Write
    {
        public bool Start_Button { get; set; }
        public bool Stop_Button { get; set; }
        public bool Reset_Button { get; set; }
        public bool Visual1_in_Sensor { get; set; }
        public bool Mcal3_in_Sensor { get; set; }
        public bool Multi3_in_Sensor { get; set; }
        public bool OLTS_in_Sensor { get; set; }
        public bool M1_in_Sensor { get; set; }
        public bool Visual2_in_Sensor { get; set; }
        public bool Visual1_error_Sensor { get; set; }
        public bool Mcal3_error_Sensor { get; set; }
        public bool Multi3_error_Sensor { get; set; }
        public bool OLTS_error_Sensor { get; set; }
        public bool M1_error_Sensor { get; set; }
        public bool Visual2_error_Sensor { get; set; }
        public bool Visual1_out_Sensor { get; set; }
        public bool Mcal3_out_Sensor { get; set; }
        public bool Multi3_out_Sensor { get; set; }
        public bool OLTS_out_Sensor { get; set; }
        public bool M1_out_Sensor { get; set; }
        public bool Visual2_out_Sensor { get; set; }
        public bool Simulate { get; set; }

    }
}
