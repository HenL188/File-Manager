using FileManager;

Console.WriteLine("Type help for list of commands: ");

switch (Console.ReadLine())
{
    case "help":
        Console.WriteLine("find - find a file");
        Console.WriteLine("find -d - find a directory");
        Console.WriteLine("ls - list directory");
        Console.WriteLine("pwd - see what directory you are in");
        Console.WriteLine("cat - see the contents of file");
        Console.WriteLine("mv - move a file");
        Console.WriteLine("mv -d - move a directory");
        Console.WriteLine("touch - create file");
        Console.WriteLine("rm - delete file");
        Console.WriteLine("rmdir - delete directory");
        Console.WriteLine("mkdir - create directory");
        break;
    case "find":
        Methods.FindFile();
        break;
    case "find -d":
        Methods.FindDirectory();
        break;
    case "ls":
        Methods.List();
        break;
    case "pwd":
        Methods.WorkingDirectory();
        break;
    case "cat":
        Methods.Read();
        break;
    case "mv":
        Methods.FileMove();
        break;
    case "mv -d":
        Methods.DirectoryMove();
        break;
    case "touch":
        Methods.FileCreate();
        break;
    case "rm":
        Methods.FileDelete();
        break;
    case "rmdir":
        Methods.DirectoryDelete();
        break;
    case "mkdir":
        Methods.DirectoryCreate();
        break;
    default:
        Console.WriteLine("That is not a command");
        Methods.Loop();
        break;
}






