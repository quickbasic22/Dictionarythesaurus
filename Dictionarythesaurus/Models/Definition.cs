namespace Dictionarythesaurus.Models
{
    public class Definition
    {
        public int Id { get; set; }
        public string WordDefinition { get; set; }
        public string PartOfSpeech { get; set; }
        public Dictionary Dictionary { get; set; }
    }
}
