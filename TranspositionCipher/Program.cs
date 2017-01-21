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
            int x, y, z, textLength;
            int[] key = {3, 1, 4, 2};       //KLUCZ
            x = key.Length; 
            double remainder;                 
            string plainText;
            char[] temp;
            char[] encipherText;
            Console.Write("Wprowadź tekst: ");
            plainText = Console.ReadLine();
            //************************** ENCIPHER ****************************//
            textLength = plainText.Length;
            temp = plainText.ToCharArray();
            
            remainder = textLength % x;     //reszta z dzielenia tekstu przez liczbę kolumn
            if (remainder != 0)               
                y = textLength / x + 1;     //jeśli reszta większa od zera zwiększ rozmiar kolumny
            else
                y = textLength / x;

            array = new char[y, x];
            z = 0;

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (z < textLength)
                    {
                        array[i, j] = temp[z];
                        z++;
                    }
                }
            }
            encipherText = new char[textLength];        //tablica na zaszyfrowany tekst
            z = 0;                                  //licznik tablicy
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if(array[j, key[i] - 1] != '\0')
                        {
                            encipherText[z] = array[j, key[i] - 1];
                            z += 1;
                        }
                }
            }
            Console.WriteLine(encipherText);
            Console.ReadKey();

            //************************** DECIPHER ***************************//

            int remainder2;
            int encipherLength;
            int a, b;
            int[] key2 = { 3, 1, 4, 2 };       //KLUCZ
            a = key.Length;
            char[,] array2;

            encipherLength = encipherText.Length;
            remainder2 = encipherLength % x;     //reszta z dzielenia tekstu przez liczbę kolumn
            if (remainder2 != 0)
                b = encipherLength / a + 1;     //jeśli reszta większa od zera zwiększ rozmiar kolumny
            else
                b = encipherLength / a;

            array2 = new char[b, a];
            z = 0;

            for (int j = 0; j < a; j++)
            {
                for (int i = 0; i < b; i++)
                {
                    if (key[j] < encipherLength - remainder2 && i != (b - 1))
                    {
                        array2[i, key[j] - 1] = encipherText[z];
                        z++;
                    }
                    else
                    {
                        array2[i, key[j] - 1] = '\0';
                    }
                }
            }
            for (int i = 0; i < b; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    Console.Write(array[i, j]);
                }
            }
            Console.ReadKey();

        }
    }
}