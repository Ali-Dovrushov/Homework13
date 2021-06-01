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
        public static bool forCheck;
        public static bool forStart;
        public static string passChecker;
        public static string myPathForOS = "/Users/dovrushov/myPathForOS/";
        public static string myPathForWin = @"C:\SomeDir";

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

        public static string CheckerPassword()
        {
            passChecker = Console.ReadLine();

            if (passChecker.Length == 11)
            {
                for (int i = 0; i < passChecker.Length; i++)
                {
                    if ((passChecker[0] != 'a' || passChecker[1] != 'z' || passChecker[2] != 'e')
                        &&
                        (passChecker[0] != 'A' || passChecker[1] != 'Z' || passChecker[2] != 'E')
                        ||
                        passChecker.Length <= 0)
                    {
                        Console.Write("Incorrect type, please first type AZE or aze and 8 numbers(AZE12345678): ");
                        CheckerPassword();
                    }

                    for (int j = 3; j < passChecker.Length; j++)
                    {
                        if (!Char.IsNumber(passChecker[j]))
                        {
                            Console.Write("Please enter AZE afret 8 digits number: ");
                            CheckerPassword();
                            break;
                        }
                    }
                }
            }

            else
            {
                Console.Write("Incorrect type, please first type AZE or aze and 8 numbers(AZE12345678): ");

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

        public static void NewTxtFileForOS()
        {
            Console.Write("Enter ID number: ");
            int idNumber = CheckerIdNumber();

            Console.Write("Enter passport number(AZE 8 digits): ");
            string passportNumber = CheckerPassword();

            Console.Write("Enter amount: ");
            double balance = CheckerBalance();

            Client client = new Client(idNumber, passportNumber, balance);

            using (StreamWriter forWrite = new StreamWriter($"{ myPathForOS }\nNote1.txt", true, System.Text.Encoding.Default))
            {
                forWrite.WriteLine($"№{ client.IDNumber }; { client.PassportNumber }; { client.Balance };");
            }

            using (StreamReader forRead = new StreamReader($"{ myPathForOS }\nNote1.txt"))
            {
                Console.WriteLine(forRead.ReadToEnd());
            }
        }

        public static void NewTxtFileForWin()
        {
            Console.Write("Enter ID number: ");
            int idNumber = CheckerIdNumber();

            Console.Write("Enter passport number(AZE 8 digits): ");
            string passportNumber = CheckerPassword();

            Console.Write("Enter amount: ");
            double balance = CheckerBalance();

            Client client = new Client(idNumber, passportNumber, balance);

            using (StreamWriter forWrite = new StreamWriter($"{ myPathForWin }/Note1.txt", true, System.Text.Encoding.Default))
            {
                forWrite.WriteLine($"№{ client.IDNumber }; { client.PassportNumber }; { client.Balance };");
            }

            using (StreamReader forRead = new StreamReader($"{ myPathForWin }/Note1.txt"))
            {
                Console.WriteLine(forRead.ReadToEnd());
            }
        }

        public static void OldTxtFileForOS()
        {
            using (StreamWriter forWrite = new StreamWriter($"{ myPathForOS }\nNote.txt", false, System.Text.Encoding.Default))
            {
                forWrite.WriteLine($"№1; AZE12345678; 22.30\n" +
                    $"№25; AZE87652134; 50.00\n" +
                    $"№34; AZE87652134; 12.35");
            }

            using (StreamReader forRead = new StreamReader($"{ myPathForOS }\nNote.txt"))
            {
                Console.WriteLine(forRead.ReadToEnd());
            }
        }

        public static void OldTxtFileForWin()
        {
            using (StreamWriter forWrite = new StreamWriter($"{ myPathForWin }/Note.txt", false, System.Text.Encoding.Default))
            {
                forWrite.WriteLine($"№1; AZE12345678; 22.30\n" +
                    $"№25; AZE87652134; 50.00\n" +
                    $"№34; AZE87652134; 12.35");
            }

            using (StreamReader forRead = new StreamReader($"{ myPathForWin }/Note.txt"))
            {
                Console.WriteLine(forRead.ReadToEnd());
            }
        }

        public static void ChooseInfoForOS()
        {
            do
            {
                string continueYesOrNo = Console.ReadLine();
                switch (continueYesOrNo)
                {
                    case "Y":
                        {
                            OldTxtFileForOS();
                            forCheck = true;

                            break;
                        }
                    case "y":
                        {
                            OldTxtFileForOS();
                            forCheck = true;

                            break;
                        }
                    case "N":
                        {
                            forCheck = true;
                            break;
                        }
                    case "n":
                        {
                            forCheck = true;
                            break;
                        }
                    default:
                        {
                            Console.Write("You enter incorrect symbol, please enter Y/y or N/n: ");
                            forCheck = false;

                            continue;
                        }
                }
            } while (forCheck == false);
        }

        public static void ChooseInfoForWin()
        {
            do
            {
                string continueYesOrNo = Console.ReadLine();
                switch (continueYesOrNo)
                {
                    case "Y":
                        {
                            OldTxtFileForWin();
                            forCheck = true;

                            break;
                        }
                    case "y":
                        {
                            OldTxtFileForWin();
                            forCheck = true;

                            break;
                        }
                    case "N":
                        {
                            forCheck = true;
                            break;
                        }
                    case "n":
                        {
                            forCheck = true;
                            break;
                        }
                    default:
                        {
                            Console.Write("You enter incorrect symbol, please enter Y/y or N/n: ");
                            forCheck = false;

                            continue;
                        }
                }
            } while (forCheck == false);
        }

        public static void ChooseLastInfoForOS()
        {
            do
            {
                string continueYesOrNo = Console.ReadLine();
                switch (continueYesOrNo)
                {
                    case "Y":
                        {
                            NewTxtFileForOS();
                            forCheck = true;

                            break;
                        }
                    case "y":
                        {
                            NewTxtFileForOS();
                            forCheck = true;

                            break;
                        }
                    case "N":
                        {
                            forCheck = true;
                            break;
                        }
                    case "n":
                        {
                            forCheck = true;
                            break;
                        }
                    default:
                        {
                            Console.Write("You enter incorrect symbol, please enter Y/y or N/n: ");
                            forCheck = false;

                            continue;
                        }
                }
            } while (forCheck == false);
        }

        public static void ChooseLastInfoForWin()
        {
            do
            {
                string continueYesOrNo = Console.ReadLine();
                switch (continueYesOrNo)
                {
                    case "Y":
                        {
                            NewTxtFileForWin();
                            forCheck = true;

                            break;
                        }
                    case "y":
                        {
                            NewTxtFileForWin();
                            forCheck = true;

                            break;
                        }
                    case "N":
                        {
                            forCheck = true;
                            break;
                        }
                    case "n":
                        {
                            forCheck = true;
                            break;
                        }
                    default:
                        {
                            Console.Write("You enter incorrect symbol, please enter Y/y or N/n: ");
                            forCheck = false;

                            continue;
                        }
                }
            } while (forCheck == false);
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Write("Please choose\n1)Windows\n2)MacOS\n3)Exit\nYour choose: ");
                byte choose = NumberCheckerForByte();

                switch (choose)
                {
                    case 1:
                        {
                            DirectoryInfo pathInfo = new DirectoryInfo(myPathForWin);
                            if (!pathInfo.Exists)
                            {
                                pathInfo.Create();
                            }

                            Console.Write("Want to read info in your .txt file(Enter Y/y or N/n): ");
                            ChooseInfoForWin();

                            Console.Write("Want to write new info in your new .txt file(Enter Y/y or N/n): ");
                            ChooseLastInfoForWin();

                            Console.Write("Want to continue(Enter Y/y or N/n): ");
                            bool checker;
                            do
                            {
                                string choiser = Console.ReadLine();
                                if (choiser == "Y" || choiser == "y")
                                {
                                    checker = true;
                                    forStart = false;
                                }
                                else if (choiser == "N" || choiser == "n")
                                {
                                    Console.WriteLine("Have a good day :)");
                                    checker = true;
                                    forStart = true;
                                }
                                else
                                {
                                    Console.Write("You enter incorrect symbol, please enter Y/y or N/n: ");
                                    checker = false;
                                }
                            } while (checker == false);

                            break;
                        }
                    case 2:
                        {
                            DirectoryInfo pathInfo = new DirectoryInfo(myPathForOS);
                            if (!pathInfo.Exists)
                            {
                                pathInfo.Create();
                            }

                            Console.Write("Want to read info in your .txt file(Enter Y/y or N/n): ");
                            ChooseInfoForOS();

                            Console.Write("Want to write new info in youur new .txt file(Enter Y/y or N/n): ");
                            ChooseLastInfoForOS();

                            Console.Write("Want to continue(Enter Y/y or N/n): ");
                            bool checker;
                            do
                            {
                                string choiser = Console.ReadLine();
                                if (choiser == "Y" || choiser == "y")
                                {
                                    checker = true;
                                    forStart = false;
                                }
                                else if (choiser == "N" || choiser == "n")
                                {
                                    Console.WriteLine("Have a good day :)");
                                    checker = true;
                                    forStart = true;
                                }
                                else
                                {
                                    Console.Write("You enter incorrect symbol, please enter Y/y or N/n: ");
                                    checker = false;
                                }
                            } while (checker == false);

                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Have a good day :)");
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