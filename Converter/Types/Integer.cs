namespace Converter.Types;

public class Integer : ConvertType
{
    private readonly int _value;

    public Integer(int integer)
    {
        _value = integer;
    }

    public Convert<Binary> ToBinary()
    {
        int n = _value;

        List<byte> bits = new();

        while (n > 0)
        {
            bits.Add((byte)(n % 2));

            n /= 2;
        }

        return new Convert<Binary>(bits.ToArray().Reverse().ToArray());
    }

    public override string ToString() => _value.ToString();

    public static bool operator ==(Integer a, Integer b) => a._value == b._value;
    public static bool operator !=(Integer a, Integer b) => a._value == b._value;

    public static implicit operator Integer(int value) => new(value);
    public static implicit operator Convert<Integer>(Integer value) => new(value);

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;

        if (obj is Integer integer)
            return integer._value == _value;

        if (obj is int value)
            return value == _value;

        return false;
    }

    public override int GetHashCode() => _value.GetHashCode();
}
