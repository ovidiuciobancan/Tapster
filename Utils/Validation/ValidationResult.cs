using Microsoft.AspNetCore.Mvc;

namespace Utils.Validation
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public ActionResult Result { get; set; }
    }
}