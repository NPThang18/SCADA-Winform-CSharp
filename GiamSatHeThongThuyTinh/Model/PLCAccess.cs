using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7.Net;

namespace GiamSatHeThongThuyTinh.Model
{
    public class PLCAccess
    {
        Plc _plc = new Plc(CpuType.S71200, "192.168.0.101", 0, 1);
        public void OpenPLC()
        {
            if (_plc.IsConnected == false)
                _plc.Open();
        }
        public void ClosePLC()
        {
            if (_plc.IsConnected)
                _plc.Close();
        }
        public bool CheckPLC()
        {
            if (_plc.IsConnected)
                return true;
            else
                return false;
        }
        public void ReadClass(object dbSource, int db )
        {
            if (_plc.IsConnected)
                _plc.ReadClass(dbSource, db);
        }
        public void Setbit(string address)
        {
            _plc.Write(address, 1);
        }
        public void Resetbit(string address)
        {
            _plc.Write(address, 0);
        }
    }
}
