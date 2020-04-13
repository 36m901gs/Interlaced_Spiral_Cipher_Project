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
            bool full_block = true;


            List<int> encode_map = new List<int>();

            while (full_block) { //this is the final section!!modify this to not rely on four block intervals? or switch if it wont be a full block?

                for (int i = block_init; i <= rim_modifier /*?*/; i++) //I think instead of using square_size, that should be a variable that I change over time. Keep everything else the same
                {
                    encode_map.Add(i);

                    for (int j = 1; j <= 3; j++)
                    {
                        encode_map.Add(i + (j * (inc_modifier))); /*?*/
                    }


                }

                inc_modifier = inc_modifier - 2;
                block_init = encode_map[encode_map.Count-1];
                rim_modifier = block_init+inc_modifier;

                if () //will determine if its a full block here
                {
                    full_block = false;
                }

                //rim_modifier = next "max" rim initiliazer, which means i = 1, needs to be changed to i =min_rim
                // the bottom row needs to be changed to be the difference between them?


            }

            if () //values arent equal means its odd, calculate final value - just subtract summation value from current sum and add it to the list?
            {

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
