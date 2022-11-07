namespace Store.Web.Models.Entities
{
    public class IngredientEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mass { get; set; }
        public int? ProductId { get; set; }
        public ProductEntity? Product { get; set; }
    }
}
