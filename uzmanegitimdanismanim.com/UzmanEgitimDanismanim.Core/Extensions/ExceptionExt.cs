namespace UzmanEgitimDanismanim.Core.Extensions
{
    public static class ExceptionExt
    {
        public static IEnumerable<Exception> GetInnerExceptions(this Exception ex)
        {
            if (ex == null) throw new ArgumentNullException("ex");

            var innerException = ex;
            do
            {
                yield return innerException;
                innerException = innerException.InnerException;
            } while (innerException != null);
        }

        public static string GetAllInnerException(this Exception ex)
        {
            var messages = new List<string>();
            do
            {
                messages.Add(ex.Message);
                ex = ex.InnerException;
            } while (ex != null);

            return string.Join(" :: ", messages);
        }
    }
}
