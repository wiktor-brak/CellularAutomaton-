using System;

namespace AutomatKomórkowy
{
    class Program
    {

        public static bool IsInt(string text)
        {
            int num = 0;
            bool isInt = false;

            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            isInt = Int32.TryParse(text, out num);

            return isInt;
        }

        static void Main(string[] args)
        {

                Console.WriteLine("Podaj liczbę Wolframa(1-255)");
                string lwolf = Console.ReadLine(); 
                if (IsInt(lwolf) && Convert.ToInt32(lwolf) >= 1 && Convert.ToInt32(lwolf) <= 255) // check if wolfram number is int and in range beetwen 1 and 255
                {
                    lwolf = Convert.ToString(Convert.ToInt32(lwolf), 2); // binary conversion
                    string olwolf = "";
                    //complement with 0
                    if (lwolf.Length == 8)
                    {
                        olwolf = lwolf;
                    }
                    else if (lwolf.Length == 7)
                    {
                        olwolf = "0" + lwolf;
                    }
                    else if (lwolf.Length == 6)
                    {
                        olwolf = "00" + lwolf;

                    }
                    else if (lwolf.Length == 5)
                    {
                        olwolf = "000" + lwolf;
                    }
                    else if (lwolf.Length == 4)
                    {
                        olwolf = "0000" + lwolf;
                    }
                    else if (lwolf.Length == 3)
                    {
                        olwolf = "00000" + lwolf;
                    }
                    else if (lwolf.Length == 2)
                    {
                        olwolf = "000000" + lwolf;
                    }
                    else if (lwolf.Length == 1)
                    {
                        olwolf = "0000000" + lwolf;
                    }
                    Console.WriteLine("Twoja liczba binarnie = " + olwolf);
                    string[] arrayConditon = new string[8] { "111", "110", "101", "100", "011", "010", "001", "000" }; // condition table
                    Console.WriteLine("Warunki:");
                    for (int i = 0; i < 8; i++)
                    {
                        Console.WriteLine(olwolf[i] + " - " + arrayConditon[i]);
                    }

                    Console.WriteLine("Podaj na ilu bitach operacja ma być wykonana (minimum 12): ");
                    string xx = Console.ReadLine();
                    if (IsInt(xx) && Convert.ToInt32(xx) >= 12)
                    {
                        int x = Convert.ToInt32(xx);
                        int[] arrayWolf = new int[x + 2]; // main table
                        int[] fakeArray = new int[x]; // table to catch string s
                        int[] arrayCopy = new int[arrayWolf.Length]; // copy of main table


                        Console.WriteLine("Podaj liczbę startową składającą się z 1 i 0 na  " + x + " bitach");
                        Console.WriteLine("Bity brzegowe zostaną dodane automatycznie");
                        string s = Console.ReadLine();

                        if (x == s.Length) // check if given number is equal to entered 0 and 1
                        {

                            for (int i = 0; i < fakeArray.Length; i++)
                            {
                                fakeArray[i] = s[i] - 48; // fulfillement of fake table 
                            }

                            Array.Copy(fakeArray, 0, arrayWolf, 1, fakeArray.Length); // copy to main table form first place
                            Console.WriteLine("");
                            arrayWolf[0] = arrayWolf[arrayWolf.Length - 2]; // set of boundary bits
                            arrayWolf[arrayWolf.Length - 1] = arrayWolf[1];
                            Array.Copy(arrayWolf, 0, arrayCopy, 0, arrayWolf.Length); // innitialization of copy

                            for (int p = 1; p < 11; p++) // set number of operations
                            {
                                Console.WriteLine("");
                                Array.Copy(arrayCopy, 0, arrayWolf, 0, arrayCopy.Length);
                                arrayWolf[0] = arrayWolf[arrayWolf.Length - 2];
                                arrayWolf[arrayWolf.Length - 1] = arrayWolf[1];

                                for (int j = 1; j < arrayWolf.Length - 1; j++)
                                {

                                    string con = arrayWolf[j - 1].ToString() + arrayWolf[j].ToString() + arrayWolf[j + 1].ToString();
                                    int pos = Array.IndexOf(arrayConditon, con); // check if con is in arrayConditon
                                    int wolfpos = olwolf[pos] - 48;

                                    if (wolfpos == 1)
                                    {
                                        arrayCopy[j] = 1;
                                    }
                                    else
                                    {
                                        arrayCopy[j] = 0;
                                    }

                                }
                                foreach (int coss in arrayWolf)
                                {

                                    Console.Write(coss);
                                }
                                System.Threading.Thread.Sleep(1000);
                            }


                        }
                        else
                        {
                            Console.WriteLine("Podana zła ilość zer i jedynek, ilość musi się równać podanej wartości bitów");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Podaj liczbę większą lub równą 12");
                    }


                }
                else
                {
                    Console.WriteLine("Zła liczba, podaj liczbę w zakresie 1-255");
                }
                Console.ReadKey();
            
        }
    }
}
