using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dictionarythesaurus.Data;
using Dictionarythesaurus.Models;

namespace Dictionarythesaurus.Pages.JoinedData
{
    public class DictionaryAndDefinitionModel : PageModel
    {
        private readonly Dictionarythesaurus.Data.DictionarythesaurusContext _context;

        public DictionaryAndDefinitionModel(Dictionarythesaurus.Data.DictionarythesaurusContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Dictionary Dictionary { get; set; } = default!;
        public Definition Definition { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Dictionary == null || Dictionary == null)
            {
                return Page();
            }
            if (!ModelState.IsValid || _context.Definition == null || Definition == null)
            {
                return Page();
            }
            Definition.Id = Dictionary.Id;

            _context.Dictionary.Add(Dictionary);
            _context.Definition.Add(Definition);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
