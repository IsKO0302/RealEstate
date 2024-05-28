using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo123
{
    internal class Agent
    {

        public int Id { get; set; }

        private string FirstName, MiddleName, LastName, DealShare;

        public string firstName {
            get {  return FirstName; } 
            set { FirstName = value; }
        }

        public string middleName
        {
            get { return MiddleName; }
            set { MiddleName = value; }
        }

        public string lastName
        {
            get { return LastName; }
            set { LastName = value; }
        }

        public string dealShare
        {
            get { return DealShare; }
            set { DealShare = value; }
        }

        public Agent() { }

        public Agent(string FirstName, string MiddleName, string LastName, string DealShare)
        {
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
            this.DealShare = DealShare;
        }

    }
}
