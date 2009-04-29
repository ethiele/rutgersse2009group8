using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRySTALManager
{
    class shiftsShow
    {
        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _role;

        public string role
        {
            get { return _role; }
            set { _role = value; }
        }
        private DateTime _startTime;

        public DateTime startTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }
        private DateTime? _endTime;

        public DateTime? endTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }
        private decimal _hours;

        public decimal hours
        {
            get { return _hours; }
            set { _hours = value; }
        }
        


        public shiftsShow()
        {
        }
        public shiftsShow(string _name, int _id, string _role, DateTime _startTime,
            DateTime? _endTime, decimal _hours)
        {
            name = _name;
            id = _id;
            role = _role;
            startTime = _startTime;
            endTime = _endTime;
            hours = _hours;
        }
    
    }
}
