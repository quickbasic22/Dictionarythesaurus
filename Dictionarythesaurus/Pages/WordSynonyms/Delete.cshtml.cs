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
    public class DeleteModel : PageModel
    {
        private readonly Dictionarythesaurus.Data.DictionarythesaurusContext _context;

        public DeleteModel(Dictionarythesaurus.Data.DictionarythesaurusContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Synonyms == null)
            {
                return NotFound();
            }
            var synonyms = await _context.Synonyms.FindAsync(id);

            if (synonyms != null)
            {
                Synonyms = synonyms;
                _context.Synonyms.Remove(Synonyms);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
