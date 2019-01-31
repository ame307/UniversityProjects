using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Cryptography_ImgCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "1.png";

            Bitmap keyImg = new Bitmap(path);
            Encrypt(keyImg);

            Bitmap encodedImg = new Bitmap("encoded.png");
            keyImg = new Bitmap(path);

            Decrypt(encodedImg, keyImg);

            Console.ReadKey();


        }

        public static void Encrypt(Bitmap keyImg)
        {

            Console.Write("Enter the text you want to encrypt: ");
            string code = Console.ReadLine();
            byte[] asciiBytes = Encoding.ASCII.GetBytes(code);

            Color originalPixel;
            Random rnd = new Random();
            int line = keyImg.Height / asciiBytes.Length;
            int x;
            int y;

            for (int i = 0; i < asciiBytes.Length; i++)
            {
                x = rnd.Next(i * line, (i + 1) * line);
                y = rnd.Next(0, keyImg.Height);
                originalPixel = keyImg.GetPixel(x, y);

                if (originalPixel.R + asciiBytes[i] <= 255)
                {
                    keyImg.SetPixel(x, y, Color.FromArgb(originalPixel.R + asciiBytes[i], originalPixel.G, originalPixel.B));
                }
                else
                {
                    keyImg.SetPixel(x, y, Color.FromArgb(originalPixel.R - asciiBytes[i], originalPixel.G, originalPixel.B));
                }

            }

            keyImg.Save("encoded.png", System.Drawing.Imaging.ImageFormat.Png);

        }

        public static void Decrypt(Bitmap encodedImg, Bitmap keyImg)
        {
            List<int> asciiBytes = new List<int>();
            for (int x = 0; x < keyImg.Width; x++)
            {
                for (int y = 0; y < keyImg.Height; y++)
                {
                    asciiBytes.Add(encodedImg.GetPixel(x, y).R - keyImg.GetPixel(x, y).R);
                }
            }

            Console.Write("\nThe decrypted text: ");

            for (int i = 0; i < asciiBytes.Count; i++)
            {
                if (asciiBytes[i] != 0)
                {
                    Console.Write((char)(Math.Abs(asciiBytes[i])));
                }

            }
        }
    }
}
