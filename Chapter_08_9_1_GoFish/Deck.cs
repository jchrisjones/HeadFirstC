using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter_08_9_1_GoFish
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

        public Card Deal()
        {
            return Deal(0);
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

        public void SortByValue()
        {
            cards.Sort(new CardComparer_byValue());
        }

        public Card Peek(int cardNumber) 
        {
            return cards[cardNumber];
        }
        
        public bool ContainsValue(Values value) 
        {
            foreach (Card card in cards)
                if (card.Value == value)
                    return true;
            return false;
        }
        public Deck PullOutValues(Values value) 
        {
            Deck deckToReturn = new Deck(new Card[] { });
            for (int i = cards.Count - 1; i >= 0; i--)
                if (cards[i].Value == value)
                    deckToReturn.Add(Deal(i));
            return deckToReturn;
        }
        public bool HasBook(Values value) 
        {
            int NumberOfCards = 0;
            foreach (Card card in cards)
            if (card.Value == value)
                NumberOfCards++;
            if (NumberOfCards == 4)
                return true;
            else
                return false;
        }
       
    }
}
