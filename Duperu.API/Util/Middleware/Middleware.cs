namespace Duperu.API.Util.Middleware
{
    public class Middleware
    {

        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Lógica de middleware aquí
            await _next(context);
        }


    }
}
