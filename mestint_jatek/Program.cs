﻿using System;
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

        static void Main(string[] args)
        {
            string test = Numbergenerator();
            string test2 = "5231205661024";

            Console.WriteLine(test);
            Console.WriteLine(test.Length);
            Console.WriteLine(Checkerone(test2,4));
            Console.WriteLine(Chekertwo(test2,3));
            Console.WriteLine(Decrese(test2,3));
            Console.WriteLine(Removeing(test2,6));
            Console.ReadLine();
        }



    
    }
}
