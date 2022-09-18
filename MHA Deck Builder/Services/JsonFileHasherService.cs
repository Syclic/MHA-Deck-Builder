using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MHA_Deck_Builder;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;
using System.IO;

namespace MHA_Deck_Builder.Services
{
    public class JsonFileHasherService
    {
        public JsonFileHasherService()
        {
        }
        public JsonFileHasherService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Sets", "MHA01.json"); }
        }
        public IEnumerable<Card> GetCard()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<Card[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }
    }
}
