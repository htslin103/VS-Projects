namespace DigitalLibraryApplication.Middleware
{
    public class SimpleMiddleware
    {
        private readonly RequestDelegate _next;
        
        public SimpleMiddleware(RequestDelegate next) 
        {
            _next = next;    
        }

        public Task InvokeAsync(HttpContext context) 
        {   //TODO: add something in our response here later
            //Call the next delegate/middleware in the pipeline 
            return this._next(context);
        }
    }
}