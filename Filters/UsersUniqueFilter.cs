using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP.Filters
{
    public class UsersUniqueFilter : IActionFilter
    {
        private readonly ILogger<UsersUniqueFilter> _logger;
        private readonly HashSet<string> _uniqueUsers = new HashSet<string>();
        

        public UsersUniqueFilter(ILogger<UsersUniqueFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.User.Identity?.Name;

            _logger.LogInformation($"New unique user: {user}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
