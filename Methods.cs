
using System.IO;
using System.Text;

namespace FileManager
{
    public class Methods
    {

       
        public static void Execute()
        {
            switch (Console.ReadLine())
            {
                case "find":
                    FindFile();
                    break;
                case "find -d":
                    FindDirectory();
                    break;
                case "ls":
                    List();
                    break;
                case "pwd":
                    WorkingDirectory();
                    break;
                case "cat":
                    Read();
                    break;
                case "mv":
                    FileMove();
                    break;
                case "mv -d":
                    DirectoryMove();
                    break;
                case "touch":
                    FileCreate();
                    break;
                case "rm":
                    FileDelete();
                    break;
                case "rmdir":
                    DirectoryDelete();
                    break;
                case "mkdir":
                    DirectoryCreate();
                    break;
                default:
                    Console.WriteLine("That is not a command");
                    Loop();
                    break;
            }
        }
        public static void Loop()
        {
            Console.WriteLine("Would you like to do anything else?");
            Console.WriteLine("Y/N");
            string done = Console.ReadLine() ?? "";
            if (done.ToUpper() == "Y")
            {
                Execute();
            }
            else { Environment.Exit(0); }
        }
       
        public static void FindFile()
        {    
            Console.WriteLine("Enter directory:");
            string directory = Console.ReadLine() ?? "";
            string directoryPath = @$"c:\path\to\{directory}";
            if (Directory.Exists(directoryPath))
            {
                Console.WriteLine("Enter File name:");
                string file = Console.ReadLine()?? "";

                string filePath = @$"c:\path\to\{directory}\" + file;
                Console.WriteLine(File.Exists(filePath) ? filePath : "File does not exist.");
            }

            else
            {
                Console.WriteLine("Directory not found");
            }
            Loop();
        }
        public static void FindDirectory()
        {
            Console.WriteLine("Enter directory name:");
            var findDirectory = Console.ReadLine() ?? "";
            var directoryPath = @$"c:\path\to\" + findDirectory;
            if(Directory.Exists(directoryPath))
            {
                Console.WriteLine(directoryPath);
            }
            else
            {
                Console.WriteLine("Directory not found");
            }
            Loop();
        }
        public static void List()
        {
            Console.WriteLine("Enter directory:");
            var path = Console.ReadLine()?? "";
            var directoryPath = @$"c:\path\to\" + path;
            if (Directory.Exists(directoryPath))
            {
                string[] directoryEntries = Directory.GetDirectories(@$"c:\path\to\" + path);
                string[] fileEntries = Directory.GetFiles(@$"c:\path\to\" + path);
                foreach (string dir in directoryEntries)
                {
                    Console.WriteLine(dir);
                }
                foreach (var file in fileEntries)
                {
                    Console.WriteLine(file);
                }
            }
            else
            {
                Console.WriteLine("Directory not found");
            }
            
            Loop();
        }
        public static void WorkingDirectory()
        {
            Console.WriteLine("Enter directory:");
            var directory = Console.ReadLine() ?? "";
            var path = @$"c:\path\to\" + directory;
            Console.WriteLine(Directory.GetParent(path));
            Loop();
        }
        public static void Read()
        {
            Console.WriteLine("Enter directory:");
            string directory = Console.ReadLine() ?? "";
            string directoryPath = @$"c:\path\to\{directory}";
            if (Directory.Exists(directoryPath))
            {
                Console.WriteLine("Enter File name:");
                string file = Console.ReadLine() ?? "";
                string filePath = @$"c:\path\to\{directory}\" + file;
                if (File.Exists(filePath)) 
                {
                    //This is code from https://learn.microsoft.com/en-us/dotnet/api/system.io.file.openread?view=net-8.0
                    using (FileStream fs = File.OpenRead(filePath))
                    {
                        byte[] b = new byte[1024];
                        UTF8Encoding temp = new UTF8Encoding(true);

                        while (fs.Read(b, 0, b.Length) > 0)
                        {
                            Console.WriteLine(temp.GetString(b));
                        }
                    }
                    
                }
                else
                {
                    Console.WriteLine("File not found");
                }
                
            }

            else
            {
                Console.WriteLine("Directory not found");
            }
            Loop();
        }
        public static void FileMove()
        {
            Console.WriteLine("Enter directory:");
            string directory = Console.ReadLine() ?? "";
            string directoryPath = @$"c:\path\to\{directory}";
            if (Directory.Exists(directoryPath))
            {
                Console.WriteLine("Enter File name:");
                string file = Console.ReadLine() ?? "";
                string filePath = @$"c:\path\to\{directory}\" + file;
                if (File.Exists(filePath)) 
                {
                    Console.WriteLine("Enter directory moving to:");
                    string fileMove = Console.ReadLine() ?? "";
                    string filePath2 = @$"c:\path\to\{directory}\" + file;
                    string fileMoveTo = @$"c:\path\to\{fileMove}\" + file;
                    File.Move(filePath2, fileMoveTo);
                    Console.WriteLine("{0} was moved to {1}.", file, fileMoveTo);
                }
                else
                {
                    Console.WriteLine("File not found");
                    Loop();
                }
                
                
            }

            else
            {
                Console.WriteLine("Directory not found");
            }
            Loop();
        }
        public static void FileCreate()
        {
            Console.WriteLine("Directory you want to create file in:");
            var directory = Console.ReadLine() ?? "";
            var directoryPath = @$"c:\path\to\{directory}";
            if (Directory.Exists(directoryPath))
            {
                Console.WriteLine("File you want to create:");
                var file = Console.ReadLine();
                var fileCreate = @$"c:\path\to\{directory}\" + file;
                File.Create(fileCreate);
            }
            else
            {
                Console.WriteLine("Directroy not found");
                Loop();
            }
            Loop();
        }
        public static void DirectoryCreate()
        {
            Console.WriteLine("Directory you want to create directroy in:");
            var directory = Console.ReadLine() ?? "";
            var directoryPath = @$"c:\path\to\{directory}";
            if (Directory.Exists(directoryPath))
            {
                Console.WriteLine("Directory you want to create:");
                var directory2 = Console.ReadLine();
                var directoryCreate = @$"c:\path\to\{directory}\" + directory2;
                Directory.CreateDirectory(directoryCreate);
            }
            else
            {
                Console.WriteLine("Directroy not found");
                Loop();
            }
            Loop();
        }
        public static void FileDelete()
        {
            Console.WriteLine("Directory you want to delete file in:");
            var directory = Console.ReadLine() ?? "";
            var directoryPath = @$"c:\path\to\{directory}";
            if (Directory.Exists(directoryPath))
            {
                Console.WriteLine("File you want to delete:");
                var file = Console.ReadLine() ?? "";
                var filePath = Path.Combine(directoryPath, file);
                if (File.Exists(filePath)) 
                {
                    var fileDelete = @$"c:\path\to\{directory}\" + file;
                    File.Delete(fileDelete);
                }
                else
                {
                    Console.WriteLine("File not found");
                    Loop();
                }
            }
            else
            {
                Console.WriteLine("Directroy not found");
                Loop();
            }
            Loop();
        }
        public static void DirectoryDelete()
        {
            Console.WriteLine("Directory you want to delete:");
            var directory = Console.ReadLine() ?? "";
            var directoryPath = @$"c:\path\to\{directory}";
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath, true);
            }
            else
            {
                Console.WriteLine("Directroy not found");
                Loop();
            }
            Loop();
        }
        //This is code from https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories
        public static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            var dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            DirectoryInfo[] dirs = dir.GetDirectories();
            Directory.CreateDirectory(destinationDir);

            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
        public static void DirectoryMove()
        {
            Console.WriteLine("Directory you want to move:");
            var directoryMove = Console.ReadLine() ?? "";
            Console.WriteLine("Directory you want to move into:");
            var directory = Console.ReadLine() ?? "";
            var directory2 = @$"c:\path\to\{directory}\" + directoryMove;
            if (Directory.Exists(directory2))
            {
                Directory.CreateDirectory(directory2);
                Console.WriteLine("Directory path you want to move:");
                var directoryMove2 = Console.ReadLine() ?? "";
                var directoryMove3 = @$"c:\path\to\{directoryMove2}";
                if (Directory.Exists(directoryMove3))
                {
                    CopyDirectory(directoryMove3, directory2, true);
                    Directory.Delete(directoryMove3, true);
                }
                else
                {
                    Console.WriteLine("Directory not found");
                    Loop();
                }
            }
            else
            {
                Console.WriteLine("Directory not found");
                Loop();
            }
           
            Loop();


        }
    }
}
