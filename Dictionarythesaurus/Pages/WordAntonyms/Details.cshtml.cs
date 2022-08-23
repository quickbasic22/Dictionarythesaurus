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
    public class DetailsModel : PageModel
    {
        private readonly Dictionarythesaurus.Data.DictionarythesaurusContext _context;

        public DetailsModel(Dictionarythesaurus.Data.DictionarythesaurusContext context)
        {
            _context = context;
        }

      public Antonyms Antonyms { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Antonyms == null)
            {
                return NotFound();
            }

            var antonyms = await _context.Antonyms.FirstOrDefaultAsync(m => m.Id == id);
            if (antonyms == null)
            {
                return NotFound();
            }
            else 
            {
                Antonyms = antonyms;
            }
            return Page();
        }
    }
}
