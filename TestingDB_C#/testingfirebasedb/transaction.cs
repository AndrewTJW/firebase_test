using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testingfirebasedb
{
    internal class transaction : Person
    {
        private double transaction_val { get; set; }
        private DateTime transaction_date { get; set; }

        private Person person_info { get; set; }

        public transaction (double a_transaction_val, DateTime a_transaction_date, string a_name, string a_ID) : base(a_name, a_ID)
        {
            transaction_val = a_transaction_val;
            transaction_date = a_transaction_date;
        }

        public double getTransVal()
        {
            return transaction_val;
        }

        public DateTime getDateTime()
        {
            return transaction_date;
        }

    }
}
