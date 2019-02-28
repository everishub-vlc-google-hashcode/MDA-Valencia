using System;
using System.Diagnostics;
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
            var watch = new Stopwatch();
            watch.Start();
            var photos = await Reader.Read(File.OpenRead("a_example.txt"));
            var slides = Calculator.Calculate(photos);
            await Writer.Write(slides, File.OpenWrite("a_example_output.txt"));
            watch.Stop();
            Console.WriteLine($"Elapsed: {watch.ElapsedMilliseconds/1000.0}");
            Console.ReadLine();
        }
    }
}
