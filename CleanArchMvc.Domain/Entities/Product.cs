using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public int Stock { get; private set; }

        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id Value");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

         public Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.when(string.IsNullOrEmpty(name), "Invalid name. Name is required");

            DomainExceptionValidation.when(name.Length < 3, "Invalid name, too short, minimum 3 characters");

            DomainExceptionValidation.when(string.IsNullOrEmpty(description), "Invalid description. Description is required");
        }

        public int CategoryId { get; set; }

        public Category Category { get; set; }   
    }
}