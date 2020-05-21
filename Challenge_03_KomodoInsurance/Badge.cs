using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_03_KomodoInsurance
{
    public class Badge
    {
        public int BadgeNumber { get; set; }
        public string DoorName { get; set; }

        public Badge() { }

        public Badge(int badgeNumber, string doorName)
        {
            BadgeNumber = badgeNumber;
            DoorName = doorName;
        }
        
    }
}
