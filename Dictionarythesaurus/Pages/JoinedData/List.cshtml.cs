using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dictionarythesaurus.Data;
using Dictionarythesaurus.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dictionarythesaurus.Pages.JoinedData
{
    public class ListModel : PageModel
    {
        private readonly Dictionarythesaurus.Data.DictionarythesaurusContext _context;
        [BindProperty(SupportsGet = true)]
        public  SelectList DictionaryItems { get; set; } = default!;
        [BindProperty]
        public string SearchString { get; set; }

        public ListModel(Dictionarythesaurus.Data.DictionarythesaurusContext context)
        {
            _context = context;
        }

        public List<Dictionary> Dictionary { get;set; } = default!;
        public List<Definition> Definition { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Dictionary != null)
            {
                Dictionary = await _context.Dictionary.Where(s => s.Word.Contains(SearchString)).ToListAsync();
            }
            if (_context.Definition != null)
            {
                Definition = await _context.Definition.Where(s => s.Id == Dictionary.First().Id).ToListAsync();
            }
            DictionaryItems = new SelectList(Dictionary.Take(5).ToList(), "Id", "Word");
        }
    }
}
