//variables
string[] movieTitles = {"Jaws", "The Conjuring", "The Thing", "Alien", "Texas Chainsaw Massacre"};
string[][] movieShowtime = {};

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

    }

} while (menuSelection != "exit");

#region Methods



#endregion