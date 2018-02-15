namespace CorePOC.Model
{
    public class Card
    {
        public int cardid { get; set; }
        public string cardnumber { get; set; }
        public string cardtype { get; set; }
        public string expirydate { get; set; }
        public int userid { get; set; }
        public bool isactive { get; set; }
        public int consumerid { get; set; }
    }
}