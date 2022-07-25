using Task_006;

DirectoryManager manager = new DirectoryManager();

manager.DirectoryCreator();

Console.WriteLine("\nPress any key to delete them all...");
Console.ReadKey();

manager.DirectoryPredator();