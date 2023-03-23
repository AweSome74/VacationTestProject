using System.Text;

namespace Vacation;
class Program
{
    static void Main(string[] args)
    {
        var firstExecute = true;
        while (true)
        {
            if (firstExecute)
            {
                Execute();
                firstExecute = false;
            }
            else
            {
                var key = Console.ReadLine();
                if (key == "y")
                {
                    Console.Clear();
                    Execute();
                }
                else if (key == "n")
                {
                    return;
                }
            }
            Console.WriteLine("Try again? y/n");
        }
    }

    private static void Execute()
    {
        //Generate users vacations
        Console.WriteLine("Creating users vacations...");
        var startTime = DateTime.Now;
        var userVacation = VacationHelper.GetUserVacations();
        Console.WriteLine($"Done! Time Elapsed: {(DateTime.Now - startTime).TotalMilliseconds:N2} ms." + Environment.NewLine);

        //Generate organiztion vacations
        Console.WriteLine("Creating organization vacations...");
        startTime = DateTime.Now;
        var organizationVacation = VacationHelper.GetOrganizationVacations();
        Console.WriteLine($"Done! Time Elapsed: {(DateTime.Now - startTime).TotalMilliseconds:N2} ms." + Environment.NewLine);

        //intersections
        Console.WriteLine("Creating result.txt file...");
        startTime = DateTime.Now;

        var builder = new StringBuilder();
        var tabDelimeter = "\t\t\t";

        foreach (var vacation in organizationVacation)
        {
            builder.Append("ID" + tabDelimeter + vacation.userId);
            builder.Append(tabDelimeter + $"{vacation.startDate:dd.MM.yyyy} - {vacation.endDate:dd.MM.yyyy}");
            foreach (var intersection in userVacation.Where(x => x.Intersects(vacation)))
            {
                builder.Append(tabDelimeter + $"пересекается с {intersection.startDate:dd.MM.yyyy} - {intersection.endDate:dd.MM.yyyy}");
            }
            builder.Append(Environment.NewLine);
        }

        var fileName = "result.txt";
        File.WriteAllText(fileName, builder.ToString());
        Console.WriteLine($"Done in file {Path.GetFullPath(fileName)}! Time Elapsed: {(DateTime.Now - startTime).TotalMilliseconds:N2} ms." + Environment.NewLine);

        //alternative intersections
        Console.WriteLine("Creating resultAlt.txt file...");
        startTime = DateTime.Now;

        builder = new StringBuilder();
        tabDelimeter = "\t\t\t";

        foreach (var vacation in organizationVacation)
        {
            builder.Append("ID" + tabDelimeter + vacation.userId);
            builder.Append(tabDelimeter + $"{vacation.startDate:dd.MM.yyyy} - {vacation.endDate:dd.MM.yyyy}");
            foreach (var intersection in userVacation.Where(x => x.IntersectsAlt(vacation)))
            {
                builder.Append(tabDelimeter + $"пересекается с {intersection.startDate:dd.MM.yyyy} - {intersection.endDate:dd.MM.yyyy}");
            }
            builder.Append(Environment.NewLine);
        }

        fileName = "resultAlt.txt";
        File.WriteAllText(fileName, builder.ToString());
        Console.WriteLine($"Done in file {Path.GetFullPath(fileName)}! Time Elapsed: {(DateTime.Now - startTime).TotalMilliseconds:N2} ms." + Environment.NewLine);
    }
}