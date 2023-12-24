using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id Value");
            Id = id;
            ValidateDomain(name);
        }

        public ICollection<Product> Products { get; set; }


        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.when(string.IsNullOrEmpty(name), "Invalid name.Name is required");

            DomainExceptionValidation.when(name.Length < 3, "Invalid name, too short, minimum 3 characters");

            Name = name;
        }
    }
}