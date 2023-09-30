namespace Converter;

public sealed class Convert<T> where T : ConvertType
{
    public T C { get; }

    public Convert(T c)
    {
        C = c;
    }

    public override string ToString() => C?.ToString() ?? "";
}