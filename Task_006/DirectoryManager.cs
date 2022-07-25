using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_006
{
    internal class DirectoryManager
    {
        private readonly string _directory = @"C:\Games\";
        private string _subName = "Folder_";
        private int _count = 100;

        public void DirectoryCreator()
        {
            DirectoryInfo? directoryInfo
            = new DirectoryInfo(_directory);

            if (directoryInfo.Exists)
            {
                for (int i = 0; i < _count; i++)
                {
                    string subNames = _subName + i;

                    directoryInfo.CreateSubdirectory(subNames);
                }
            }
            else throw new Exception("Не создана основная директория!");

            Console.WriteLine($"Subdirectories has been created! " +
                $"In count of {_count} items in {_directory}");
        }

        public void DirectoryPredator()
        {
            string[] dirs = Directory.GetDirectories(_directory, "Folder_*");

            foreach (var item in dirs)
            {
                Directory.Delete(item, true);
            }

            Console.WriteLine("\nAll subderictories has been delited!");
        }
    }
}
