using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xmlOld
{
    class restaurant // 시작 대문자로 할 것
    {
        public string Name { get; private set; } // 시설 이름
        public string Do { get; private set; }
        public string Si { get; private set; }
        public string Gun { get; private set; }
        public string Other { get; private set; }
        public string Institution { get; private set; } // 기관
        public string Number { get; private set; }
        public string Location { get; private set; } // 급식 장소
        public string Target { get;private set; }
        public string Time { get; private set; }
        public string DayOfTheWeek { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public restaurant(
            string Name,
            string Do,
            string Si,
            string Gun,
            string Other,
            string Institution,
            string Number,
            string Location,
            string Target,
            string Time,
            string DayOfTheWeek, 
            double Latitude, 
            double Longitude
            )
        {
            this.Name = Name; 
            this.Do = Do;
            this.Si = Si;
            this.Gun = Gun; 
            this.Other = Other;
            this.Institution = Institution; 
            this.Number = Number; 
            this.Location = Location;
            this.Target = Target;
            this.Time = Time; 
            this.DayOfTheWeek = DayOfTheWeek; 
            this.Latitude = Latitude; 
            this.Longitude = Longitude;
        }
        public object[] returnAll()
        {
            object[] arr = new object[13];
            arr[0] = Name;
            arr[1] = Do;
            arr[2] = Si;
            arr[3] = Gun;
            arr[4] = Other;
            arr[5] = Institution;
            arr[6] = Number;
            arr[7] = Location;
            arr[8] = Target;
            arr[9] = Time;
            arr[10] = DayOfTheWeek;
            arr[11] = Latitude;
            arr[12] = Longitude;
            return arr;
        }
        public override string ToString()
        {
            return this.Location;
        }
    }

}
