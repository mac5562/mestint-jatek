using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestint_jatek
{
    class Program
    {
        static public string Numbergenerator() //a függvény generál egy szám sorozatott ami nagy valószínüséggel tartalmaz 0-át
        {
            string generated = null;
            int number;
            Random rnd_length = new Random();
            Random rnd_number = new Random();
            int length = rnd_length.Next(10, 21);

            for (int i = 0; i < length; i++)
            {
                number = rnd_number.Next(0, 9);
                if (number * 2 % 6 == 0)
                {
                    int zero = 0;
                    generated = generated + zero.ToString();

                }
                else
                {
                    generated = generated + number.ToString();
                }


            }


            return generated;
        }

        static public bool Checkerone(string generated, int number) //Ellenörzi, hogy a megadott pozíción lévő szám nem nulla illetve a szám nem nagyobb mint a számsorozat hossza
        {
            bool result = false;
            for (int i = 0; i < generated.Length; i++)
            {
                if (number <= generated.Length + 1 && i == number - 1 && (int)Char.GetNumericValue(generated[i]) != 0)
                {
                    result = true;
                    break;
                }
                else
                {
                    result = false;
                }

            }

            return result;

        }
        static public bool Chekertwo(string generated, int position) //Ellenörzi, hogy a hátulról megadott pozíción 0-e található, illetve, hogy a megadott szám nem nagyobb mint a számsorozat hossza
        {
            bool result = false;
            for (int i = generated.Length - 1; i >= generated.Length - position; i--)
            {

                if (position <= generated.Length && (int)Char.GetNumericValue(generated[generated.Length - position]) == 0 && i == generated.Length - position)
                {
                    int test = (int)Char.GetNumericValue(generated[i]);
                    result = true;
                    break;
                }
                else
                {
                    result = false;
                }

            }
            return result;

        }

        static public string Decrese(string generated, int position)//Ellenörzés után csökkenti a megadott pozíción lévő számott 1-el 
        {

            string newone = generated;
            char[] ch = newone.ToCharArray();
            int number = ((int)char.GetNumericValue(newone[position - 1]) - 1) + '0';
            char replaceble = Convert.ToChar(number);
            ch[position - 1] = replaceble;
            newone = new string(ch);

            return newone;
        }
        static public string Removeing(string generated, int position)//Ellenörzés után eltávolítja a megadott pozíción lévő nullával kezdödő sorozatott
        {
            string newone = null;
            newone = generated.Remove(generated.Length - position);

            return newone;
        }
        static public void Gameover(int id)//Kapott id alapján kiírja a vesztest
        {
            if (id == 1)
            {
                Console.WriteLine("Játék vége !!! a játékos vesztett");
            }
            else
            {
                Console.WriteLine("Játék vége !!! az Ai vesztett");
            }

        }
        static public int Aimovechoice(string generated)//Visszaadja, hogy mi legyen a Ai választása
        {
            int choice = 0;
            for (int i = 0; i < generated.Length; i++)
            {
                if (generated[i] == '0')
                {
                    choice = 0;
                    break;
                }
                else if (generated[i] == '1')
                {
                    choice = 1;
                    break;
                }

            }


            return choice;
        }

        static public int Aipositionchoice(string generated, int aichoice) // Miután megvan melyik pozíciót választja a gép, a függvény visszaad egy érvényes pozíciót
        {
            int choice = 0;
            if (aichoice == 0)
            {
                for (int i = generated.Length - 1; i >= 0; i--)
                {
                    if (generated[i] == '0')
                    {
                        choice = generated.Length - i;
                        break;

                    }
                }
            }
            else if (aichoice == 1)
            {
                for (int i = 0; i < generated.Length; i++)
                {
                    if (generated[i] == '1' || generated[i] == '2')
                    {
                        choice = i + 1;
                        break;
                    }
                }
            }
            return choice;
        }

        static void Main(string[] args)
        {
            string generated = Numbergenerator();
            string test2 = "5231205661024";
            int playerid = 1;
            int aiid = 2;
            int lastid;
            int playermovechoice;
            int aimovechoice;
            int position;
            bool gamerunning = true;
            string result = generated;
            Console.WriteLine("Adott egy tetszőleges hosszú, 0, 1, . . . , 9 számjegyekből álló szám (vezetőnullák lehetnek az elején).\n A játékosok felváltva következnek lépni.Egylépésben az alábbi két lépés közül választhatnak: ");
            Console.WriteLine(" 1: egy 0-nál nagyobb számjegy értékét eggyel csökkentik, \n 0: letörölnek a szám végéről egy 0-val kezdődő, legalább 1 hosszú számjegysorozatot");
            Console.WriteLine("Az a játékos veszít aki utoljára tud lépni");
            while (gamerunning) //játék loop
            {
                Console.WriteLine("Jelenlegi érték: " + result);// A játékos kezd
                Console.WriteLine("Melyik lépést választja?");

                playermovechoice = int.Parse(Console.ReadLine());

                switch (playermovechoice)
                {
                    case 1:
                        Console.WriteLine("Adja meg a csökkenteni kivánt szám helyzetétt");
                        position = int.Parse(Console.ReadLine());
                        if (Checkerone(result, position) == true)
                        {
                            result = Decrese(result, position);
                            Console.WriteLine("Müvelet után: " + result);
                            lastid = playerid;
                            if (!result.Contains('0') || !result.Contains('1'))//Ha már a számsorozat nem tartalmaz 1-et vagy 0-át akkor a játéknak vége
                            {
                                gamerunning = false;
                                Gameover(lastid);
                                Console.WriteLine("Végső érték: " + result);
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("A megadott pozíció érvénytelen");
                            break;
                        }
                        break;
                    case 0:
                        Console.WriteLine("Adja meg a eltávolítani kivánt kivánt karakterlánc kezdő nullájának helyzetétt hátulról nézve");
                        position = int.Parse(Console.ReadLine());
                        if (Chekertwo(result, position) == true)
                        {
                            result = Removeing(result, position);
                            Console.WriteLine("Müvelet után: " + result);
                            lastid = playerid;
                            if (!result.Contains('0') && !result.Contains('1'))
                            {
                                gamerunning = false;
                                Gameover(lastid);
                                Console.WriteLine("Végső érték: " + result);
                                goto Finish;
                            }
                        }
                        else
                        {
                            Console.WriteLine("A megadott pozíció érvénytelen");
                            break;
                        }

                        break;
                    default:
                        Console.WriteLine("Csak 1-et vagy 0-át adhat meg !!!");
                        break;
                }



                Console.WriteLine("AI lépése");
                aimovechoice = Aimovechoice(result);
                switch (aimovechoice)
                {
                    case 1:
                        Console.WriteLine("Ai csökkenti az általa gondolt számot 1-el");
                        position = Aipositionchoice(result, aimovechoice);
                        if (Checkerone(result, position) == true)
                        {
                            result = Decrese(result, position);
                            Console.WriteLine("Müvelet után: " + result);
                            lastid = aiid;
                            if (!result.Contains('0') || !result.Contains('1'))
                            {
                                gamerunning = false;
                                Gameover(lastid);
                                Console.WriteLine("Végső érték: " + result);
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("A megadott pozíció érvénytelen");
                            break;
                        }
                        break;

                    case 0:
                        Console.WriteLine("Az Ai kiválasztja törölni kivánt karakterlánc kezdő 0-jának pozícióját");
                        position = Aipositionchoice(result, aimovechoice);
                        if (Chekertwo(result, position) == true)
                        {
                            result = Removeing(result, position);
                            Console.WriteLine("Müvelet után: " + result);
                            lastid = aiid;
                            if (!result.Contains('0') && !result.Contains('1'))
                            {
                                gamerunning = false;
                                Gameover(lastid);
                                Console.WriteLine("Végső érték: " + result);
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("A megadott pozíció érvénytelen");
                            break;
                        }
                        break;

                }


            }



            //Console.WriteLine(test);
            //Console.WriteLine(test.Length);
            //Console.WriteLine(Checkerone(test2,4));
            //Console.WriteLine(test2);
            //Console.WriteLine(Chekertwo(test2,3));
            //Console.WriteLine(Decrese(test2,3));
            //Console.WriteLine(Removeing(test2,3));


Finish:
            Console.ReadLine();
        }




    }
}



