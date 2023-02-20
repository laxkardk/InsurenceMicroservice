using Insurance.CustomerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Insurance.CustomerAPI.Filters
{
    /// <summary>
    /// Custom Exception filter to handle glob exceptions
    /// </summary>
    public class CustomExceptionFilter : IExceptionFilter
    {
        #region [Private Properties]

        private readonly ILogger _logger;

        #endregion [Private Properties]

        #region [Constructor]

        /// <summary>
        /// Default Initialization
        /// </summary>
        /// <param name="logger"></param>
        public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
        {
            _logger = logger;
        }

        #endregion [Constructor]

        #region [Public Methods]

        /// <summary>
        /// On Exception Handler
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                var exception = context.Exception;


                int statusCode;
                var result = new Response<string>();

                switch (true)
                {
                    case bool _ when exception is UnauthorizedAccessException:
                        result.SetError("Unauthorized");
                        statusCode = (int)HttpStatusCode.Unauthorized;
                        break;


                    case bool _ when exception is InvalidOperationException:
                        result.SetError("InvalidOperation");
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;


                    default:
                        statusCode = (int)HttpStatusCode.OK;
                        result.SetError("Something went wrong please try again.");
                        break;
                }

                _logger.LogError($"CustomExceptionFilter: Error in {context.ActionDescriptor.DisplayName}. {exception.Message}. Stack Trace: {exception.StackTrace}");

                // Custom Exception message to be returned
                context.Result = new ObjectResult(result) { StatusCode= statusCode};
            }
        }

        #endregion [Public Methods]
    }
}
