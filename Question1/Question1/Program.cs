using System;
using System.IO;

namespace Question1
{
    class Client
    {
        private int idNumber;
        private string passportNumber;
        private double balance;

        public int IDNumber { get { return idNumber; } set { idNumber = value; } }
        public string PassportNumber { get { return passportNumber; } set { passportNumber = value; } }
        public double Balance { get { return balance; } set { balance = value; } }

        public Client(int IDNumber, string PassportNumber, double Balance)
        {
            idNumber = IDNumber;
            passportNumber = PassportNumber;
            balance = Balance;
        }
    }

    class Program
    {
        static int CheckerIdNumber()
        {
            int number;

            for (; ; )
            {
                string numberInString = Console.ReadLine();

                if (Int32.TryParse(numberInString, out number))
                {
                    return number;
                }

                else
                {
                    Console.Write("Incorrect number, please enter again: ");
                }
            }
        }

        public static string passChecker;

        public static string CheckerPassword()
        {
            passChecker = Console.ReadLine();

            if (passChecker.Length == 11)
            {
                for (int i = 0; i < passChecker.Length; i++)
                {
                    if ((passChecker[0] != 'a' || passChecker[1] != 'z' || passChecker[2] != 'e') && (passChecker[0] != 'A' || passChecker[1] != 'Z' || passChecker[2] != 'E') || passChecker.Length <= 0)
                    {
                        Console.WriteLine("Incorrect type, please first type AZE or aze");
                        CheckerPassword();
                    }

                    else
                    {
                        break;
                    }
                }
            }

            else
            {
                Console.Write("Incorrect type, please first type AZE or aze and 8 numbers: ");

                CheckerPassword();
            }

            return passChecker;
        }

        static double CheckerBalance()
        {
            double number;

            for (; ; )
            {
                string numberInString = Console.ReadLine();

                if (Double.TryParse(numberInString, out number))
                {
                    return number;
                }

                else
                {
                    Console.Write("Incorrect number, please enter again: ");
                }
            }
        }

        static byte NumberCheckerForByte()
        {
            byte number;

            for (; ; )
            {
                string numberInString = Console.ReadLine();

                if (Byte.TryParse(numberInString, out number))
                {
                    return number;
                }

                else
                {
                    Console.Write("Incorrect, if your PC Windows enter 1, else your PC MacOS enter 2: ");
                }
            }
        }

        public static string myPath = "/Users/dovrushov/myPath/";

        public static void Arg1()
        {
            Console.Write("Enter ID number: ");
            int idNumber = CheckerIdNumber();

            Console.Write("Enter passport number(AZE 8 digits): ");
            string passportNumber = CheckerPassword();

            Console.Write("Enter amount: ");
            double balance = CheckerBalance();

            Client client = new Client(idNumber, passportNumber, balance);

            using (StreamWriter forWrite = new StreamWriter($"{ myPath }\nNote1.txt", false, System.Text.Encoding.Default))
            {
                forWrite.WriteLine($"№{ client.IDNumber }; { client.PassportNumber }; { client.Balance };");
            }

            using (StreamReader forRead = new StreamReader($"{ myPath }\nNote1.txt"))
            {
                Console.WriteLine(forRead.ReadToEnd());
            }
        }

        public static void Arg()
        {
            using (StreamWriter forWrite = new StreamWriter($"{ myPath }\nNote.txt", false, System.Text.Encoding.Default))
            {
                forWrite.WriteLine($"№1; AZE12345678; 22.30\n" +
                    $"№25; AZE87652134; 50.00\n" +
                    $"№34; AZE87652134; 12.35");
            }

            using (StreamReader forRead = new StreamReader($"{ myPath }\nNote.txt"))
            {
                Console.WriteLine(forRead.ReadToEnd());
            }
        }

        public static bool forStart;
        static void Main(string[] args)
        {
            do
            {
                Console.Write("Please choose\n1)Windows\n2)MacOS\nYour choose: ");
                byte choose = NumberCheckerForByte();

                switch (choose)
                {
                    case 1:
                        {

                            forStart = true;
                            break;
                        }
                    case 2:
                        {
                            //string myPath = "/Users/dovrushov/myPath/";

                            DirectoryInfo pathInfo = new DirectoryInfo(myPath);
                            if (!pathInfo.Exists)
                            {
                                pathInfo.Create();
                            }

                            Arg();
                            //Arg

                            //using (StreamWriter forWrite = new StreamWriter($"{ myPath }\nNote.txt", false, System.Text.Encoding.Default))
                            //{
                            //    forWrite.WriteLine($"№1; AZE12345678; 22.30\n" +
                            //        $"№25; AZE87652134; 50.00\n" +
                            //        $"№34; AZE87652134; 12.35");
                            //}

                            //using (StreamReader forRead = new StreamReader($"{ myPath }\nNote.txt"))
                            //{
                            //    Console.WriteLine(forRead.ReadToEnd());
                            //}

                            Arg1();
                            //Arg1
                            //Console.Write("Enter ID number: ");
                            //int idNumber = CheckerIdNumber();

                            //Console.Write("Enter passport number(AZE 8 digits): ");
                            //string passportNumber = CheckerPassword();

                            //Console.Write("Enter amount: ");
                            //double balance = CheckerBalance();

                            //Client client = new Client(idNumber, passportNumber, balance);

                            //using (StreamWriter forWrite = new StreamWriter($"{ myPath }\nNote1.txt", false, System.Text.Encoding.Default))
                            //{
                            //    forWrite.WriteLine($"№{ client.IDNumber }; { client.PassportNumber }; { client.Balance };");
                            //}

                            //using (StreamReader forRead = new StreamReader($"{ myPath }\nNote1.txt"))
                            //{
                            //    Console.WriteLine(forRead.ReadToEnd());
                            //}

                            forStart = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Incorrect, if your PC Windows enter 1, else your PC MacOS enter 2\n");
                            forStart = false;
                            continue;
                        }
                }
            } while (forStart == false);
            Console.ReadKey();
        }
    }
}
