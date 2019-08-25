﻿using BlueBoard.API.Models;
using BlueBoard.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;

namespace BlueBoard.API.Filters
{
    public class BlueBoardExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<BlueBoardExceptionFilter> _logger;

        public BlueBoardExceptionFilter(ILogger<BlueBoardExceptionFilter> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            if (context == null) return;
            if (context.Exception is BlueBoardBaseException baseException) { }
            _logger.LogError(context.Exception.Message, context.Exception);
            if (context.Exception is ValidationException exception)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                _logger.LogError("Code: {code}, Errors: {@errors}", exception.Code, exception.Errors);
                var model = new ExceptionModel(exception.Code, exception.Errors);
                context.Result = new JsonResult(model);
                return;
            }

            HttpStatusCode code;
            bool showTrace = true;
            switch (context.Exception)
            {
                case NotFoundException e:
                    {
                        showTrace = false;
                        code = HttpStatusCode.NotFound;
                        break;
                    }
                case AuthException e:
                    {
                        showTrace = false;
                        code = HttpStatusCode.Unauthorized;
                        break;
                    }
                default:
                    {
                        code = HttpStatusCode.InternalServerError;
                        break;
                    }
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            if (!showTrace) return;
            context.Result = new JsonResult(new
            {
                error = new[] { context.Exception.Message },
                stackTrace = context.Exception.StackTrace,
            });
        }
    }
}