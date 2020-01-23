using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaIOsiExceptii
{
    class Program
    {
        public static Boolean TryParse(string numberOrNot)
        {
            try
            {
                int.Parse(numberOrNot);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        const string readFileName = "numbers.txt";
        static void Main(string[] args)
        {
            if (File.Exists(readFileName))
            {
                if (new FileInfo(readFileName).Length > 0)
                {

                    List<string> validNumbers = new List<string>();
                    List<string> invalidNumbers = new List<string>();

                    string[] allLinesFromFile = File.ReadAllLines(readFileName);

                    foreach (string newItem in allLinesFromFile)
                    {
                        if (TryParse(newItem))
                        {
                            validNumbers.Add(newItem);
                        }
                        else
                        {
                            invalidNumbers.Add(newItem);
                        }
                    }

                    if (validNumbers.Count != 0)
                    {
                        using (StreamWriter correctStreamWriter = new StreamWriter("correctNumbers.txt")) 
                        {
                            foreach (string item in validNumbers)
                            {
                                correctStreamWriter.WriteLine(item);
                            }   
                        }
                        
                    }

                    if (invalidNumbers.Count != 0)
                    {
                        using (StreamWriter incorrectStreamWriter = new StreamWriter("incorrectNumbers.txt"))
                        {
                            foreach (string item in invalidNumbers)
                            {
                                incorrectStreamWriter.WriteLine(item);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File exists but it is empty!");
                }

            }
            else
            {
                Console.WriteLine("File Not Found! Please create you 'numbers.txt' file.");
            }
        }
    }
}
