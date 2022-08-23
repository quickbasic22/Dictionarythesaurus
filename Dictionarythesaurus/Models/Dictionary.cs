using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dictionarythesaurus.Models
{
    public class Dictionary
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public List<Definition> Definitions { get; set; }
        public List<Synonyms> Synonyms { get; set; }
        public List<Antonyms> Antonyms { get; set; }
    }
}
