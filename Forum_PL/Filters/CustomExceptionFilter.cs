﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum_PL.Filters
{
    public class CustomExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        public  void OnException(ExceptionContext context)
        {
            string action = context.ActionDescriptor.DisplayName;
            string callStack = context.Exception.StackTrace;
            string exceptionMessage = context.Exception.Message;
            context.Result = new ContentResult
            {
                Content = $"Calling {action} failed, because: {exceptionMessage}. Callstack: {callStack}.",
                StatusCode = 500
            };
            context.ExceptionHandled = true;
        }
    }
}
