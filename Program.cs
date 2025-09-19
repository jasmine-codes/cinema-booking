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

#endregion