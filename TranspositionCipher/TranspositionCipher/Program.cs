using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Transposition
{
    class TranspositionCipher
    {
        static void Main(string[] args)
        {
            char[,] array;
            int x, y, textLength;         
            x = 4;                          
            double remainder;                 
            string plainText;
            char[] encipher;
            char[] decipher;
            plainText = Console.ReadLine();
            //************************************** ENCIPHER **************************************//

            textLength = plainText.Length;
            encipher = plainText.ToCharArray();
            
            remainder = textLength % x;
            if (remainder != 0)               
                y = textLength / x + 1;
            else
                y = textLength / x;

            array = new char[x + 1, y + 1];
            int z = 0;

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (z < textLength)
                    {
                        array[i, j] = encipher[z];
                        z++;
                    }
                }
            }

            decipher = new char[textLength];
            z = 0;

            for (int i = 0; i < y; i++)
            {
                if (array[i, 2] != 0)
                {
                    decipher[z] = array[i, 2];
                    z++;
                }
            }
            for (int i = 0; i < y; i++)
            {
                if (array[i, 0] != 0)
                {
                    decipher[z] = array[i, 0];
                    z++;
                }
            }
            for (int i = 0; i < y; i++)
            {
                if (array[i, 3] != 0)
                {
                    decipher[z] = array[i, 3];
                    z++;
                }
            }
            for (int i = 0; i < y; i++)
            {
                if (array[i, 1] != 0)
                {
                    decipher[z] = array[i, 1];
                    z++;
                }
            }
            Console.WriteLine(decipher);
            Console.ReadKey();

            //************************************** DECIPHER **************************************//


        }
    }
}