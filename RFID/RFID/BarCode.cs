using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID
{
    class BarCode : IdentificationTechnology, IScannable
    {
        private bool isScanned = false;
        private const float MaxScanDistance = 0.5f;
        private bool is1stWrite = true;

        public override ulong Id {
            get {
                if (!isScanned)
                    throw new ScanException(base.Id);
                return base.Id;
            }

            set
            {
                if (!is1stWrite)
                    throw new ScanException(base.Id);
                is1stWrite = false;
                base.Id = value;
            }
        }

        public BarCode(ulong id): base(id)
        {
            //            this.isScanned = false;
        }

        public void StartScan(float distance)
        {
            if (distance > MaxScanDistance)
                throw new ScanException(Id);
            isScanned = true;
        }

        public void StopScan(float distance)
        {
            if (distance > MaxScanDistance)
                throw new ScanException(Id);
            isScanned = false;
        }
    }
}

