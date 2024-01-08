using googleplayCrawler;
using System.Text.Json;
while (true)
{
    Console.Write("link:1 - appname:2 -> ");
    bool link = Console.ReadLine() == "1";
    Console.WriteLine("Enter link/app name: ");

    string name = Console.ReadLine() ?? "";
    //string name = "org.telegram.messenger";
    if (string.IsNullOrEmpty(name))
        return;

    GooglePlayApps googlePlayApps = new GooglePlayApps(name, link);

    var info = await googlePlayApps.GetAppInfo();

    var json = JsonSerializer.Serialize(info);

    Console.WriteLine(json);

    Console.WriteLine("---------------------------------------------");
    Console.Write("\n Start Again y/n: ");
    var again = Console.ReadLine()?.ToLower() == "y" ? true : false;

    if (!again)
        break;
}

