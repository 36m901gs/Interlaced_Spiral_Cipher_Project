using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncrypTion_Project
{
    class Encoder
    {

        //almost there - still needs some tweaking. Slightly misunderstood the problem. I need to combine 
        //ROWS, not just add the corners sequentially.Think about tomororw - use indices of path, rather than the actual
        //value? As in, the 5th index of the path has the value "2". So put the 5th value in the message, and put it 
        // in space 2 when you encode it. SO i think the origal message index coincides with encoded path index - so you need to piece
        // together the encoded message by finding "1,2,3,4"...in the encoded_path, and when you find it, use that index to select the 
        // character from the original message. if It doesnt exist, put a space there
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

            //this is all incorrect - need to figure out what I would need to do to combine row by row
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
            Encoder encoder_steve = new Encoder();
            string message = "Romani_ite_domum";
            string encoded_message = encoder_steve.encode_string(message);
            Console.WriteLine(encoded_message);
            Console.ReadLine();
        }
    }
}
