using System.Collections.Generic;

namespace CorePOC.Model
{

    public class NewCard
    {
        public int cardid { get; set; }
        public string cardnumber { get; set; }
        public string cardtype { get; set; }
        public string expirydate { get; set; }
        public bool isactive { get; set; }
    }
    public class newConsumer
    {
        public int userid { get; set; }
        public string emailAddress { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }        
        public List<NewCard> cardDetails { get; set; }

        public NewCard card{get;set;}
    }
}