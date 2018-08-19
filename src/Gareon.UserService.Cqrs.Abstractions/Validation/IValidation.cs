using System.Threading.Tasks;
using FluentValidation.Results;

namespace Gareon.UserService.Cqrs.Abstractions.Validation
{
    public interface IValidation<in T> where T : class
    {
        ValidationResult Validate(T data);

        Task<ValidationResult> ValidateAsync(T data);
    }
}