using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID
{
    interface IScannable
    {
        void StartScan(float distance);
        void StopScan(float distance);
    }
}
