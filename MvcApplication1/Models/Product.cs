namespace MvcApplication1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        //修改部分
        //public Product(int id,string name,string imageurl,string description,decimal price)
        //{
        //    this.Id = id;
        //    this.Name = name;
        //    this.ImageUrl = imageurl;
        //    this.Description = description;
        //    this.Price = price;
        //}
    }
}