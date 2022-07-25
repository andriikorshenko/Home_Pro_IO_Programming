using Task_003; 

FileStreamManager streamManager = new FileStreamManager();

var path = streamManager.SearchTheFile(@"C:\Games\", "test*");

streamManager.Write(path);
streamManager.Read(path);
streamManager.Compress(path);