using System;
using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_With_Valid_Parameters_Result_Object_Valid_State()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should()
                            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_With_Negative_Id_Value_Result_Object_Valid_State()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should()
                            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                            .WithMessage("Invalid Id Value");
        }

        [Fact]
        public void CreateProduct_With_Short_Name_Value_Returns_Domain_Return_Exception_Short_Name()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "product image");
            action.Should()
                            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                            .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateProduct_With_Long_Image_Name_Domain_Return_Exception_Long_Image_Name()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "product image toooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong");
            action.Should()
                            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                            .WithMessage("Invalid image name, too long, maximum 250 characters");
        }

        [Fact]
        public void CreateProduct_With_Null_Image_Name_Not_Return_Domain_Exception()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should()
                            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_With_Null_Image_Name_Not_Null_Reference_Exception()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should()
                            .NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CreateProduct_With_Empty_Image_Name_Not_Return_Domain_Exception()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "");
            action.Should()
                            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_With_Invalid_Price_Return_Domain_Exception_Invalid()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -9.99m, 99, "product image");
            action.Should()
                            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                            .WithMessage("Invalid price value");
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_With_Invalid_Stock_Value_Exception_Return_Domain_Negative_Value(int value)
        {
            Action action = () => new Product(1, "Pro", "Product Description", 9.99m, value, "product image");
            action.Should()
                            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                            .WithMessage("Invalid stock value");
        }
    }
}