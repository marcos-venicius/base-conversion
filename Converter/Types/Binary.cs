namespace Converter.Types;

public sealed class Binary : ConvertType
{
    private readonly byte[] _bits;

    public Binary(params byte[] bits)
    {
        ValidateBits(bits);

        _bits = bits;
    }

    public Binary(params char[] bits) : this(TransformBits(bits)) { }

    public Binary(string bits) : this(TransformBits(bits)) { }

    private static byte[] ValidateBits(byte[] bits)
    {
        foreach (var bit in bits)
            if (bit != 0 && bit != 1) throw new Exception($"Invalid bit '{bit}'. 0/1");

        return bits;
    }

    private static byte[] TransformBits(char[] bits) => bits.Select(bit => byte.Parse(bit.ToString())).ToArray();
    private static byte[] TransformBits(string bits) => TransformBits(bits.ToCharArray());

    public Convert<Integer> ToInteger()
    {
        int value = 0;
        int pos = _bits.Length - 1;

        do
            value += _bits[_bits.Length - pos - 1] * (int)Math.Pow(2, pos);
        while (pos-- > 0);

        return new Convert<Integer>(value);
    }

    public static bool operator ==(Binary a, Binary b) => a._bits.Equals(b._bits);
    public static bool operator !=(Binary a, Binary b) => !a._bits.Equals(b._bits);

    public static implicit operator Binary(byte[] bits) => new(bits);
    public static implicit operator Convert<Binary>(Binary bits) => new(bits);

    public override string ToString() => string.Join("", _bits);

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;

        if (obj is Binary binary)
        {
            if (binary._bits.Length != _bits.Length) return false;

            for (var i = 0; i < _bits.Length; i++)
                if (!_bits[i].Equals(binary._bits[i])) return false;

            return true;
        }
        if (obj is byte[] binaryAsBytes) return Equals(new Binary(binaryAsBytes));
        if (obj is char[] binaryAsChars) return Equals(TransformBits(binaryAsChars));
        if (obj is string binaryAsString) return Equals(TransformBits(binaryAsString));

        return false;
    }

    public override int GetHashCode() => _bits.GetHashCode();
}
