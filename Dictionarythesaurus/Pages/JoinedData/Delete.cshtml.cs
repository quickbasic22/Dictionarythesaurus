using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dictionarythesaurus.Data;
using Dictionarythesaurus.Models;

namespace Dictionarythesaurus.Pages.JoinedData
{
    public class DeleteModel : PageModel
    {
        private readonly Dictionarythesaurus.Data.DictionarythesaurusContext _context;

        public DeleteModel(Dictionarythesaurus.Data.DictionarythesaurusContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Dictionary Dictionary { get; set; } = default!;
        public Definition Definition { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dictionary == null)
            {
                return NotFound();
            }
            if (id == null || _context.Definition == null)
            {
                return NotFound();
            }
            var dictionary = await _context.Dictionary.FirstOrDefaultAsync(m => m.Id == id);
            var definition = await _context.Definition.FirstOrDefaultAsync(m => m.Id == id);

            if (dictionary == null)
            {
                return NotFound();
            }
            else if (definition == null)
            {
                return NotFound();
            }
            else
            {
                Dictionary = dictionary;
                Definition = definition;
            }
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Dictionary == null)
            {
                return NotFound();
            }
            if (id == null || _context.Definition == null)
            {
                return NotFound();
            }
            var dictionary = await _context.Dictionary.FindAsync(id);
            var definition = await _context.Definition.FindAsync(id);

            if (dictionary != null)
            {
                Dictionary = dictionary;
                _context.Dictionary.Remove(Dictionary);
                await _context.SaveChangesAsync();
            }
            if (definition != null)
            {
                Definition = definition;
                Definition.Id = Dictionary.Id;
                _context.Definition.Remove(definition);
                await _context.SaveChangesAsync();
            }            

            return RedirectToPage("./Index");
        }
    }
}
