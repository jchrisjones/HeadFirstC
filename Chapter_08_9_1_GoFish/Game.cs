using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter_08_9_1_GoFish
{
    class Game
    {
        //========== Fields ===========//
        private List<Player> _players;
        private Dictionary<Values, Player> _books;
        private Deck _stock;
        private TextBox _textBoxOnForm;

        //======== Constructors =======//
        public Game(string playerName, IEnumerable<string> opponentNames, TextBox textBoxOnForm)
        {
            Random random = new Random();
            _textBoxOnForm = textBoxOnForm;
            _players = new List<Player>();
            _players.Add(new Player(playerName, random, textBoxOnForm));
            foreach (string player in opponentNames)
                _players.Add(new Player(player, random, textBoxOnForm));
            _books = new Dictionary<Values, Player>();
            _stock = new Deck();
            Deal();
            _players[0].SortHand();
        }

        //======== Interfaces =========//

        //======== Properties =========//

        //========== Methods ==========//
        private void Deal()
        {
            // This is where the game starts—this method's only called at the beginning
            // of the game. Shuffle the stock, deal five cards to each player, then use a
            // foreach loop to call each player's PullOutBooks() method.
            _stock.Shuffle();
            _stock.Shuffle();
            for(int i = 0; i < 5; i++)
            {
                foreach (Player player in _players)
                    player.TakeCard(_stock.Deal());
            }
            foreach (Player player in _players)
                player.PullOutBooks();
        }

        public bool PlayOneRound(int selectedPlayerCard)
        {
            // Play one round of the game. The parameter is the card the player selected
            // from his hand—get its value. Then go through all of the players and call
            // each one's AskForACard() methods, starting with the human player (who's
            // at index zero in the Players list—make sure he asks for the selected
            // card's value). Then call PullOutBooks()—if it returns true, then the
            // player ran out of cards and needs to draw a new hand. After all the players
            // have gone, sort the human player's hand (so it looks nice in the form).
            // Then check the stock to see if it's out of cards. If it is, reset the
            // TextBox on the form to say, "The stock is out of cards. Game over!" and return
            // true. Otherwise, the game isn't over yet, so return false.
            Values SelectedCard = _players[0].Peek(selectedPlayerCard).Value;
            for (int i = 0; i < _players.Count; i++)
            {
                if (i == 0)
                    _players[0].AskForACard(_players, 0, _stock, SelectedCard);
                else
                    _players[i].AskForACard(_players, i, _stock);
                if (PullOutBooks(_players[i]))
                {
                    _textBoxOnForm.Text += _players[i].Name + " drew a new hand\r\n";
                    int card = 1;
                    while (card <= 5 && _stock.Count > 0)
                    {
                        _players[i].TakeCard(_stock.Deal());
                    }
                }
                _players[0].SortHand();
                if (_stock.Count == 0)
                {
                    _textBoxOnForm.Text += "The stock is out of cards, Game over!\r\n";
                    return true;
                }
            }
            return false;
        }

        public bool PullOutBooks(Player player)
        {
            // Pull out a player's books. Return true if the player ran out of cards, otherwise
            // return false. Each book is added to the Books dictionary. A player runs out of
            // cards when he’'s used all of his cards to make books—and he wins the game.
            IEnumerable<Values> booksPulled = player.PullOutBooks();
            foreach (Values value in booksPulled)
                _books.Add(value, player);
            if (player.CardCount == 0)
                return true;
            return false;
        }

        public string DescribeBooks()
        {
            // Return a long string that describes everyone's books by looking at the Books
            // dictionary: "Joe has a book of sixes. (line break) Ed has a book of Aces."
            string describeBooks = "";
            foreach (Values value in _books.Keys)
                describeBooks += _books[value].Name + " has a book of " + Card.Plural(value) + "\r\n";
            return describeBooks;
        }

        public string GetWinnerName()
        {
            // This method is called at the end of the game. It uses its own dictionary
            // (Dictionary<string, int> winners) to keep track of how many books each player
            // ended up with in the books dictionary. First it uses a foreach loop
            // on books.Keys—foreach (Values value in books.Keys)—to populate
            // its winners dictionary with the number of books each player ended up with.
            // Then it loops through that dictionary to find the largest number of books
            // any winner has. And finally it makes one last pass through winners to come
            // up with a list of winners in a string ("Joe and Ed"). If there's one winner,
            // it returns a string like this: "Ed with 3 books". Otherwise, it returns a
            // string like this: "A tie between Joe and Bob with 2 books."
            Dictionary<string, int> winners = new Dictionary<string, int>();
            foreach(Values value in _books.Keys)
            {
                string name = _books[value].Name;
                if (winners.ContainsKey(name))
                    winners[name]++;
                else
                    winners.Add(name, 1);
            }
            int mostBooks = 0;
            foreach (string name in winners.Keys)
                if (winners[name] > mostBooks)
                    mostBooks = winners[name];
            bool tie = false;
            string winnerList = "";
            foreach(string name in winners.Keys)
            {
                if(winners[name] == mostBooks)
                {
                    if(!String.IsNullOrEmpty(winnerList))
                    {
                        winnerList += " and ";
                        tie = true;
                    }
                    winnerList += name;
                }
            }
            winnerList += " with " + mostBooks + " books";
            if (tie)
                return "A tie between " + winnerList;
            else
                return winnerList;
        }

        public IEnumerable<string> GetPlayerCardNames()
        {
            return _players[0].GetCardNames();
        }
        public string DescribePlayerHands()
        {
            string description = "";
            for (int i = 0; i < _players.Count; i++)
            {
                description += _players[i].Name + " has " + _players[i].CardCount;
                if (_players[i].CardCount == 1)
                    description += " card." + Environment.NewLine;
                else
                    description += " cards." + Environment.NewLine;
            }
            description += "The stock has " + _stock.Count + " cards left.";
            return description;
        }
    }
}
