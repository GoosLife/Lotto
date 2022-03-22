int correctNumbers = 0;

int[] winningTicket = new int[7];

// Generate winning ticket
for (int i = 0; i < winningTicket.Length; i++)
{
    do
    {
        Random rng = new Random();
        int numberToAdd = rng.Next(1, 21);

        if (!IsDuplicate(winningTicket, numberToAdd)) // Ensure duplicate numbers won't get drawn
        {
            winningTicket[i] = numberToAdd;
        }
    } while (winningTicket[i] == 0);
}

// Generate user ticket
string input;
int[] userTicket = new int[7];

Console.WriteLine("Indtast dine 7 tal mellem 1 og 20. Tryk Enter efter hvert tal: ");

// Get user numbers
for (int i = 0; i < userTicket.Length; i++)
{
    do
    {
        bool isDuplicate = false;

        Console.WriteLine("Du har valgt {0} tal mellem 1 og 20.", i);
        input = Console.ReadLine();

        int numberToAdd;
        int.TryParse(input, out numberToAdd);

        if (!IsDuplicate(userTicket, numberToAdd) && // Check users number isn't a duplicate, and is between 1 and 20.
            numberToAdd > 0 && numberToAdd <= 20)
        {
            userTicket[i] = numberToAdd; // Add valid number.
        }

    } while (userTicket[i] == 0);
}

// Compare tickets
for (int i = 0; i < userTicket.Length; i++)
{
    for (int j = 0; j < winningTicket.Length; j++)
    {
        if (userTicket[i] == winningTicket[j])
            correctNumbers++;
    }
}

Console.Clear();

Console.WriteLine("Vindetallene er: \n");
for (int i = 0; i < winningTicket.Length; i++)
{
    Console.Write(winningTicket[i] + " ");
}

Console.WriteLine("Dine tal var: \n");
for (int i = 0; i < userTicket.Length; i++)
{
    Console.Write(userTicket[i] + " ");
}

Console.WriteLine(); // add line break between user numbers & outputted winnings

// output winnings
switch (correctNumbers)
{
    case 0:
    case 1:
        Console.WriteLine("Du vandt ingenting.");
        break;
    case 2:
        Console.WriteLine("Du har vundet 50 kr.");
        break;
    case 3:
        Console.WriteLine("Du har vundet 100 kr.");
        break;
    case 4:
        Console.WriteLine("Du har vundet 250 kr.");
        break;
    case 5:
        Console.WriteLine("Du har vundet 1000 kr.");
        break;
    case 6:
        Console.WriteLine("Du har vundet 10.000 kr.");
        break;
    case 7:
        Console.WriteLine("Du har sikkert snydt, ryk direkte i fængsel.");
        break;

}

bool IsDuplicate(int[] arr, int numberToAdd)
{
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] == numberToAdd)
            return true;
    }
    return false;
}