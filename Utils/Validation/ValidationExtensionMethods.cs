using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.Extensions.DependencyInjection;

using FluentValidation.Results;
using Utils.Extensions;
using Utils.String.Extensions;

namespace Utils.Validation.Extensions
{
    public static class ValidationExtensionMethods
    {
        /// <summary>
        /// Maps the error from an invalid ModelState to a Dictionary
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static Dictionary<string, List<string>> GetErrors(this ModelStateDictionary modelState)
        {
            return modelState
                .Where(p => p.Value.Errors.Any())
                .ToDictionary
                (
                    p => p.Key.Decapitalize(),
                    p => p.Value.Errors
                        .Select(e => e.ErrorMessage)
                        .ToList()
                );
        }
        /// <summary>
        /// Maps the error from a list of ValidationFailure to a Dictionary
        /// </summary>
        /// <param name="validationFailures"></param>
        /// <returns></returns>
        public static Dictionary<string, List<string>> GetErrors(this IList<ValidationFailure> validationFailures)
        {
            var result = new Dictionary<string, List<string>>();

            foreach (var validation in validationFailures)
            {
                var propertyName = validation.PropertyName.Decapitalize();

                if(!result.ContainsKey(propertyName))
                {
                    result.Add(propertyName, new List<string>());
                }

                result[propertyName].Add(validation.ErrorMessage);
            }

            return result;
        }
        private static string GetModelKey<F, T>(Expression<Func<F, T>> expression)
        {
            return ExpressionHelper.GetExpressionText(expression);
        }
        public static void AddModelError<TModel>(this ModelStateDictionary modelState, string message)
        {
            modelState.AddModelError<TModel, dynamic>(message);
        }
        public static void AddModelError<TModel, TProperty>(this ModelStateDictionary modelState, string message, Expression<Func<TModel, TProperty>> expression = null)
        {
            var property = expression != null ? GetModelKey(expression) : "_error";
            modelState.TryAddModelError(property, message);
        }
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            Func<Type, bool> exprGoodInterfaces = (i) => {

                return i.FullName.HasValue() && i.FullName.Contains("Utils.Extensions.IValidator");
            };

            var allAssemblies = new List<Assembly> { Assembly.GetCallingAssembly() }
               .Union(
                   Assembly.GetCallingAssembly()
                       .GetReferencedAssemblies()
                       .Select(assName => Assembly.Load(assName)))
               .ToList();

            var allInterfaces = allAssemblies
                .SelectMany(a => a.GetTypes())
                .Where(t => t.GetInterfaces().Any(exprGoodInterfaces))
                .ToList();

            allInterfaces.ForEach(timpl =>
            {
                var allMappers = timpl.GetTypeInfo().GetInterfaces()
                                    .Where(exprGoodInterfaces)
                                    .ToList();

                allMappers.ForEach(m =>
                {
                    services.AddScoped(m, timpl);
                });
            });

            return services.AddScoped<ValidationService>();
        }
    }
}