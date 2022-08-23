using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dictionarythesaurus.Data;
using Dictionarythesaurus.Models;

namespace Dictionarythesaurus.Pages.WordAntonyms
{
    public class IndexModel : PageModel
    {
        private readonly Dictionarythesaurus.Data.DictionarythesaurusContext _context;

        public IndexModel(Dictionarythesaurus.Data.DictionarythesaurusContext context)
        {
            _context = context;
        }

        public IList<Antonyms> Antonyms { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Antonyms != null)
            {
                Antonyms = await _context.Antonyms.ToListAsync();
            }
        }
    }
}
