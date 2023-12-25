using System;
using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_With_Valid_Parameters_Result_Object_Valid_State()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_With_Negative_Id_Value_Result_Object_Valid_State()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                            .WithMessage("Invalid Id Value");
        }

        [Fact]
        public void CreateCategory_With_Short_Name_Value_Returns_Domain_Exception_Short_Name()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                            .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateCategory_With_Missing_Name_Value_Domain_Exception_Required_Name()
        {
            Action action = () => new Category(1, "");
            action.Should()
                            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                            .WithMessage("Invalid name. Name is required");
        }

        [Fact]
        public void CreateCategory_With_Null_Name_Value_Domain_Exception_Invalid_Name()
        {
            Action action = () => new Category(1, null);
            action.Should()
                            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
