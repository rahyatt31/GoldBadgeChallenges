using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_03_KomodoInsurance
{                                           // Create ID Badge, Update ID Badge, Read(view), Remove from Badge
    public class BadgeRepository
    {
        Dictionary<int, string> _dictionary = new Dictionary<int, string>();


        // CREATE

        public void AddBadgeToDictionary(int badgeNumber, string doorName)
        {
            _dictionary.Add(badgeNumber, doorName);
        }
    }
}
