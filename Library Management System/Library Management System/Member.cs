using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
 

    public class Member
    {
        private string name;
            private string cnic;
            private List<int> borrowedBooks;

        public Member(string name, string cnic)
        {
            this.name = name;
            this.cnic = cnic;
        }

        public string CNIC
        {
            get { return cnic; }
        }

        public bool hasBorrowed(int bookID)
        {
            return borrowedBooks.Contains(bookID);
        }
    }
}


