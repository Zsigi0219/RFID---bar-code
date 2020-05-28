using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID
{
    class ActiveRFID: RFID
    {
        private BatteryType battery;

        public BatteryType Battery
        {
            get
            {
                return battery;
            }
        }

        public ActiveRFID(ulong id, FrequencyType frequency, bool isReadOnly, bool isWriteOnce, BatteryType battery)
            : base(id, frequency, isReadOnly, isWriteOnce)
        {
            this.battery = battery;
        }
        public override string ToString()
        {
            return string.Format("{0}({1} {2} {3}, {4})",
                Id,
                Frequency,
                IsReadOnly ? "RO" : "",
                IsWriteOnce ? "WO" : "",
                Battery);
            // másik megoldás: StringBuilder
        }
    }
}
