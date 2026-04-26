using Microsoft.AspNetCore.Builder; // זה ה-Using שפתר את השגיאה של IApplicationBuilder
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace TipatCholAPI.Middlewares
{
    public class ShabbatMiddleware
    {
        private readonly RequestDelegate _next;

        public ShabbatMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // בדיקה האם היום יום שבת
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Service is not available on Shabbat.");
                return; // עוצר את ה-Pipeline ולא ממשיך ל-Next
            }

            await _next(context);
        }
    }

    // Extension Method להוספה נוחה ב-Program.cs
    public static class ShabbatMiddlewareExtensions
    {
        public static IApplicationBuilder UseShabbatCheck(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ShabbatMiddleware>();
        }
    }
}