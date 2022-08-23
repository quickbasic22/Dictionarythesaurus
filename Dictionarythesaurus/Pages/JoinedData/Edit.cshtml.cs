﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dictionarythesaurus.Data;
using Dictionarythesaurus.Models;

namespace Dictionarythesaurus.Pages.JoinedData
{
    public class EditModel : PageModel
    {
        private readonly Dictionarythesaurus.Data.DictionarythesaurusContext _context;

        public EditModel(Dictionarythesaurus.Data.DictionarythesaurusContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dictionary Dictionary { get; set; } = default!;
        [BindProperty]
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

            var dictionary =  await _context.Dictionary.FirstOrDefaultAsync(m => m.Id == id);
            if (dictionary == null)
            {
                return NotFound();
            }
            var definition = await _context.Definition.FirstOrDefaultAsync(m => m.Id == id);
            if (definition == null)
            {
                return NotFound();
            }            
            Dictionary = dictionary;
            Definition.Id = Dictionary.Id;
            Definition = definition;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Dictionary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DictionaryExists(Dictionary.Id))
                {
                    return NotFound();
                }
                else if (!DefinitionExists(Definition.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
                
            }

            return RedirectToPage("./Index");
        }

        private bool DictionaryExists(int id)
        {
          return (_context.Dictionary?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private bool DefinitionExists(int id)
        {
            return (_context.Definition?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
