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
            var album = await Reader.Read(File.OpenRead("e_shiny_selfies.txt"));
            var slides = Calculator.Calculate(album);
            await Writer.Write(slides, File.OpenWrite("e_shiny_selfies_output.txt"));
            watch.Stop();
            Console.WriteLine($"Elapsed: {watch.ElapsedMilliseconds/1000.0}");
            Console.ReadLine();
        }
    }
}
