using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MenuWriter mw = new MenuWriter();
     
            Console.WriteLine("Wellcome to reader side!");
            mw.StartServerMenu();
            mw.StartWriterUI();
            Console.WriteLine("GOODBYE!");

            Console.ReadKey();
        }
    }
}
