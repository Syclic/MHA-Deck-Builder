using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace MHA_Deck_Builder.Services
{
    public class Search
    {
        public Search(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }
        public bool CheckDifficulty(Card card)
        {
            int difficulty = 4;

            return card.Difficulty == difficulty;
        }
        public bool CheckSymbol(Card card)
        {
            string symbol = "Air";

            return card.Symbols.Contains(symbol);
        }
        public IEnumerable<Card> SearchCards()
        {
            IEnumerable<Card> CardList = new JsonFileHasherService(WebHostEnvironment).GetCard();
            List<Card> FilteredList = new List<Card>();
            List<Func<Card, bool>> filterFuncs = new List<Func<Card, bool>>();
            filterFuncs.Add(CheckDifficulty);
            filterFuncs.Add(CheckSymbol);

            foreach (Card card in CardList)
            {
                bool anyTrue = true;
                foreach (Func<Card, bool> func in filterFuncs)
                {
                    anyTrue &= func(card);
                    Console.WriteLine(anyTrue);
                }
                if (anyTrue)
                {
                    FilteredList.Add(card);
                    Console.WriteLine(FilteredList);
                }
            }

            return FilteredList;
        }
    }
}
