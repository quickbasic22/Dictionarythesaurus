﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dictionarythesaurus.Data;
using Dictionarythesaurus.Models;

namespace Dictionarythesaurus.Pages.WordDefinition
{
    public class DeleteModel : PageModel
    {
        private readonly Dictionarythesaurus.Data.DictionarythesaurusContext _context;

        public DeleteModel(Dictionarythesaurus.Data.DictionarythesaurusContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Definition Definition { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Definition == null)
            {
                return NotFound();
            }

            var definition = await _context.Definition.FirstOrDefaultAsync(m => m.Id == id);

            if (definition == null)
            {
                return NotFound();
            }
            else 
            {
                Definition = definition;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Definition == null)
            {
                return NotFound();
            }
            var definition = await _context.Definition.FindAsync(id);

            if (definition != null)
            {
                Definition = definition;
                _context.Definition.Remove(Definition);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
