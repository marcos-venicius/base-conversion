using Converter.Types;
using FluentAssertions;

namespace Converter.Tests.Types;

public sealed class BinaryTests
{
    [Fact]
    public void Should_Create_From_Char_List()
    {
        var binary = new Binary('1', '0', '1', '0');

        binary.ToString().Should().Be("1010");
    }

    [Fact]
    public void Should_Create_From_Bytes_List()
    {
        var binary = new Binary(1, 0, 1, 0);

        binary.ToString().Should().Be("1010");
    }

    [Fact]
    public void Should_Create_From_String()
    {
        var binary = new Binary("1010");

        binary.ToString().Should().Be("1010");
    }

    [Fact]
    public void Should_Convert_To_Integer()
    {
        var binary = new Binary("100010001");

        var result = binary.ToInteger();

        result.C.Should().BeOfType(typeof(Integer));
        result.C.Should().Be(new Integer(273));
        result.C.Should().Be(273);
    }

    [Fact]
    public void Two_Binaries_Should_Be_Comparable()
    {
        var binary1 = new Binary("100010001");
        var binary2 = new Binary("100010001");

        binary1.Should().Be(binary2);
        binary1.Should().Be("100010001");
        binary1.Should().Be(new char[] { '1', '0', '0', '0', '1', '0', '0', '0', '1' });
        binary1.Should().Be(new byte[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 });

        new Binary(1, 0).Should().NotBe(new Binary(1, 0, 0));
    }
}