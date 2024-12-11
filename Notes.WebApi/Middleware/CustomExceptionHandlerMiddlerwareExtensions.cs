namespace Notes.WebApi.Middleware
{
    public static class CustomExceptionHandlerMiddlerwareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddlerware>();
        }
    }
}
