using Microsoft.AspNetCore.Mvc;

namespace Utils.AspCore.Extensions
{
    public static class AspCoreExtensionMethods
    {
        public static UnprocessableEntityObjectResult UnprocessableEntity(this Controller controller)
        {
            return new UnprocessableEntityObjectResult(controller.ModelState);
        }
    }
}
