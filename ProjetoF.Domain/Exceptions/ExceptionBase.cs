namespace ProjetoF.Domain.Exceptions;

public abstract class ExceptionBase : Exception
{
    protected ExceptionBase(string key, string message, string className) : base(message)
    {
        Key = key;
        ClassName = className;
    }

    public string Key { get; private set; }
    public string ClassName { get; private set; }
}