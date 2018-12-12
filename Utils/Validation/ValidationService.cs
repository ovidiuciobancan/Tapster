using System;

namespace Utils.Validation
{
    public class ValidationService
    {
        private IServiceProvider _services;
        public ValidationService(IServiceProvider services)
        {
            _services = services;
        }

        public ValidationResult Validate<T>(T model)
        {
            var validator = (IValidator<T>)_services.GetService(typeof(IValidator<T>));

            return validator.ValidateModel(model);
        }
    }
}