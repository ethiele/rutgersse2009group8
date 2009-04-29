using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRySTALManager
{
    public class CustTimeData
    {
        List<TimeFrame> tfl;
        public List<TimeFrame> Times
        {
            get
            {
                return tfl;
            }
            set
            {
                tfl = value;
            }
        }

        private List<int> custperHour;
        public List<int> CustPerHour
        {
            get
            {
                List<int> i = new List<int>();
                i.Add(1);
                i.Add(2);
                i.Add(4);
                i.Add(9);
                i.Add(9);
                i.Add(7);
                i.Add(8);
                i.Add(5);
                i.Add(3);
                return i;
            }
        }


    }

    public class TimeFrame
    {
        private DateTime start;
        private DateTime end;
        public DateTime Start { get { return start; } set { start = value; } }
        public DateTime End { get { return end; } set { end = value; } }
    }
}
