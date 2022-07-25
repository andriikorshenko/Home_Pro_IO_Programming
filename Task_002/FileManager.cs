using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_002
{
    internal class FileManager
    {
        private readonly string _path = @"C:\Games\test.txt";
        private readonly string _text = "the text from the new file";

        public async void Write()
        {
            using (StreamWriter writer = new StreamWriter(_path, false))
            {
                await writer.WriteLineAsync(_text);
            }
        }

        public async void Read()
        {
            using (StreamReader reader = new StreamReader(_path))
            {
                string text = await reader.ReadToEndAsync();
                Console.Write(text);
            }
        }
    }
}
