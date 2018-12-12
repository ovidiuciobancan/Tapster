using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Utils.AspCore.ObjectResults
{
    public class UnprocessableEntityObjectResult : ObjectResult
    {
        public UnprocessableEntityObjectResult(Dictionary<string, List<string>> errors)
            : base(errors)
        {
            errors = errors ?? throw new Exception("Validation failed with no errors.");
            StatusCode = 422;
        }
    }
}