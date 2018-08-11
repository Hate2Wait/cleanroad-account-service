using FluentValidation.Results;
using System.Threading.Tasks;

namespace CleanRoad.UserService.Cqrs.Abstractions.Validation
{
    public interface IValidation<in T> where T : class
    {
        ValidationResult Validate(T data);

        Task<ValidationResult> ValidateAsync(T data);
    }
}