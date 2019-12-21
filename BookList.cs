using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpgaveA
{
    class BookList
    {
        #region fields
        private List<Book> Books = new List<Book>();
        private static volatile BookList instance;
        #endregion
        #region static methods
        public static BookList Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new BookList();
                }
                return instance;
            }
        }
        #endregion
        #region public methods
        public void AddBook(Book book)
        {
            this.Books.Add(book);
            // Books.Sort();
            Books = QuickSort(Books);
        }

        public List<Book> GetBooks()
        {
            return Books;
        }

        public Book GetBook(int index)
        {
            return Books[index];
        }

        // Returns List of books on specified location
        // Returns null if no books were found
        public List<int> GetIndexOfBooksByPlacement(double target)
        {
            List<int> indexes = new List<int>();
            int min = 0;
            int max = Books.Count - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;

                //Check which side of collection to search
                if (target < Books[mid].BookNumber)
                {
                    max = mid - 1;
                }
                else if (target > Books[mid].BookNumber)
                {
                    min = mid + 1;
                }
                else
                {
                    int startvalue = mid;
                    while (target == Books[(startvalue - 1)].BookNumber && startvalue > 0)
	                    {
                            startvalue--;
	                    }
                    while (target == Books[startvalue].BookNumber)
	                    {
                            indexes.Add(startvalue);
                            startvalue++;
	                    }

                    return indexes;
                }
            }
            //if no matches
            return null;
        }

        public override string ToString()
        {
            string returnstring = "";

            foreach (Book book in Books)
            {
                returnstring += $"{book.ToString()} \n";
            }

            return returnstring;
        }
        #endregion

        #region private methods
        private List<Book> QuickSort(List<Book> items)
        {
            if (items.Count <= 1)
            {
                return items;
            }
            List<Book> before = new List<Book>();
            List<Book> after = new List<Book>();

            Book pivot = items[0];

            for (int i = 1; i < items.Count; i++)
            {
                if (items[i].BookNumber > pivot.BookNumber)
                {
                    after.Add(items[i]);
                }
                else if (items[i].BookNumber == pivot.BookNumber)
                {
                    if (string.Compare(items[i].BookName, pivot.BookName) == -1)
                    {
                        before.Add(items[i]);
                    }
                    else
                    {
                        after.Add(items[i]);
                    }
                }
                else
                {
                    before.Add(items[i]);
                }
            }

            List<Book> result = new List<Book>();
            result.AddRange(QuickSort(before));
            result.Add(pivot);
            result.AddRange(QuickSort(after));

            return result;
        }
        #endregion
        #region constructors
        private BookList() { }
        #endregion
    }
}
