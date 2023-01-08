// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.ObjectModel;


// 1. Create a new Visual C# Console App using .NET Framework
// project and name it "MyFirstConsoleApplication."

// 2. Create two variables to store your values:
// Your name
// Your location (state or country)

internal class MyFirstConsoleApplication
{
    private static void Main(string[] args)
    {
        var name = "Julie Antezana";
        var location = "Texas";

        // 3. Output two WriteLine statements that display those
        // two variables with proper labels (My name is ... ,
        // I am from ...) using String Interpolation.

        Console.WriteLine($"\nMy name is {name}.");
        Console.WriteLine($"\nI am from {location}.");

        // 4. Output the current date, but not the current time. 
        //   (Ex: 04 / 06 / 1830)

        // Display using current (en-us) culture's short date format
        Console.WriteLine(DateTime.Today.ToString("d"));

        // 5. Output the number of days until Christmas this year and, 
        // of course, apply an appropriate label to that output.

        DateTime today = DateTime.Today;
        DateTime next = new DateTime(2023, 12, 25);

        if (next < today)
            next = next.AddYears(1);

        int numDays = (next - today).Days;

        Console.WriteLine($"There are {numDays} days until Christmas this year.");

        // 6. Add the program example from section 2.1 in the
        // C# Programming Yellow Book by Rob Miles.

        double width, height, woodLength, glassArea;
        string widthString, heightString;
        // -- Provide appropriate text labels when requesting
        // dimensional input.
        Console.WriteLine("\nWidth: Please enter the width of the window opening in meters");
        widthString = Console.ReadLine();
        width = double.Parse(widthString);
        Console.WriteLine("\nHeight: Please enter the height of the window opening in meters");
        heightString = Console.ReadLine();
        height = double.Parse(heightString);
        woodLength = 2 * (width + height) * 3.25;
        glassArea = 2 * (width * height);
        Console.WriteLine("The length of the wood is " +
        woodLength + " feet");
        Console.WriteLine("The area of the glass is " +
        glassArea + " square metres");
        Console.ReadKey();
    }
}
// -- Cause the program to pause in the console so that the
// application does not automatically terminate when launched
// from the Visual Studio run debugger tool. 
// Hint: Consider Console.ReadKey()
// Console.ReadKey();

// 7. Add these requirements to the code:
// -- Provide appropriate text labels when requesting
// dimensional input.
// -- Cause the program to pause in the console so that the
// application does not automatically terminate when launched
// from the Visual Studio run debugger tool. 
// Hint: Consider Console.ReadKey()
// You do NOT need to add any sort of input validation.