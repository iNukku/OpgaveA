using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpgaveA
{
    class Program
    {
        static void Main(string[] args)
        {
            Book bookOne = new Book(79.41, "Rasmus Klump i Pingonesien");
            Book bookTwo = new Book(50, "NaturTeknikfaget.dk");
            Book bookThree = new Book(99.4, "The Hobbits - the many lives of Bilbo, Sam, Merry and Pippin");
            Book bookFour = new Book(79.41, "Broken Dimensions");
            Book bookFive = new Book(50.264, "Fremtidens natur i Sønderborg Kommune");
            Book bookSix = new Book(37.8, "Kunst af lyst");
            Book bookSeven = new Book(50.264, "By, sø, skov");

            BookList myBookList = BookList.Instance;

            myBookList.AddBook(bookOne);
            myBookList.AddBook(bookTwo);
            myBookList.AddBook(bookThree);
            myBookList.AddBook(bookFour);
            myBookList.AddBook(bookFive);
            myBookList.AddBook(bookSix);
            myBookList.AddBook(bookSeven);

            Console.WriteLine(myBookList.ToString());
            Console.WriteLine("Which book placement would you like to search for ?");
            double x = double.Parse(Console.ReadLine());
            //int y = myBookList.GetIndexOfBookByPlacement(x);

            List<int> indexes = myBookList.GetIndexOfBooksByPlacement(x);
            if (indexes == null)
            {
                Console.WriteLine("No matches - sorry!");
            }
            else
            {
                foreach (int index in indexes)
                {
                    Console.WriteLine($"The book on this placement is : \n" + myBookList.GetBook(index).ToString());
                }
            }

           // Console.WriteLine($"The book on this placement is : \n" + myBookList.GetBook(y).ToString());


            Console.ReadKey();
        }
    }
}
