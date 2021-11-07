using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xmlOld
{
    class walk
    {
        public int Year { get; private set; }
        public string fullLocation { get; private set; }
        public int dead { get; private set; }
        public int severelyInjured { get; private set; }
        public int minorInjury { get; private set; }
        public int injured { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public string nearBy { get; private set; }

        public walk(int Year, string fullLocation, int dead, int severelyInjured, int minorInjury, int injured, double Latitude, double Longitude, string nearBy)
        {
            this.Year = Year;
            this.fullLocation = fullLocation;
            this.dead = dead;
            this.severelyInjured = severelyInjured;
            this.minorInjury = minorInjury;
            this.injured = injured;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
            this.nearBy = nearBy;
        }
        public object[] returnAll()
        {
            object[] arr = new object[9];
            arr[0] = Year;
            arr[1] = fullLocation;
            arr[2] = dead;
            arr[3] = severelyInjured;
            arr[4] = minorInjury;
            arr[5] = injured;
            arr[6] = Latitude;
            arr[7] = Longitude;
            arr[8] = nearBy;
            return arr;
        }
        public override string ToString()
        {
            return this.fullLocation;
        }
    }
}
