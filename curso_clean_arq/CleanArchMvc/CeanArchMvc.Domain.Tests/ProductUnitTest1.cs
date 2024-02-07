using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeanArchMvc.Domain.Tests
{

    public  class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Dados( 1,"Product Name","Product Description",9.99m,
                99,"product image");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
               


        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalid()
        {
            Action action = () => new Dados(-1, "Product Name", "Product Description", 9.99m,
                99, "product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");



        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Dados(1, "Pr", "Product Description", 9.99m,
                99, "product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short,  minimum 3 characters");

        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionImageName()
        {
            Action action = () => new Dados(1, "Product Name", "Product Description", 9.99m,
                99, "product image tooooooooooooooooooooooooooooooooooooooooooooooooooooppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppooooooooo");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters");

        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Dados(1, "Product Name", "Product Description", 9.99m,
                99, null);
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
                
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Dados(1, "Product Name", "Product Description", 9.99m,
                99, "");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
           
        }

        [Theory] // com parâmetros.
        [InlineData(-5)]
     
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Dados(1, "Product Name", "Product Description", 9.99m,
                value, "product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value.");



        }
        [Fact]
        public void CreateProduct_InvalidPriceValue_DomainException()
        {
            Action action = () => new Dados(1, "Product Name", "Product Description", -9.99m,
                99, "product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value.");



        }


        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Dados(1, "Product Name", "Product Description", 9.99m,
                99, null);
            action.Should().NotThrow<NullReferenceException>(); // image?, quando for nulo a exceção
            // vai ser lançada.
                



        }


    }
}
