using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Common.Exceptions
{
    public sealed class ValidationExceptionCustom : Exception
    {
        public ValidationExceptionCustom() : base(ResponseMessage.VALIDATION_ERROR)
        {
            Errors = new List<BaseError>();
        }

        public ValidationExceptionCustom(IEnumerable<BaseError>? errors) : this()
        {
            Errors = errors;
        }

        public IEnumerable<BaseError>? Errors { get; }
    }
}
