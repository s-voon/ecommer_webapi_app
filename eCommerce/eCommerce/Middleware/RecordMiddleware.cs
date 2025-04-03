namespace eCommerce.Middleware
{
    public class RecordMiddleware
    {

        private readonly RequestDelegate _next;


        public RecordMiddleware(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Before calling next middleware which is routing");

            Console.WriteLine($"Request Method if {context.Request.Method}");
            Console.WriteLine($"Request Path if {context.Request.Path}");

            await _next(context);

            Console.WriteLine("After routing and other middleware all the way till endpoints, logging response");
            Console.WriteLine($"Response status code is {context.Response.StatusCode}");
        }

    }
}
