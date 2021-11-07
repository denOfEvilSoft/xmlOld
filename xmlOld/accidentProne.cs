using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xmlOld
{
    class accidentProne
    {
        
        public int Year { get; private set; }
        public int count { get; private set; }
        public int roadCasualties { get; private set; }
        public int dead { get; private set; }
        public int severelyInjured { get; private set; }
        public int minorInjury { get; private set; }
        public int injured { get; private set; }
        public double latitude { get; private set; }
        public double longtitude { get; private set; }
        public string Gun { get; private set; }
        public string Other1 { get; private set; } // 면 (읍)
        public string Other2 { get; private set; } // () 안
        public string fullLocation { get; private set; }

        public accidentProne(
            int Year,
            int count,
            int roadCasualties,
            int dead,
            int severelyInjured,
            int minorInjury,
            int injured,
            double latitude,
            double longtitude,
            string Gun,
            string Other1,
            string Other2,
            string fullLocation
            )
        {
            this.Year = Year;
            this.count = count;
            this.roadCasualties = roadCasualties;
            this.dead = dead;
            this.severelyInjured = severelyInjured;
            this.minorInjury = minorInjury;
            this.injured = injured;
            this.latitude = latitude;
            this.longtitude = longtitude;
            this.Gun = Gun;
            this.Other1 = Other1;
            this.Other2 = Other2;
            this.fullLocation = fullLocation;
        }
        public object[] returnAll()
        {
            object[] arr = new object[13];
            arr[0] = Year;
            arr[1] = count;
            arr[2] = roadCasualties;
            arr[3] = dead;
            arr[4] = severelyInjured;
            arr[5] = minorInjury;
            arr[6] = injured;
            arr[7] = latitude;
            arr[8] = longtitude;
            arr[9] = Gun;
            arr[10] = Other1;
            arr[11] = Other2;
            arr[12] = fullLocation;
            return arr;
        }
        public override string ToString()
        {
            return this.fullLocation;
        }
    }
}
