using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpgaveA
{
    class Book : IComparable<Book>
    {
        #region fields
        private double bookNumber;
        private string bookName;
        #endregion
        #region properties
        public string BookName
        {
            get { return bookName; }
        }

        public double BookNumber
        {
            get { return bookNumber; }
        }
        #endregion
        #region constructors
        public Book(double id, string name)
        {
            this.bookNumber = id;
            this.bookName = name;
        }
        #endregion

        #region public methods
        public int CompareTo(Book other)
        {
            //Implementing ICompare Interface
            //Returns integer 1, 0 or -1
            //=1: Greater than comparison Book Object
            //=0: equals comparison Book Object
            //-1: Lesser than comparison Book Object
            if (this.BookNumber > other.BookNumber)
            {
                return 1;
            }
            else if (this.BookNumber < other.BookNumber)
            {
                return -1;
            }
            else
            {
                if (string.Compare(this.bookName, other.bookName) == 1)
                {
                    return 1;
                }
                else if (string.Compare(this.bookName, other.bookName) == -1)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public override string ToString()
        {
            string returnString = "";
            returnString += $"Placement ID: {this.BookNumber} ---- Name of Book: {this.BookName}.";

            return returnString;
        }
        #endregion
    }
}
