using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MHA_Deck_Builder.Services;

namespace MHA_Deck_Builder.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileHasherService HasherService;
        public IEnumerable<Card> cardIndex { get; private set; }

        public IndexModel(
            ILogger<IndexModel> logger,
            JsonFileHasherService hasherService)
        {
            _logger = logger;
            HasherService = hasherService;
        }

        public void OnGet()
        {
            cardIndex = HasherService.GetCard();
        }
    }
}
