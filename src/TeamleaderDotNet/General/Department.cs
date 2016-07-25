using TeamleaderDotNet.Crm;

namespace TeamleaderDotNet.General
{
    public class Department : Entity
    {
        public int Id { get; set; }

        [TeamleaderDataType(Name = "name")]
        public string name { get; set; }


    }
}
