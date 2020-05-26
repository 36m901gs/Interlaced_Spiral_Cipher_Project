using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncrypTion_Project
{
    class Encoder
    {

        public Dictionary<int, int> square_coord_gen(int square_size)
        {
            //I can store these values as ID's
            Dictionary<int, int> square_coordinate = new Dictionary<int, int>();
            int square_value = 1;
            int square_corx = 1;
            int square_cory = 1;
            int edge = ((square_size - 1) * 4);
            //currently bruteforcing - make this more elegant after you find a solution, think I can do away with these ni the looping phase
            int max_x = square_size;
            int max_y = square_size;
            int min_x = 1;
            int min_y = 1;
            int key = 1;

            //troubleshooting variables
            int trg = 0;

                while (square_value <= edge && square_value!=(square_size*square_size))
                {
                //generate and store coordinates
                while (square_corx < max_x)   //x coordinates
                {
                    //add stuff to the list
                    key = Convert.ToInt32(string.Format("{0}{1}", square_corx, square_cory));
                    square_coordinate.Add(square_value, key);

                    //prep next rotation
                    square_value++;
                    square_corx++;

                }
                while (square_cory < max_y)
                {
                    key = Convert.ToInt32(string.Format("{0}{1}", square_corx, square_cory));
                    square_coordinate.Add(square_value, key);

                    //prep next rotation
                    square_value++;
                    square_cory++;

                }
                while (square_corx > min_x)
                {
                    //add stuff to the list
                    key = Convert.ToInt32(string.Format("{0}{1}", square_corx, square_cory));
                    square_coordinate.Add(square_value, key);

                    //prep next rotation
                    square_value++;
                    square_corx--;

                }

                while (square_cory > (min_y+1))
                {
                    key = Convert.ToInt32(string.Format("{0}{1}", square_corx, square_cory));
                    square_coordinate.Add(square_value, key);

                    //prep next rotation
                    square_value++;
                    square_cory--;

                }

                    //update values for next set of edges and min/maxes
                    


                
                edge += (edge - 8);
                min_x++;
                max_x--;
                min_y++;
                max_y--;
                trg++;
                }







            
            return square_coordinate;




        }

        public string encode_string(string message)
        {
            List<int> path = new List<int>();
            List<char> enc_mess = new List<char>();
            string encoded_message;
            double square_size = 0;
            int msg_index = 0;

            if(message.Length % 2 != 0)
            {   
                square_size = Math.Ceiling(Math.Sqrt((message.Length + 1)));

            }
            else
            {
                square_size = Math.Ceiling(Math.Sqrt(message.Length));

            }

            path = encoder((int)square_size);

            //this is all incorrect - need to figure out what I would need to do to combine row by row (going to use coordinates instead!)
            for(int j = 0; j < (path.Count-1); j++)
            {
                if (path.IndexOf(j+1) > (message.Length-1)) /*change this to get index of the value location of j, since youre getting index on need to subtract by 1*/
                {
                    enc_mess.Insert(j, ' '); // put a space at that point
                }
                else
                {
                    enc_mess.Insert(j, message[path.IndexOf(j+1)]);//change this to get the index of the value location of j
                }
            }

            
            
            encoded_message = String.Join("", enc_mess);
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
            Dictionary<int, int> test_dict_cor = new Dictionary<int, int>();
            Encoder encoder_steve = new Encoder();

            test_dict_cor = encoder_steve.square_coord_gen(10); // need to finish up the edge reformation of loop
            foreach (KeyValuePair<int,int> entry in test_dict_cor)
            {
                Console.WriteLine(entry);
                Console.ReadLine();
            }





            /* Answer Section
            string message = "Romani_ite_domum";
            string encoded_message = encoder_steve.encode_string(message);
            Console.WriteLine(encoded_message);
            Console.ReadLine();  */




            
        }
    }
}
