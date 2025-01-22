using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace APIslovnik
{
    internal class tridy
    {

        // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
        public class Definition
        {
            public string definition { get; set; }
            public List<object> synonyms { get; set; }
            public List<object> antonyms { get; set; }
            public string example { get; set; }
        }

        public class Meaning
        {
            public string partOfSpeech { get; set; }
            public List<Definition> definitions { get; set; }
            public List<string> synonyms { get; set; }
            public List<string> antonyms { get; set; }
        }

        public class Phonetic
        {
            public string audio { get; set; }
            public string sourceUrl { get; set; }
            public string text { get; set; }
        }

        public class Root
        {
            public string word { get; set; }
            public List<Phonetic> phonetics { get; set; }
            public List<Meaning> meanings { get; set; }
            public List<string> sourceUrls { get; set; }
        }
    }
}
