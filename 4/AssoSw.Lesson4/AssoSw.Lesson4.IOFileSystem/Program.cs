using System;
using System.IO;
using System.Linq;
using System.Text;

namespace AssoSw.Lesson4.IOFileSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /***** Accesso ai File *****/

            // La classe Path
            string dirname = @"C:\temp";
            string filename = "file.txt";
            string fullpath = Path.Combine(dirname, filename); //C:\\temp\\file.txt"
            string xml = Path.ChangeExtension(filename, "xml");// file.xml
            string dir = Path.GetDirectoryName(fullpath); // c:\temp
            string ext = Path.GetExtension(fullpath); // .txt
            string file = Path.GetFileName(fullpath); // file.txt
            string filewithoutext = Path.GetFileNameWithoutExtension(fullpath); // file

            string beforeChangeDirectortyPath = Path.GetFullPath(filename);
            Directory.SetCurrentDirectory("c:\\windows"); // imposta la directory di lavoro corrente
            string afterChangeDirectoryPath = Path.GetFullPath(filename); // c:\windows\file.txt

            string root = Path.GetPathRoot(fullpath); // C:
            bool hasExt = Path.HasExtension("file.txt"); // true

            string randomFile = Path.GetRandomFileName(); // v3ybhjqf.0xd
            string tempFile = Path.GetTempFileName(); // C:\Users\UserName\AppData\Local\Temp\tmp210E.tmp
            string tempPath = Path.GetTempPath(); // C:\Users\UserName\AppData\Local\Temp

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // File e Directory
            string rootDirectory = @"C:\temp";
            string subDirectory1 = @"C:\temp\subdir1";
            string subDirectory2 = @"C:\temp\subdir2";
            string subDirectory3 = @"C:\temp\subdir3";
            // If directory does not exist, create it.
            if (!Directory.Exists(rootDirectory))
                Directory.CreateDirectory(rootDirectory);
            // Create sub directory 2
            if (!Directory.Exists(subDirectory2))
                Directory.CreateDirectory(subDirectory2);
            // Create sub directory 3
            if (!Directory.Exists(subDirectory3))
                Directory.CreateDirectory(subDirectory3);

            // Elimina subdir3
            if (Directory.Exists(subDirectory3))
                Directory.Delete(subDirectory3);

            string filePathToWrite = Path.Combine(subDirectory1, "fileditest.txt");
            if (!File.Exists(filePathToWrite))
                Console.WriteLine($"Il file {filePathToWrite} non esiste!");

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("riga 1");
            builder.AppendLine("riga 2");
            builder.AppendLine("riga 3");
            File.WriteAllText(filePathToWrite, builder.ToString());

            if (File.Exists(filePathToWrite))
                Console.WriteLine($"Il file {filePathToWrite} ora esiste!");

            // Ricerca
            var items = new DirectoryInfo(@"C:\sources").EnumerateFiles("*", SearchOption.AllDirectories);
            /*
             * Query per stampare nome e dimensione dei file in C:\temp > 1 MB (dimensione in byte ricavata 
             * shiftando a sinistra di 20 posizioni il valore 1) e con estensione diversa da 'txt'
             */
            var query = from f in items
                        where f.Length > (1 << 20) && f.Extension != "txt"
                        select new { f.FullName, f.Length };
            query.ToList().ForEach(Console.WriteLine);

            // La classe DriveInfo
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo driveInfo in drives)
            {
                Console.WriteLine($"Drive {driveInfo.Name}");
                Console.WriteLine($"File type: {driveInfo.DriveType}");
                if (driveInfo.IsReady)
                {
                    Console.WriteLine($"Volume label: {driveInfo.VolumeLabel}");
                    Console.WriteLine($"File system: {driveInfo.DriveFormat}");
                    Console.WriteLine("Spazio disponibile: {0,10} KBytes", (driveInfo.AvailableFreeSpace / 1024));
                    Console.WriteLine("Spazio totale: {0,10} KBytes", driveInfo.TotalFreeSpace / 1024);
                    Console.WriteLine("Total size of drive: {0,10} KBytes", driveInfo.TotalSize / 1024);
                }
            }

            // La classe FileSystemWatcher
            FileSystemWatcher watcher = new FileSystemWatcher(subDirectory1);
            watcher.EnableRaisingEvents = true;
            watcher.Created += Watcher_Created;
            watcher.Changed += Watcher_Created;
            watcher.Renamed += Watcher_Created;
            Console.WriteLine("Digita un carattere per uscire...");
            Console.ReadKey();
        }

        private static void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"E' stato manipolato il file {e.Name}");
        }
    }
}