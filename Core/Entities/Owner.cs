namespace Core.Entities
{
    public class Owner : EntityBase
    {
        public string Fullname { get; set; }
        public string Profile { get; set; }
        public string Avater { get; set; }

        public Address Address { get; set; }

    }
}
