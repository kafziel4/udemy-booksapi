using BooksApi.Exceptions;
using BooksApi.Schemas;
using HotChocolate.Resolvers;

namespace BooksApi.Middlewares
{
    public class DomainExceptionMiddleware
    {
        private readonly FieldDelegate _next;
        private readonly ILogger<DomainExceptionMiddleware> _logger;

        public DomainExceptionMiddleware(FieldDelegate next, ILogger<DomainExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(IMiddlewareContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainException ex) when (SetResult(context, ex.Message))
            {
                _logger.LogError(ex, "Unexpected Error");
            }
        }

        private bool SetResult(IMiddlewareContext context, string error)
        {
            Type type = context.Selection.Field.Type.NamedType().ToRuntimeType();

            if (type.IsSubclassOf(typeof(Payload)))
            {
                context.Result = (Payload)Activator.CreateInstance(type, null, error)!;
                return true;
            }

            return false;
        }
    }
}
