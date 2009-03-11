using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace CRySTAL
{
    [DataContract]
    public class MenuItem
    {
        [DataMember]
        public string category1;
        [DataMember]
        public string subcategory1;
        [DataMember]
        public MealTimes servedDuring;
        [DataMember]
        public string name;
        [DataMember]
        public string description;
        [DataMember]
        public double price;
        
        public enum MealTimes
        {
            breakfast = 1,
            lunch = 2,
            dinner = 4,
            latenight = 8
        }
    }

}
