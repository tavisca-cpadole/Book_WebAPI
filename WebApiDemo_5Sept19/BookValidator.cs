using FluentValidation;
using WebApiDemo_5Sept19.Model;

namespace WebApiDemo_5Sept19
{
    public class BookValidator : AbstractValidator<Book>
    {

        public BookValidator()
        {
            Initialize();
        }

        private void Initialize()
        {
            BookNameValidation();
            BookAuthorValidation();
            BookCategoryValidation();
            BookPriceValidation();
            BookIdValidation();
        }

        public void BookNameValidation()
        {
            RuleFor(b => b.name)
                .NotEmpty()
                .WithMessage("Book Name Should Not Be Empty");


        }

        public void BookAuthorValidation()
        {
            RuleFor(b => b.author)
                .NotEmpty()
                .WithMessage("Book Author Should Not Be Empty")
                .Matches(@"^[a-zA-Z\s]+$")
                .WithMessage("Book Author Name Should Only Contain Letters");

        }

        public void BookCategoryValidation()
        {
            RuleFor(b => b.category)
                .NotEmpty()
                .WithMessage("Book Category Should Not Be Empty")
                .Matches(@"^[a-zA-Z\s]+$")
                .WithMessage("Book Category Should Only Contain Letters");

        }

        public void BookPriceValidation()
        {
            RuleFor(b => b.price)
                .NotEmpty()
                .WithMessage("Book Price Should Not Be Empty")
                .GreaterThan(0)
                .WithMessage("Book Price Should Not Be Negative");

        }

        public void BookIdValidation()
        {
            RuleFor(b => b.id)
                .NotEmpty()
                .WithMessage("Book Id Should Not Be Empty")
                .GreaterThan(0)
                .WithMessage("Book Id Should Not Be Negative");

        }
    }
}
