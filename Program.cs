//movie data
using System.Net;
using Microsoft.Win32.SafeHandles;

string[] movieTitles = { "Jaws", "The Conjuring", "The Thing", "Alien", "Texas Chainsaw Massacre" };
string[][] movieShowtimes = {
    new string[] {"1) 12:00", "2) 16:30", "3) 21:00"},
    new string[] {"1) 13:00", "2) 18:00", "3) 23:00"},
    new string[] {"1) 14:00", "2) 16:00", "3) 20:30"},
    new string[] {"1) 12:30", "2) 15:30", "3) 21:00"},
    new string[] {"1) 13:00", "2) 16:30", "3) 21:00"}
};

//variables supporting data entry
string? readResult;
string menuSelection = "";
string chosenMovie = "";
string chosenShowtime = "";
string chosenSeat = "";
bool booked = false;

//initialise seats
string[,] seats = new string[5, 5];

for (int row = 0; row < 5; row++)
{
    for (int col = 0; col < 5; col++)
    {
        char rowLetter = (char)('A' + row);
        seats[row, col] = rowLetter.ToString() + (col + 1);
    }
}

//snack data
string[] snacks = { "🍿 Popcorn", "🥤 Coca-Cola", "🍫 M&Ms", "🌮 Nachos", "🌭 Hot Dog" };
decimal[] snackPrices = { 5.00m, 3.00m, 2.50m, 5.00m, 4.00m };
int[] snackQuantities = new int[snacks.Length];

do
{
    Console.Clear();

    Console.WriteLine("Welcome to Butter & Reel. Your main menu options are:");
    Console.WriteLine(" 1) View Movies and Showtimes");
    Console.WriteLine(" 2) Book a Seat");
    Console.WriteLine(" 3) Order Snacks");
    Console.WriteLine(" 4) View Current Booking Summary");
    Console.WriteLine(" 5) Apply Membership Discount");
    Console.WriteLine(" 6) Exit");
    Console.WriteLine();
    Console.WriteLine("Please enter a selection number (or type Exit to leave the application)");

    readResult = Console.ReadLine();
    if (readResult != null) menuSelection = readResult.ToLower();

    //process selected menu option
    switch (menuSelection)
    {
        case "1":
            ChooseMovie(movieTitles, movieShowtimes);
            break;

        case "2":
            DisplaySeats(seats);
            break;

        case "3":
            OrderSnacks(snacks, snackPrices, snackQuantities);
            break;
    }

} while (menuSelection != "exit");

#region Methods

void ShowMovies(string[] titles, string[][] showtimes)
{
    for (int i = 0; i < movieTitles.Length; i++)
    {
        Console.WriteLine($"🎬 {movieTitles[i]}");

        foreach (var time in movieShowtimes[i])
        {
            Console.WriteLine($"    ⏰ {time}");
        }
        Console.WriteLine();
    }
}

(string movie, string showtime) ChooseMovie(string[] titles, string[][] showtimes)
{
    ShowMovies(titles, showtimes);

    while (true)
    {
        //choose movie
        Console.Write("Choose movie number (0 to finish): ");
        readResult = Console.ReadLine();

        if (!int.TryParse(readResult, out int movieChoice))
        {
            Console.WriteLine("Please enter a valid number.");
            continue;
        }

        if (movieChoice == 0) break;

        if (movieChoice < 0 || movieChoice > titles.Length)
        {
            Console.WriteLine("That movie number doesn't exist. Try again.");
            continue;
        }

        int index = movieChoice - 1;
        chosenMovie = titles[index];

        //choose showtime
        Console.WriteLine($"You chose {chosenMovie}. Select a time (0 to finish): ");

        foreach (string time in showtimes[index])
        {
            Console.WriteLine(time);
        }

        readResult = Console.ReadLine();

        if (!int.TryParse(readResult, out int timeChoice))
        {
            Console.WriteLine("Please enter a valid number.");
        }

        if (timeChoice == 0) break;

        if (timeChoice < 0 || timeChoice > showtimes[index].Length)
        {
            
        }

        // if (int.TryParse(readResult, out int timeChoice))
        // {
        //     if (timeChoice > 0 && timeChoice <= showtimes[index].Length)
        //     {
        //         chosenShowtime = showtimes[index][timeChoice - 1];
        //         Console.WriteLine($"You picked {chosenMovie} at {chosenShowtime}");
        //         Console.WriteLine("Press the Enter key to continue"); //continue here - fix it
        //         readResult = Console.ReadLine();
        //     }
        //     else
        //     {
        //         Console.WriteLine("That showtime doesn't exist.");
        //     }
        // }
        // else
        // {
        //     Console.WriteLine("Please enter a valid time.");
        // }

    }

    return (chosenMovie, chosenShowtime);
}

void DisplaySeats(string[,] layout)
{
    for (int row = 0; row < layout.GetLength(0); row++)
    {
        for (int col = 0; col < layout.GetLength(1); col++)
        {
            Console.Write(layout[row, col] + "\t");
        }
        Console.WriteLine();
    }

    Console.WriteLine("Would you like to book a seat? (y/n)");
    readResult = Console.ReadLine();
    string bookSeat = "";

    if (readResult != null) bookSeat = readResult.ToLower();

    if (readResult == "y")
    {
        BookSeats();
    }
    else
    {
        Console.WriteLine("Press the Enter key to continue");
        readResult = Console.ReadLine();
    }
}

void BookSeats()
{
    Console.Write("Enter the seat you want (e.g. B3): ");
    readResult = Console.ReadLine();
    if (readResult != null) chosenSeat = readResult.ToUpper();

    for (int row = 0; row < 5; row++)
    {
        for (int col = 0; col < 5; col++)
        {
            if (seats[row, col] == chosenSeat)
            {
                seats[row, col] = "X";
                Console.WriteLine("Seat booked successfully!");
                booked = true;
            }
        }
    }

    if (!booked) Console.WriteLine("That seat is not available.");

    DisplaySeats(seats);
}

void DisplaySnackMenu(string[] names, decimal[] prices)
{
    Console.WriteLine("Available snacks:");
    for (int i = 0; i < names.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {names[i]} - ${prices[i]:F2}");
    }

    Console.WriteLine();
}

decimal OrderSnacks(string[] names, decimal[] prices, int[] quantities)
{
    DisplaySnackMenu(names, prices);

    while (true)
    {
        // 1. Choose snack number
        Console.Write("Enter snack number to add (0 to finish): ");
        readResult = Console.ReadLine();

        if (!int.TryParse(readResult, out int choice))
        {
            Console.WriteLine("Please enter a valid number.");
            continue;
        }

        // done ordering
        if (choice == 0) break;

        // snack number should exist
        if (choice < 0 || choice > names.Length)
        {
            Console.WriteLine("That snack number doesn't exist. Try again.");
            continue;
        }

        // 2. order quantity
        int index = choice - 1; //convert to 0-based index

        Console.Write($"How many {names[index]} would you like? ");
        readResult = Console.ReadLine();
        string quantityInput = "";

        if (readResult != null) quantityInput = readResult;

        if (!int.TryParse(quantityInput, out int quantity) || quantity <= 0)
        {
            Console.WriteLine("Please enter a positive integer quantity.");
            continue;
        }

        quantities[index] += quantity;
        decimal lineTotal = prices[index] * quantity;
        Console.WriteLine($"{quantity} x {names[index]} added to cart - line total: ${lineTotal:F2}\n");
    }

    decimal subtotal = 0m;
    bool any = false;
    Console.WriteLine("\n--- Snack Summary ---");
    for (int i = 0; i < names.Length; i++)
    {
        if (quantities[i] > 0)
        {
            any = true;
            decimal line = quantities[i] * prices[i];
            Console.WriteLine($"{quantities[i]} x {names[i]} @ ${prices[i]:F2} = ${line:F2}");
            subtotal += line;
        }
    }

    if (!any) Console.WriteLine("No snacks selected.");

    Console.WriteLine($"Snacks subtotal: ${subtotal:F2}");
    Console.WriteLine("---------------------\n");
    Console.ReadKey();
    return subtotal;
}

#endregion