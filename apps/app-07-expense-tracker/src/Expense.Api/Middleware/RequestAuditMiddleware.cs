using Serilog;

namespace Expense.Api.Middleware;

public sealed class RequestAuditMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        if (HttpMethods.IsPost(context.Request.Method) || HttpMethods.IsPut(context.Request.Method) || HttpMethods.IsDelete(context.Request.Method))
        {
            Log.Information("AUDIT {Method} {Path} CorrelationId={CorrelationId}", context.Request.Method, context.Request.Path, context.TraceIdentifier);
        }
        await next(context);
    }
}
