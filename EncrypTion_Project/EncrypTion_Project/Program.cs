using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncrypTion_Project
{
    class Encoder
    {
        public List<char> encode_string(string message)
        {
            List<int> path = new List<int>();
            string encoded_message;
            double square_size = 0;

            if(message.Length % 2 != 0)
            {   
                square_size = Math.Ceiling(Math.Sqrt((message.Length + 1)));

            }
            else
            {
                square_size = Math.Ceiling(Math.Sqrt(message.Length));

            }

            path = encoder((int)square_size);

            //1. get the size of the square we'll need --done


            //2. calculate the encode path -- done


            //3. put the strings into the List

            //4. return it as a string

            return encoded_message;
        }

        public List<int> encoder(int square_size) 
        {
            // int square_val = 0;
            int rim_modifier = ((square_size) - 1);
            int inc_modifier = ((square_size - 1));
            int block_init = 1;
            int rim = ((4 * (square_size))-4);
            


            List<int> encode_map = new List<int>();

            while  (rim >= 4) { 

                for (int i = block_init; i <= rim_modifier /*?*/; i++) 
                {
                    encode_map.Add(i);

                    for (int j = 1; j <= 3; j++)
                    {
                        encode_map.Add(i + (j * (inc_modifier))); /*set a breakpoint when the value added is 40 then step through*/
                    }

                }

                inc_modifier -= 2;
                block_init = (encode_map[encode_map.Count-1])+1;
                rim_modifier = ((block_init+inc_modifier)-1);
                rim -= 8;

            }

            if(square_size % 2 != 0)
            {
                encode_map.Add(rim_modifier + 1);
            }
       
            return encode_map;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Encoder encoder_steve = new Encoder();
            List<int> answer = encoder_steve.encoder(7);
            foreach(int val in answer)
            {
                Console.WriteLine(val);
                Console.ReadLine();
            }                     
        }
    }
}
