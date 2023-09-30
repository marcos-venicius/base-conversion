using Converter;
using Converter.Types;

internal class Program
{
    private static void Main()
    {
        var integer = new Integer(10);

        Console.WriteLine("\nUsing Integer class\n");

        Console.WriteLine($"{integer} \t-[binary]-> \t\t{integer.ToBinary()}");

        Console.WriteLine("\nUsing Binary class\n");

        var binary1 = new Binary(1, 0, 1, 0);
        var binary2 = new Binary('1', '0', '1', '0');
        var binary3 = new Binary("1010");

        Console.WriteLine($"{binary1} \t-[int]-> \t\t{binary1.ToInteger()}");
        Console.WriteLine($"{binary2} \t-[int]-> \t\t{binary2.ToInteger()}");
        Console.WriteLine($"{binary3} \t-[int]-> \t\t{binary3.ToInteger()}");

        Console.WriteLine("\nUsing Convert:\n");

        Convert<Binary> binaryConvert = binary1;

        Console.WriteLine($"{binaryConvert} \t-[int]-> \t\t{binaryConvert.C.ToInteger()}");
        Console.WriteLine($"{binaryConvert} \t-[int]-[binary]-> \t{binaryConvert.C.ToInteger().C.ToBinary()}");

        Console.WriteLine("\nCreating Convert from scratch:\n");

        var convert = new Convert<Integer>(2023);

        Console.WriteLine($"{convert} \t-[binary]-> \t\t{convert.C.ToBinary()}\n");
    }
}