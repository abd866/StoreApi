using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Store.Services.Cahe;
using System.Text;

namespace Store.Web.Hellper
{
    public class CacheAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _timeToLiveInSecond;

        public CacheAttribute(int timeToLiveInSecond)
        {
           _timeToLiveInSecond = timeToLiveInSecond;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var _cachedServices=context.HttpContext.RequestServices.GetRequiredService<IcacheIServices>();
            var cachedKey = GnerateCachingKeyFromRequset(context.HttpContext.Request);
            var cachedRespons=await  _cachedServices.GetCacheResponseAsync(cachedKey);
            if(!string.IsNullOrEmpty(cachedRespons))
            {
                var contentRuslt = new ContentResult
                {
                    Content = cachedRespons,
                    ContentType = "application/json",
                    StatusCode = 200
                };
                context.Result = contentRuslt;
                return;

            }
            var excutedContext=await next();
            if (excutedContext.Result is OkObjectResult respons) 
            { 
            
            await _cachedServices.SetCacheResponseAsync(cachedKey, respons.Value,TimeSpan.FromSeconds(_timeToLiveInSecond));
            
            }

        }
        public string GnerateCachingKeyFromRequset(HttpRequest request) { 
        
        StringBuilder cahedKey=new StringBuilder();
            cahedKey.Append($"{request.Path}");
            foreach (var item in request.Query.OrderBy(c=>c.Key))
            
                cahedKey.Append(item);
            return cahedKey.ToString();
            
        }
    }
}
