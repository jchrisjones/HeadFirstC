using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter_08_9_1_GoFish
{
    class Player
    {
        //========== Fields ===========//

        private string _name;        
        private Random _random;
        private Deck _cards;
        private TextBox _textBoxOnForm;

        //======== Constructors =======//

        public Player(String name, Random random, TextBox textBoxOnForm)
        {
            // The constructor for the Player class initializes four private fields, and then
            // adds a line to the TextBox control on the form that says, "Joe has just
            // joined the game"—but use the name in the private field, and don't forget to
            // add a line break at the end of every line you add to the TextBox.
            _name = name;
            _random = random;
            _textBoxOnForm = textBoxOnForm;
            _cards = new Deck(new Card[] { });
            _textBoxOnForm.Text += name + " has just joined the game\r\n";

        }

        //======== Interfaces =========//

        //======== Properties =========//

        public string Name { get { return _name; } }
        public int CardCount { get { return _cards.Count; } }       

        //========== Methods ==========//

        public IEnumerable<Values> PullOutBooks()
        {
            List<Values> books = new List<Values>();
            for (int i = 1; i <= 13; i++)
            {
                Values value = (Values)i;
                int howMany = 0;
                for (int card = 0; card < _cards.Count; card++)
                    if (_cards.Peek(card).Value == value)
                        howMany++;
                if (howMany == 4)
                {
                    books.Add(value);
                    _cards.PullOutValues(value);
                }
            }
            return books;
        }

        public Values GetRandomValue()
        {
            // This method gets a random value—but it has to be a value that's in the deck!
            Card randomCard = _cards.Peek(_random.Next(_cards.Count));
            return randomCard.Value;
        }

        public Deck DoYouHaveAny(Values value)
        {
            // This is where an opponent asks if I have any cards of a certain value
            // Use Deck.PullOutValues() to pull out the values. Add a line to the TextBox
            // that says, "Joe has 3 sixes"—use the new Card.Plural() static method
            Deck cardsIHave = _cards.PullOutValues(value);
            _textBoxOnForm.Text += Name + " has " + cardsIHave.Count + " "
                + Card.Plural(value) + Environment.NewLine;
            return cardsIHave;
        }

        public void AskForACard(List<Player> players, int myIndex, Deck stock)
        {
            // Here's an overloaded version of AskForACard()—choose a random value
            // from the deck using GetRandomValue() and ask for it using AskForACard()
            Values RandomValue = GetRandomValue();
            AskForACard(players, myIndex, stock, RandomValue);
        }

        public void AskForACard(List<Player> players, int myIndex, Deck stock, Values value)
        {
            // Ask the other players for a value. First add a line to the TextBox: "Joe asks
            // if anyone has a Queen". Then go through the list of players that was passed in
            // as a parameter and ask each player if he has any of the value (using his
            // DoYouHaveAny() method). He'll pass you a deck of cards—add them to my deck.
            // Keep track of how many cards were added. If there weren't any, you'll need
            // to deal yourself a card from the stock (which was also passed as a parameter),
            // and you'll have to add a line to the TextBox: "Joe had to draw from the stock"
            _textBoxOnForm.Text += Name + " asks if anyone has a " + value + "\r\n";
            int totalCardsGiven = 0;
            for(int i = 0; i < players.Count; i++)
            {
                if( i != myIndex)
                {
                    Player player = players[i];
                    Deck CardsGiven = player.DoYouHaveAny(value);
                    totalCardsGiven += CardsGiven.Count;
                    while (CardsGiven.Count > 0)
                        _cards.Add(CardsGiven.Deal());
                }                
            }
            if (totalCardsGiven == 0 && stock.Count > 0)
            {
                _textBoxOnForm.Text += Name + " had to draw from the stock.\r\n";
                _cards.Add(stock.Deal());
            }
        }

        public void TakeCard(Card card) { _cards.Add(card); }
        public IEnumerable<string> GetCardNames() { return _cards.GetCardNames(); }
        public Card Peek(int cardNumber) { return _cards.Peek(cardNumber); }
        public void SortHand() { _cards.SortByValue(); }
    }
}
