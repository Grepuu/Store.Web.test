namespace Store.Web.Models.Entities
{
    public class SectionEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string MaxNumberOfRacks { get; set; }

        public ICollection<ProductEntity>? Products { get; set; }
    }
}
