using System.Collections.Generic;
using ATMApp;

namespace ATM_Project
{
    public static class CardHolderManager
    {
        public static List<CardHolder> InitializeCardHolders()
        {
            List<CardHolder> cardHolders = new List<CardHolder>
            {
                new CardHolder("99", "1234", "John", "Doe", 1500.00),
                new CardHolder("102", "2345", "Jane", "Smith", 2500.00),
                new CardHolder("111", "3456", "Jim", "Beam", 3500.00),
                new CardHolder("123", "4567", "Jill", "Stark", 4500.00)
            };

            return cardHolders;
        }
    }
}