using TeamleaderDotNet.Crm;

namespace TeamleaderDotNet.General
{
    public class BookkeepingAccount : Entity
    {
        public int Id { get; set; }

        public string account { get; set; }
        public string name { get; set; }
        public string name_nl { get; set; }
        public string name_fr { get; set; }


    }
}
