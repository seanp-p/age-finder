using System.Diagnostics.Metrics;
using System.Numerics;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("[Welcome to the Finding Your Age App]\n");

static void ClearCurrentConsoleLine()
{
    int currentLineCursor = Console.CursorTop;
    Console.SetCursorPosition(0, Console.CursorTop);
    Console.Write(new string(' ', Console.WindowWidth));
    Console.SetCursorPosition(0, currentLineCursor);
}

static void loadingImage()
{
    Random rnd = new Random();
    int timer = rnd.Next(1,32); // Change random loading times here
    string[] loadingDash = ["/", "--", "\\", "|"];
    int dashLength = loadingDash.Length; 
    Console.Clear();
    Console.WriteLine("[Welcome to the Finding Your Age App]\n");

    for (int i = 0; i < timer; i++) 
    {
        if (i >= dashLength)
        {
            i = i - dashLength;
            timer = timer - dashLength;
        }
        Console.WriteLine($" [{loadingDash[i]}]");
        Thread.Sleep(150);
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        ClearCurrentConsoleLine();
    }
}

static void inputError(string errorMessage)
{
    loadingImage();
    Console.WriteLine($"[{errorMessage}]");
}

while (true) {
    
    Console.Write("Please enter the [year] you were born: ");

    string inputYear = Console.ReadLine();
    inputYear = inputYear.Replace(" ", "");
    inputYear = inputYear.Replace("'", "");
    int yearLength = inputYear.Length;

    if (inputYear == "")
    {
        inputError("Please enter number values");
    }
    else if (!int.TryParse(inputYear, out int value))
    {
        inputError("Please enter only whole numbers");
    }
    else if (yearLength > 4 )
    {
        inputError("Please enter only (4) number values");
    }
    else if (yearLength == 1 || yearLength == 3 )
    {
        inputError("Please enter only (2) or (4) number values");
    }
    else
    {
        int userYear = 0;
        int curYear = DateTime.Now.Year;
        if (yearLength == 2)
        {
            string curStringYear = curYear.ToString();
            string curStringYearTwo = curStringYear.Remove(0, 2);
          
            if (int.Parse(curStringYearTwo) >= int.Parse(inputYear)) //born after 19(22)
            {
                Console.Clear();
                Console.WriteLine("[Welcome to the Finding Your Age App]\n");
                userYear = int.Parse(curStringYearTwo) - int.Parse(inputYear);
                Console.WriteLine($"You are {userYear} year(s) old.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("[Welcome to the Finding Your Age App]\n");
                userYear = int.Parse(curStringYear) - int.Parse("19" + inputYear);
                Console.WriteLine($"You are {userYear} years old.");

            }

        }
        else
        {
            Console.Clear();
            Console.WriteLine("[Welcome to the Finding Your Age App]\n");
            userYear = curYear - int.Parse(inputYear);
            Console.WriteLine($"You are {userYear} year(s) old.");
        }
        if (userYear >= 1000)
        {
            Console.WriteLine("Wow, you are ancient!");
        }
        else if (userYear > 99)
        {
            Console.WriteLine("Wow, pretty old!");
        }
        else if (userYear < 10)
        {
            Console.WriteLine("Wow, you are young!");
        }
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("[Welcome to the Finding Your Age App]\n");
        continue;

        


    }
}