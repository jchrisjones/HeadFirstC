using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter_08_8_TwoDecks
{
    class Deck
    {
        //========= Fields ========//

        private List<Card> cards;
        private Random random = new Random();

        //======= Constructors ====//

        public Deck()
        {
            cards = new List<Card>();
            for(int suit = 0; suit <= 3; suit++)
                for(int value = 1; value <= 13; value++)
                    cards.Add(new Card((Suits) suit, (Values) value));
        }

        public Deck(IEnumerable<Card> initialCards)
        {
            cards = new List<Card>(initialCards);
        }
        //======== Properties =====//
        public int Count { get { return cards.Count; } }

        //========== Methods ======//
        public void Add(Card cardToAdd)
        {
            cards.Add(cardToAdd);
        }

        public Card Deal(int index)
        {
            Card CardToDeal = cards[index];
            cards.RemoveAt(index);
            return CardToDeal;
        }

        public IEnumerable<string> GetCardNames()
        {
            string[] CardNames = new string[cards.Count];
            for (int i = 0; i < CardNames.Length; i++)
                CardNames[i] = cards[i].Name;
            return CardNames;
        }

        public void Shuffle()
        {
            Card tempCard;
            int randomPosition;
            for(int i = 0; i < cards.Count; i++)
            {
                randomPosition = random.Next(cards.Count);
                tempCard = cards[randomPosition];
                cards.RemoveAt(randomPosition);
                cards.Insert(random.Next(cards.Count + 1), tempCard);
            }
        }

        public void Sort()
        {
            cards.Sort(new CardComparer_bySuit());
        }
    }
}
