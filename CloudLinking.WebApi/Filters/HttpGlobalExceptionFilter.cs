using CloudLinking.Entity.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudLinking.WebApi.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        readonly ILoggerFactory _loggerFactory;
        readonly IHostingEnvironment _hostingEnvironment;
        public HttpGlobalExceptionFilter(ILoggerFactory loggerFactory, IHostingEnvironment hostingEnvironment)
        {
            _loggerFactory = loggerFactory;
            _hostingEnvironment = hostingEnvironment;
        }
        public void OnException(ExceptionContext context)
        {
            var logger = _loggerFactory.CreateLogger(context.Exception.TargetSite.ReflectedType);
            logger.LogError(new EventId(context.Exception.HResult), context.Exception, context.Exception.Message);

            HttpResult<string> result = new HttpResult<string>();
            result.Success = Convert.ToString(Entity.Common.Enum.HTTP_SUCCESS.FAIL);
            result.Code = -1;
            result.Msg = context.Exception.Message;

            context.Result = result;
            throw new NotImplementedException();
        }
    }
}
