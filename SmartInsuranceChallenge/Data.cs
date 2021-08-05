using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInsuranceChallenge
{
    public class Data
    {
        public int PolicyNumber { get; set; }
        public int AverageSpeeding { get; set; }
        public int LaneSwerve { get; set; }
        public int StopSigns { get; set; }
        public int CloseFollow { get; set; }

        public Data() { }
        public Data(int policyNumber, int averageSpeeding, int laneSwerve, int stopSigns, int closeFollow)
        {
            PolicyNumber = policyNumber;
            AverageSpeeding = averageSpeeding;
            LaneSwerve = laneSwerve;
            StopSigns = stopSigns;
            CloseFollow = closeFollow;
        }
    }
}
