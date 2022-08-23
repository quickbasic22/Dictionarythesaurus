using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dictionarythesaurus.Data;
using Dictionarythesaurus.Models;

namespace Dictionarythesaurus.Pages.WordDictionary
{
    public class DetailsModel : PageModel
    {
        private readonly Dictionarythesaurus.Data.DictionarythesaurusContext _context;

        public DetailsModel(Dictionarythesaurus.Data.DictionarythesaurusContext context)
        {
            _context = context;
        }

      public Dictionary Dictionary { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dictionary == null)
            {
                return NotFound();
            }

            var dictionary = await _context.Dictionary.FirstOrDefaultAsync(m => m.Id == id);
            if (dictionary == null)
            {
                return NotFound();
            }
            else 
            {
                Dictionary = dictionary;
            }
            return Page();
        }
    }
}
