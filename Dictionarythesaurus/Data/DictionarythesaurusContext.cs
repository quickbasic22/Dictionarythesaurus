using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dictionarythesaurus.Models;

namespace Dictionarythesaurus.Data
{
    public class DictionarythesaurusContext : DbContext
    {
        public DictionarythesaurusContext (DbContextOptions<DictionarythesaurusContext> options)
            : base(options)
        {
        }

        public DbSet<Dictionarythesaurus.Models.Dictionary> Dictionary { get; set; } = default!;

        public DbSet<Dictionarythesaurus.Models.Definition>? Definition { get; set; }

        public DbSet<Dictionarythesaurus.Models.Antonyms>? Antonyms { get; set; }

        public DbSet<Dictionarythesaurus.Models.Synonyms>? Synonyms { get; set; }
    }
}
