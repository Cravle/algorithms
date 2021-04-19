using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Date: IComparable
    {
        public string Name { get; set; }
        public int PasId { get; set; }
        public int Age { get; set; }

        public Date(string name, int pasId, int age)
        {
            Name = name;
            PasId = pasId;
            Age = age;
        }

        public int CompareTo(object obj)
        {
            return Name.CompareTo(obj);
        }

        public override string ToString()
        {
            return $"|{Name}, {PasId}, {Age}|";
        }
    }
}
