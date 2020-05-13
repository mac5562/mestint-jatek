using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestint_jatek
{
    class Program
    {
        static public string Numbergenerator()
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

        static public bool Checkerone(string generated,int number)
        {
            bool result=false;
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
        static public bool Chekertwo(string generated,int position)
        {
            bool result = false;
            for (int i = generated.Length-1; i >= generated.Length-position; i--)
            {
              
                if (position <= generated.Length && (int)Char.GetNumericValue(generated[generated.Length  - position])==0 && i== generated.Length - position)
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

        static public string Decrese(string generated,int position)
        {
  
            string newone = generated;
            char[] ch = newone.ToCharArray();
            int number = ((int)char.GetNumericValue(newone[position - 1]) - 1)+'0';
            char replaceble = Convert.ToChar(number);
            ch[position - 1] = replaceble;
            newone = new string(ch);
            
             return newone;
        }
        static public string Removeing(string generated,int position)
        {
            string newone=null;
            newone = generated.Remove(position-1);

            return newone;
        }
        static public void Gameover(int id)
        {
            if (id==1)
            {
                Console.WriteLine("Játék vége !!! a játékos vesztett");
            }
            else
            {
                Console.WriteLine("Játék vége !!! az Ai vesztett");
            }
            
        }

        static void Main(string[] args)
        {
            string test = Numbergenerator();
            string test2 = "5231205661024";
            int playerid = 1;
            int aiid = 2;
            int lastid;
            int movechoice;
            int position;
            Random airnd = new Random();
            bool gamerunning = true;
            string result=test2;

            while (gamerunning)
            {
                Console.WriteLine(result);
                Console.WriteLine("Melyik lépést választja?");
                movechoice = int.Parse(Console.ReadLine());
                switch (movechoice)
                {
                    case 0:
                        Console.WriteLine("Adja meg a csökkenteni kivánt szám helyzetétt");
                        position = int.Parse(Console.ReadLine());
                        if (Checkerone(result,position)==true)
                        {
                            result = Decrese(result, position);
                            lastid = playerid;
                            if (!result.Contains('0') || !result.Contains('1'))
                            {
                                gamerunning = false;
                                Gameover(lastid);
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("A megadott pozíció érvénytelen");
                            break;
                        }
                        break;
                    case 1:
                        Console.WriteLine("Adja meg a eltávolítani kivánt kivánt karakterlánc kezdő nullájának helyzetétt");
                        position = int.Parse(Console.ReadLine());
                        if (Chekertwo(result,position)==true)
                        {
                            result = Removeing(result, position);
                            lastid = playerid;
                            if (!result.Contains('0') && !result.Contains('1'))
                            {
                                gamerunning = false;
                                Gameover(lastid);
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
            //Console.WriteLine(Chekertwo(test2,3));
            //Console.WriteLine(Decrese(test2,3));
            //Console.WriteLine(Removeing(test2,6));



            Console.ReadLine();
        }



    
    }
}
