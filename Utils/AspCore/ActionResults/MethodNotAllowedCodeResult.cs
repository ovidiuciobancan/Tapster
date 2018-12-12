using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Utils.AspCore.ObjectResults
{
    public class MethodNotAllowedCodeResult : StatusCodeResult
    {
        public MethodNotAllowedCodeResult() 
            : base((int)HttpStatusCode.MethodNotAllowed)
        { }
    }
}