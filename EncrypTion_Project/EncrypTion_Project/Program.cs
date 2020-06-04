using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncrypTion_Project
{
    class Encoder
    {
        public static string Decode(string message)
        {
            

            List<int> encode_path = new List<int>();
            List<char> enc_mess = new List<char>();
            
            Dictionary<string, int> square_cors = new Dictionary<string, int>();
            string final_message;
            double square_size = Math.Ceiling(Math.Sqrt(message.Length)); ;
            int cor_x = 1;
            int cor_y = 1;
            int char_index = 0;
            int mssg_index;

          
           
            char[] decoded = new char[(int)(square_size * square_size)];

            encode_path = encoder((int)square_size);  //get path
            square_cors = square_coord_gen((int)square_size);

            while (cor_y <= square_size) //this is incorrect in the first place, but also something is happening at the string generation phase - need to reset x value dum dum
            {
                while (cor_x <= square_size)
                {
                     
                    mssg_index = encode_path.IndexOf(square_cors[String.Format("{0},{1}", cor_x, cor_y)]); //determines where we will place the next value

                    if (mssg_index > message.Length - 1)
                    {
                        decoded[mssg_index] = ' ';

                    }
                    else
                    {
                        decoded[mssg_index] = message[char_index]; //  SANITY CHECK
                        
                    }

                    cor_x++;
                    char_index++;

                }
                cor_x = 1;
                cor_y++;
                

            }


            final_message = String.Join("", decoded);
            while (final_message[final_message.Length - 1] == ' ')
            {
                final_message = final_message.Substring(0,final_message.Length - 1);

            }



            return final_message;

        }


        public static string encoded_message(Dictionary<string, int> square_cors, List<int> encode_path, int square_size, string message)
        {
            List<char> enc_message = new List<char>();   
            int cor_x = 1;
            int cor_y = 1;
            int mssg_index;



            while (cor_y <= square_size) 
            {
                while (cor_x <= square_size)
                {
                     
                    mssg_index = encode_path.IndexOf(square_cors[String.Format("{0},{1}", cor_x, cor_y)]); 
                    
                    if(mssg_index > message.Length-1)
                    {
                       enc_message.Add(' ');

                    }
                    else 
                    {
                        enc_message.Add(message[mssg_index]); 
                    }
                    
                    cor_x++;
                }
                cor_x = 1;
                cor_y++;

            }

            return String.Join("", enc_message.ToArray());




        }


        public static Dictionary<string, int> square_coord_gen(int square_size) 
        {
            //I can store these values as ID's
            Dictionary<string, int> square_coordinate = new Dictionary<string, int>();
            int square_value = 1;
            int square_corx = 1;
            int square_cory = 1;
            int edge = ((square_size - 1) * 4);
            int max_x = square_size;
            int max_y = square_size;
            int min_x = 1;
            int min_y = 1;
            string key;

                while (square_value <= edge && square_value<=(square_size*square_size))
                {
                
                /*Workaround to get final values - first block for 4x4 and up, why doesnt work for 2x2, 3x3? I dont think the value gets hit at the right point?*/
                if (square_value == (square_size * square_size))
                {
                    key = string.Format("{0},{1}", square_corx, square_cory);
                    square_coordinate.Add(key, square_value);
                    break;

                } 

                while (square_corx < max_x)   //x coordinates
                {
                    //add stuff to the list
                    key = string.Format("{0},{1}", square_corx, square_cory);
                    square_coordinate.Add(key, square_value);

                    //prep next rotation
                    square_value++;
                    square_corx++;

                }
                while (square_cory < max_y)
                {
                    key = string.Format("{0},{1}", square_corx, square_cory);
                    square_coordinate.Add(key, square_value);

                    //prep next rotation
                    square_value++;
                    square_cory++;

                }
                while (square_corx > min_x)
                {
                    //add stuff to the list
                    key = string.Format("{0},{1}", square_corx, square_cory);
                    square_coordinate.Add(key, square_value);

                    //prep next rotation
                    square_value++;
                    square_corx--;

                }

                while (square_cory > (min_y+1)) 
                {
                    key = string.Format("{0},{1}", square_corx, square_cory);
                    square_coordinate.Add(key, square_value);

                    //prep next rotation
                    square_value++;
                    square_cory--;

                }

                //going to cheat here and add functionality for 2x2, 3x3 squares. Will fix later!
                if (square_size==2 && square_value==4 || square_size == 3 && square_value == 9)
                {
                    key = string.Format("{0},{1}", square_corx, square_cory);
                    square_coordinate.Add(key, square_value);

                }
                
                edge += (edge - 8);
                min_x++;
                max_x--;
                min_y++;
                max_y--;
                
                }

     
            return square_coordinate;

        }

        public static string encode_string(string message)
        {
            List<int> path = new List<int>();
            List<char> enc_mess = new List<char>();
            Dictionary<string, int> square_coords = new Dictionary<string, int>();
            string final_message;
            double square_size  = Math.Ceiling(Math.Sqrt((message.Length)));
            path = encoder((int)square_size);  //get path
            square_coords = square_coord_gen((int)square_size);
            final_message = encoded_message(square_coords, path, (int)square_size, message);




            return final_message;
        }

        public static List<int> encoder(int square_size) 
        {
            int rim_modifier = ((square_size) - 1);
            int inc_modifier = ((square_size - 1));
            int block_init = 1;
            int rim = ((4 * (square_size))-4);
            


            List<int> encode_map = new List<int>();

            while  (rim >= 4) { 

                for (int i = block_init; i <= rim_modifier; i++) 
                {
                    encode_map.Add(i);

                    for (int j = 1; j <= 3; j++)
                    {
                        encode_map.Add(i + (j * (inc_modifier))); 
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
            String message = "ux,*=XjUO,ZfmE,%@_kv&Arn+";
            String print_message = Encoder.encode_string(message);
            String print_dec_mess = Encoder.Decode(print_message);
            
            Console.WriteLine(print_message);
            Console.WriteLine(print_dec_mess);
            Console.ReadLine();

            
        }
    }
}
