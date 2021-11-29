using BrasilCashTest.Domain.Entities;
using FluentValidation;


namespace BrasilCashTest.Domain.Validations

{
   
  public class CustomerValidation : AbstractValidator<Customer>
    {
            public CustomerValidation()
            {
            //Expressão lambda, criando regras para validação das entradas

            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia")

                .NotNull()
                .WithMessage("O campo não pode ser nulo");

            RuleFor(x => x.Name)
            .MaximumLength(60);

            RuleFor(x => x.TaxId);
            

        }
    }
    
}
