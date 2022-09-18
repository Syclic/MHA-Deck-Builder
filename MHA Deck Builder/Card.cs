using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace MHA_Deck_Builder
{
    public class Card
    {
        public string image { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Symbols { get; set; }
        public int Difficulty { get; set; }
        public int Control { get; set; }
        public string Type { get; set; }
        public string BlockZone { get; set; }
        public int BlockMod { get; set; }
        public string[] Keywords { get; set; }
        public string Abilities { get; set; }
        public string Zone { get; set; }
        public int Speed { get; set; }
        public int Damage { get; set; }
        public int HandSize { get; set; }
        public int Health { get; set; }
        public string Rarity { get; set; }
        public int Source { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
