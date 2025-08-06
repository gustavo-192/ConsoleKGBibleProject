namespace Repository.Json;

public static class MachineExplorer
{
    public static string GetFilePath(string nameRepository)
    {
        string file = "";

        if (OperatingSystem.IsMacOS())
            file = @"/" + nameRepository + "Data.json";
        else if (OperatingSystem.IsWindows())
            file = @"\" + nameRepository + "Data.json" ;

        // var x = Environment.SystemDirectory;
        // var x2 = Environment.CommandLine;

        string environment = Environment.CurrentDirectory;
        // var z = typeof(EndOfStreamException ).Assembly.FullName;  
        // string replaceProject = environment.Replace("/bin/Debug/net7.0", ""); /* TestProject */
        // string replaceProject = environment.Replace("/Api", "/Repository.Json");
        string replaceProject = environment.Replace(@"ConsoleKGBlibliProjectApp\bin\Debug\net8.0", "Repository.Json");
        // C:\Projects\ConsoleKGBibleProject\ConsoleKGBlibliProjectApp\bin\Debug\net8.0\PersonData.json
        //C:\\Projects\\ConsoleKGBibleProject\\ConsoleKGBlibliProjectApp\\bin\\Debug\\net8.0\\PersonData.json

        string fullPath = replaceProject + file;

        return fullPath;
    }
}
