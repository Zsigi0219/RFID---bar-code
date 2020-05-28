using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID
{
    class PassiveRFID : RFID, IScannable
    {
        private bool isScanned = false;
        private readonly float[] maxScanDistances = { 0.1f, 1, 100, 200 };

        public void StartScan(float distance)
        {
/*            switch (Frequency)
            {
                case FrequencyType.LF:
                    if (distance > 0.1)
                        throw new ScanException(Id);
                    break;
                case FrequencyType.HF:
                    if (distance > 1)
                        throw new ScanException(Id);
                    break;
            }*/

            if (10 * distance > (int)Frequency)
                throw new ScanException(Id);
            isScanned = true;
        }

        public void StopScan(float distance)
        {
            if (distance > maxScanDistances[(int)Frequency])
                throw new ScanException(Id);
            isScanned = false;
        }

        public override ulong Id {
            get
            {
                if (!isScanned)
                    throw new ScanException(base.Id);
                return base.Id;
            }
        }

        public PassiveRFID(ulong id, FrequencyType frequency, bool isReadOnly, bool isWriteOnce)
            : base(id, frequency, isReadOnly, isWriteOnce)
        {
        }
    }
}
