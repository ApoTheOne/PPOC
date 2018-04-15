using System.Collections.Generic;

namespace CorePOC.Model
{
    public class ConsumerDetails
    {
        public int user_id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public List<Card> cards{ get; set; }
        public List<NewCard> newcards{ get; set; }
    }
}