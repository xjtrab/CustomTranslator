using System.ComponentModel.DataAnnotations;

namespace CustomTranslator.API.DataAccess
{
    public class TranslatorHistory
    {
       
        public TranslatorHistory(string fromText, string toText, string from, string to, DateTime queryTime)
        {
            FromText = fromText;
            ToText = toText;
            From = from;
            To = to;
            QueryTime = queryTime;
        }

        [Key]
        public int Id { get; set; }
        public string FromText { get; set; }
        public string ToText { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime QueryTime { get; set; }
    }
}
