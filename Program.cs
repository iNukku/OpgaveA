using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpgaveA
{
    public class Program
    {
        static void Main(string[] args)
        {
            Display myDisplay = new Display();
            /*
            Console.WriteLine(myBookList.ToString());
            Console.WriteLine("Which book placement would you like to search for ?");
            double x = double.Parse(Console.ReadLine());

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
            }*/

            Console.ReadKey();
        }
    }
}
