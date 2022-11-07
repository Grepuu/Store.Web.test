namespace Store.Web.Models.DTO
{
    public class SectionDTO
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string MaxNumberOfRacks { get; set; }

        public ICollection<ProductDTO>? Products { get; set; }
    }
}
