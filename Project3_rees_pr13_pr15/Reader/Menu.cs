using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader
{
    public class Menu
    {
        public int Read { get; set; }
        public string Code { get; set; }

        public Menu(int read, string code) {
            Read = read;
            Code = code;
        }

        public Menu() { }

        public void PrintRead() {
            bool isValid = false;
            do
            {
                Console.WriteLine("1.   Reading the last value arrived at the database");
                Console.WriteLine("2.   Read the values ​​from the selected time interval");
                Console.WriteLine("3.   Number of active Workers");

                

                int number;
                Int32.TryParse(Console.ReadLine(), out number);
                isValid = ChoiseRead(number);

            } while (isValid == false);
        }

        public bool ChoiseRead(int input) {
            bool ret = false;
            if (input != 1 && input != 2 && input != 3)
            {
                Console.WriteLine("Bad input, try again...");
                ret = false;
            }
            else {
                Read = input;
                ret = true;
            }
            return ret;
         }


        public void PrintCode() {
            bool isValid = false;
            do
            {
                Console.WriteLine("Please select CODE: ");
                Console.WriteLine("1.   CODE_ANALOG");
                Console.WriteLine("2.   CODE_DIGITAL");
                Console.WriteLine("3.   CODE_CUSTOM");
                Console.WriteLine("4.   CODE_LIMITSET");
                Console.WriteLine("5.   CODE_SINGLENODE");
                Console.WriteLine("6.   CODE_MULTIPLENODE");
                Console.WriteLine("7.   CODE_CONSUMER");
                Console.WriteLine("8.   CODE_SOURCE");

                int numCODE;
                Int32.TryParse(Console.ReadLine(), out numCODE);

                isValid = ChoiseCode(numCODE);                        


            } while (isValid == false);

        }

        public bool ChoiseCode(int input) {
            bool ret = false;

            switch (input)
            {
                case 1:
                    Code = "CODE_ANALOG";
                    ret = true;
                    break;
                case 2:
                    Code = "CODE_DIGITAL";
                    ret = true;
                    break;
                case 3:
                    Code = "CODE_CUSTOM";
                    ret = true;
                    break;
                case 4:
                    Code = "CODE_LIMITSET";
                    ret = true;
                    break;
                case 5:
                    Code = "CODE_SINGLENODE";
                    ret = true;
                    break;
                case 6:
                    Code = "CODE_MULTIPLENODE";
                    ret = true;
                    break;
                case 7:
                    Code = "CODE_CONSUMER";
                    ret = true;
                    break;
                case 8:
                    Code = "CODE_SOURCE";
                    ret = true;
                    break;
                default:
                    Console.WriteLine("Bad input, try again...");
                    ret = false;
                    break;
            }
        
            return ret;
        }
    }
}
