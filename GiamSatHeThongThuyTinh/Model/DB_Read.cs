using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7.Net;

namespace GiamSatHeThongThuyTinh.Model
{
    public class DB_Read
    {
        public bool Led_Start { get; set; }
        public bool Led_Stop { get; set; }
        public bool Pittong_MCal3 { get; set; }
        public bool Pittong_Multi3 { get; set; }
        public bool Pittong_M1 { get; set; }
        public bool Pittong_OLTS { get; set; }
        public bool Led_Visual1 { get; set; }
        public bool Led_Visual2 { get; set; }
        public bool Led_Mcal3 { get; set; }
        public bool Led_Multi3 { get; set; }
        public bool Led_OLTS { get; set; }
        public bool Led_M1 { get; set; }
        public byte Bit_end { get; set; }
    }
}
