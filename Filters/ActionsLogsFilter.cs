using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP.Filters
{
    public class ActionsLogsFilter : IActionFilter
    {
        private readonly ILogger<ActionsLogsFilter> _logger;

        public ActionsLogsFilter(ILogger<ActionsLogsFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            var currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            _logger.LogInformation($"Action '{actionName}' викликано в {currentTime}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }
    }
}
