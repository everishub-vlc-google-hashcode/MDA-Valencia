using System.IO;
using System.Threading.Tasks;
using Hashcode.Algorithm;
using Hashcode.IO;

namespace Algorithm
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var input = await Reader.Read(File.OpenRead("a_example.txt"));
            var output = await Calculator.Calculate(input);
            await Writer.Write(output, File.OpenWrite("a_example_output.txt"));
        }
    }
}
