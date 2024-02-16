using System.Diagnostics;
using System.Text;

namespace Products.API.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<RequestLoggingMiddleware> logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            await next(context);

            stopwatch.Stop();
            var elapsedTime = stopwatch.ElapsedMilliseconds;

            var logMessage = $"[{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")}] {context.Request.Method} {context.Request.Path} - Elapsed Time: {elapsedTime} ms";
            logger.LogInformation(logMessage);

            await WriteToFileAsync(logMessage);
        }

        private async Task WriteToFileAsync(string message)
        {
            var logFilePath = "Logs/requests.txt";

            try
            {
                await using (var writer = new StreamWriter(logFilePath, append: true, encoding: Encoding.UTF8))
                {
                    await writer.WriteLineAsync(message);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Error writing to log file: {ex.Message}");
            }
        }
    }
}
