using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncrypTion_Project
{
    class Encoder
    {
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
                        encode_map.Add(i + (j * (inc_modifier))); /*?*/
                    }


                }

                inc_modifier -= 2;
                block_init = (encode_map[encode_map.Count-1])+1;
                rim_modifier = (block_init+inc_modifier);
                rim -= 8;

             


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
