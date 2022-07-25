using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_003
{
    internal class FileStreamManager
    {
        private readonly string _text = "some text to show on the screen";

        public string SearchTheFile(string directory, string file)
        {
            string[] theFile = Directory.GetFiles(directory, file);

            if (theFile.Length >= 1)
                return theFile[0];
            else throw new Exception("The file has not been found!");
        }

        public async void Write(string path)
        {
            try
            {
                using (FileStream fStream =
                new FileStream(path, FileMode.Open))
                {
                    byte[] buffer = Encoding.Default.GetBytes(_text);
                    await fStream.WriteAsync(buffer, 0, buffer.Length);

                    Console.WriteLine("Текст записан в файл!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

        public async void Read(string path)
        {
            try
            {
                using (FileStream fStream = File.OpenRead(path))
                {
                    byte[] buffer = new byte[fStream.Length];
                    await fStream.ReadAsync(buffer, 0, buffer.Length);
                    string textFromFile = Encoding.Default.GetString(buffer);

                    Console.WriteLine($"Текст из файла: {textFromFile}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void Compress(string path)
        {
            FileStream source = File.OpenRead(path);
            FileStream destination = File.Create(@"C:\Games\test.zip");

            GZipStream compressor = new GZipStream(destination, CompressionMode.Compress);

            int theByte = source.ReadByte();
            while (theByte != -1)
            {
                compressor.WriteByte((byte)theByte);
                theByte = source.ReadByte();
            }

            compressor.Close();

            Console.WriteLine($"Сжатие файла завершено.");
        }
    }
}
