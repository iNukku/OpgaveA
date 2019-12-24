using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OpgaveA
{
    public class Display
    {
        #region fields
        private readonly string introMessage = "Welcome to Aarhus Public Library \n ********** \n";
        private readonly string searchMessage = "Which bookplacement would you like to check out ? (searchformat must be xx,yy) ";
        private readonly string errormessage = "Woops - an error seems to have occured... please try again";

        private BookList libraryBooklist = null;

        private bool endprogram = false;

        #endregion
        #region methods
        private void run()
        {
            while (!endprogram)            
            {
                Console.WriteLine("To view a List of Librarybooks - press 1 \n");
                Console.WriteLine("---------------------------\n");
                Console.WriteLine("To search a placement for books press 2 \n");
                Console.WriteLine("---------------------------\n");
                Console.WriteLine("To exit program press q \n");
                Console.WriteLine("---------------------------\n");
                checkInput(Console.ReadLine());
                Console.ReadLine();
            }

        }
        private void runIntro()
        {
            Console.WriteLine(introMessage);
        }
        private void checkInput(string input)
        {
            try
            {
                if (input.ToLower() == "q" )
                {
                    Console.WriteLine("Ending program - bye bye");
                    endprogram = true;
                }
                else if (int.Parse(input) == 2)
                {
                    Console.WriteLine(searchMessage);
                    checkSearchInput(Console.ReadLine());
                }
                else if (int.Parse(input) == 1)
                {
                    Console.WriteLine(libraryBooklist.ToString());
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {

                Console.WriteLine(errormessage);
            }
        }

        private void checkSearchInput(string searchinput)
        {
            if (checkForDoubleFormat(searchinput) == 1)
	        {
                List<int> indexes = libraryBooklist.GetIndexOfBooksByPlacement(double.Parse(searchinput));
                if (indexes == null)
                {
                    Console.WriteLine("No matches - sorry!");
                }
                else

                {
                    foreach (int index in indexes)
                    {
                        Console.WriteLine($"The book on this placement is : \n" + libraryBooklist.GetBook(index).ToString());
                    }
                }
	        }else
	        {
                     Console.WriteLine("You can only use the format xx,yy or xx to search \n");
	        }

        }

        private int checkForDoubleFormat(string input)
        {
            Regex regtest = new Regex(@"\A\b\d+(,(\d+))?\b\Z");

            if (regtest.IsMatch(input))
	            {
                    return 1;
	            }else
	            {
                    return -1;
	            }
        }
        #endregion

        #region Constructor
        public Display()
        {
            Book bookOne = new Book(79.41, "Rasmus Klump i Pingonesien");
            Book bookTwo = new Book(50, "NaturTeknikfaget.dk");
            Book bookThree = new Book(99.4, "The Hobbits - the many lives of Bilbo, Sam, Merry and Pippin");
            Book bookFour = new Book(79.41, "Broken Dimensions");
            Book bookFive = new Book(50.264, "Fremtidens natur i Sønderborg Kommune");
            Book bookSix = new Book(37.8, "Kunst af lyst");
            Book bookSeven = new Book(50.264, "By, sø, skov");

            libraryBooklist = BookList.Instance;

            libraryBooklist.AddBook(bookOne);
            libraryBooklist.AddBook(bookTwo);
            libraryBooklist.AddBook(bookThree);
            libraryBooklist.AddBook(bookFour);
            libraryBooklist.AddBook(bookFive);
            libraryBooklist.AddBook(bookSix);
            libraryBooklist.AddBook(bookSeven);

            this.runIntro();
            this.run();
        }
        #endregion
    }
}
