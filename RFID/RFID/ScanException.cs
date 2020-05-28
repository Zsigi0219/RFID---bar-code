using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID
{
    class ScanException: Exception
    {
        private ulong id;
        public ulong Id
        {
            get
            {
                return id;
            }
        }

        private DateTime time;
        public DateTime Time
        {
            get
            {
                return time;
            }
        }

        public ScanException(ulong id)
        {
            this.id = id;
            this.time = DateTime.Now;
        }
    }
}
