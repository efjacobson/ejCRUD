using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jacobson.Web.Models.Response
{
    public class SuccessResponse : BaseResponse
    {
        public SuccessResponse()
        {
            IsSuccessful = true;
        }
    }
}