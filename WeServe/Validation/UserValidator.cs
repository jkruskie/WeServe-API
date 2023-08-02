using FluentValidation;
using WeServe.DTO;
using WeServe.Models;

namespace WeServe.Validation
{
    /// <summary>
    /// The validation for the user model.
    /// </summary>
    /// <author>Justin Kruskie</author>
    /// <date>07/28/2023</date>
    public class UserValidator : AbstractValidator<User>
    {
        /// <summary>
        /// Create a new instance of the user validator.
        /// </summary>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public UserValidator()
        {
            RuleFor(user => user.Email).NotEmpty().EmailAddress();
            RuleFor(user => user.FirstName).NotEmpty();
            RuleFor(user => user.LastName).NotEmpty();
            RuleFor(user => user.Role).NotEmpty();
        }
    }

    /// <summary>
    /// The validation for the create user DTO.
    /// </summary>
    /// <author>Justin Kruskie</author>
    /// <date>07/28/2023</date>
    public class CreateUserDTOValidator : AbstractValidator<CreateUserDTO>
    {
        /// <summary>
        /// Create a new instance of the login user DTO validator.
        /// </summary>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public CreateUserDTOValidator()
        {
            RuleFor(user => user.Email).NotEmpty().EmailAddress();
            RuleFor(user => user.Password).NotEmpty();
            RuleFor(user => user.FirstName).NotEmpty();
            RuleFor(user => user.LastName).NotEmpty();
            RuleFor(user => user.Role).NotEmpty();
        }
    }

    /// <summary>
    /// The validation for the login user DTO.
    /// </summary>
    /// <author>Justin Kruskie</author>
    /// <date>07/28/2023</date>
    public class SigninUserDTOValidator : AbstractValidator<SigninUserDTO>
    {
        /// <summary>
        /// Create a new instance of the login user DTO validator.
        /// </summary>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public SigninUserDTOValidator()
        {
            RuleFor(user => user.Email).NotEmpty().EmailAddress();
            RuleFor(user => user.Password).NotEmpty();
        }
    }
}
