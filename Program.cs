//variables
string[] movieTitles = { "Jaws", "The Conjuring", "The Thing", "Alien", "Texas Chainsaw Massacre" };
string[][] movieShowtimes = {
    new string[] {"12:00", "16:30", "21:00"},
    new string[] {"13:00", "18:00", "23:00"},
    new string[] {"14:00", "16:00", "20:30"},
    new string[] {"12:30", "15:30", "21:00"},
    new string[] {"13:00", "16:30", "21:00"}
};

//variables supporting data entry
string? readResult;
string menuSelection = "";
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
            ShowMovies();
            break;

        case "2":
            DisplaySeats(seats);
            break;

        case "3":
            DisplaySnackMenu(snacks, snackPrices);
            break;
    }

} while (menuSelection != "exit");

#region Methods

void ShowMovies()
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

    Console.WriteLine("Press the Enter key to continue");
    readResult = Console.ReadLine();
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

    Console.WriteLine("Would you like to buy snacks? (y/n)");
    readResult = Console.ReadLine();
}

#endregion