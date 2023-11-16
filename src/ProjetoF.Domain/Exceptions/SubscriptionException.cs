namespace ProjetoF.Domain.Exceptions;

public class SubscriptionException : ExceptionBase
{
    public SubscriptionException(string key, string message, string className) : base(key, message, className)
    { }
}
