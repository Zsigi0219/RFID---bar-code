using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID
{
    abstract class IdentificationTechnology
    {
        private ulong id;

        virtual public ulong Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value > 9999999999999)
                    throw new Exception("Túl nagy ID érték!");
                id = value;
            }
        }

        public IdentificationTechnology(ulong id)
        {
            this.Id = id;
        }

        public override string ToString()
        {
            return string.Format("Id: {0}", id);
        }
    }
}