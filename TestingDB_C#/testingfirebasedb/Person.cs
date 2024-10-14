using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testingfirebasedb
{
    internal class Person
    {
        private string name { get; set; }
        private string ID { get; set; }

        public Person (string a_name, string a_ID)
        {
            name = a_name;
            ID = a_ID;
        }

        public string getName ()
        {
            return name;
        }
        public string getID()
        {
            return ID;
        }
    }
}
