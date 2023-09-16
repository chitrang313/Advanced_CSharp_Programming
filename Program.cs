class Program {
    delegate void LogDel(string information);

    static void Main(string[] args) {
        Log log = new Log();

        LogDel logTextToScreenDel = new LogDel(log.LogTextToScreen);
        LogDel logTextToFileDel = new LogDel(log.LogTextToFile);

        LogDel multiLogDel = logTextToFileDel + logTextToScreenDel;

        Console.WriteLine("Enter your message:");

        string message = Console.ReadLine();

        multiLogDel(message); 
    }    
}

class Log {
    public void LogTextToScreen(string message) {
        Console.WriteLine($"{DateTime.Now}: {message}");
    }

    public void LogTextToFile(string message) {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"LogFile.txt");

        using (StreamWriter sw = new StreamWriter(Path.Combine(filePath),true)) {
            sw.WriteLine($"{DateTime.Now}: {message}");
        }
    }
}
