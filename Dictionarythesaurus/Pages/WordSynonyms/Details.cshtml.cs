using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dictionarythesaurus.Data;
using Dictionarythesaurus.Models;

namespace Dictionarythesaurus.Pages.WordSynonyms
{
    public class DetailsModel : PageModel
    {
        private readonly Dictionarythesaurus.Data.DictionarythesaurusContext _context;

        public DetailsModel(Dictionarythesaurus.Data.DictionarythesaurusContext context)
        {
            _context = context;
        }

      public Synonyms Synonyms { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Synonyms == null)
            {
                return NotFound();
            }

            var synonyms = await _context.Synonyms.FirstOrDefaultAsync(m => m.Id == id);
            if (synonyms == null)
            {
                return NotFound();
            }
            else 
            {
                Synonyms = synonyms;
            }
            return Page();
        }
    }
}
