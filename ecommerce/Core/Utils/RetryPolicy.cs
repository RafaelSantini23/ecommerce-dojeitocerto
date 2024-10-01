namespace ecommerce.Core.Utils
{
    public class RetryPolicy
    {
        public static async Task<bool> ExecuteAsync(Func<Task<bool>> action, int maxAttempts, TimeSpan delay)
        {
            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                if (await action())
                {
                    return true; 
                }

                await Task.Delay(delay);
            }

            return false;
        }
    }
}