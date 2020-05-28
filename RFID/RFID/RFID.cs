using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID
{
    abstract class RFID: IdentificationTechnology
    {
        private FrequencyType frequency;
        public FrequencyType Frequency
        {
            get
            {
                return frequency;
            }
        }

        private bool isReadOnly;
        public bool IsReadOnly
        {
            get
            {
                return isReadOnly;
            }
        }

        private bool isWriteOnce;

        public bool IsWriteOnce
        {
            get { return isWriteOnce; }
        }

        private bool is1stWrite = true;

        public override ulong Id
        {
            set
            {
                if (isReadOnly || (isWriteOnce && !is1stWrite))
                    throw new IdSetException(base.Id);
                is1stWrite = false;
                base.Id = value;
            }
        }

        public RFID(ulong id, FrequencyType frequency, bool isReadOnly, bool isWriteOnce): base(id)
        {
            this.frequency = frequency;
            this.isReadOnly = isReadOnly;
            this.isWriteOnce = isWriteOnce;
        }

        public override string ToString()
        {
            return string.Format("{0}({1} {2} {3})",
                Id,
                Frequency,
                IsReadOnly ? "RO" : "",
                IsWriteOnce ? "WO" : "");
            // másik megoldás: StringBuilder
        }
    }
}
