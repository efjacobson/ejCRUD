using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jacobson.Web.Models.Response
{
    public class ErrorResponse : BaseResponse
    {
        public List<string> Errors { get; set; }

        public ErrorResponse(string errorMessage)
        {
            Errors.Add(errorMessage);
            IsSuccessful = false;
        }

        public ErrorResponse(IEnumerable<string> errorMessages)
        {
            Errors.AddRange(errorMessages);
            IsSuccessful = false;
        }
    }
}