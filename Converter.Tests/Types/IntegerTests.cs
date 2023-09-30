using Converter.Types;
using FluentAssertions;

namespace Converter.Tests.Types;

public sealed class IntegerTests
{
    [Fact]
    public void Should_Create_From_Integer()
    {
        var integer = new Integer(10);

        integer.ToString().Should().Be("10");
    }

    [Fact]
    public void Should_Convert_To_Binary()
    {
        var integer = new Integer(273);

        var result = integer.ToBinary();

        result.C.Should().BeOfType(typeof(Binary));
        result.C.Should().Be(new Binary("100010001"));
    }

    [Fact]
    public void Two_Binaries_Should_Be_Comparable()
    {
        var integer1 = new Integer(10);
        var integer2 = new Integer(10);

        integer1.Should().Be(integer2);
        integer1.Should().Be(10);

        new Integer(10).Should().NotBe(new Integer(100));
    }
}