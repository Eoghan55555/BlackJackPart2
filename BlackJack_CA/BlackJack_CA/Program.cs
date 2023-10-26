namespace BlackJack_CA
{
    internal class Program
    {
        static List<string> CardSuits = new List<string>() { "Diamonds", "Hearts", "Clubs", "Spades" }; //List of Suits
        static List<string> CardValues = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" }; //List of Cards Types
        static List<string> Deck = new List<string>(); //List of the actual Deck
        static void Main(string[] args)
        {
            Card Player1 = new Card();
            
            DeckReshuffle();
            string card = GetCard();
            GetCardValue(card);
        }
        static void DeckReshuffle() //Adds two of the Arrays to make the Deck so it can 'reshuffle' everytime it is called
        {
            foreach(string cardsuit in CardSuits)
            {
                foreach(string cardvalue in CardValues)
                {
                    string card = cardvalue + " of " + cardsuit; //Saves time to add two arrays than to make one big list from scratch

                    Deck.Add(card); //Variable now added to the Main List
                }
            }


        }
        static string GetCard()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, Deck.Count); //Takes a random number from the list
            
            string randomValue = Deck[randomIndex]; //Turns the number into a card
            Deck.Remove(randomValue); //Removes the card out of the deck

            Console.WriteLine($"{randomValue}\n"); //To show the card that has been taken out
            foreach (string card in Deck)
            {
                Console.WriteLine(card); //Shows the deck without the taken card (only used for testing)
            }
            return randomValue; //Returns the card to be used elsewhere
        }
        static public int GetCardValue(string card)
        {
            card.Split("of"); //card is now able to show the first character of the string
            
            char value = card[0]; //Single Character that is able to be converted later

            //Console.WriteLine(value); //Testing to see if it takes the right value

            IDictionary<char, int> CardValueConverter = new Dictionary<char, int> //Converter for char so it can be an int
            {
                ['2'] = 2,
                ['3'] = 3,
                ['4'] = 4,
                ['5'] = 5,
                ['6'] = 6,
                ['7'] = 7,
                ['8'] = 8,
                ['9'] = 9,
                ['1'] = 10, //Since there is no 1 card in a deck, 10 can be called as '1' when using char
                ['J'] = 10, //Jack
                ['Q'] = 10, //Queen
                ['K'] = 10, //King
                ['A'] = 11, //Ace
            };

            int cardvalue = CardValueConverter[value]; //Turns the char into an int from the dictionary
            //cardvalue += 1; //To test for int Property
            Console.WriteLine(cardvalue); //Test for new value to see if it is an int

            return cardvalue;
        }

    }
}