using System.IO;
using System.Threading.Tasks;

namespace Hashcode.IO
{
    public class Writer
    {
        public static async Task Write(WritedDto[] input, Stream stream)
        {
            using (var writer = new StreamWriter(stream))
            {
                await writer.WriteLineAsync($"{input.Length}");
                foreach (var dto in input)
                {
                    await writer.WriteLineAsync($"{dto.p0} {dto.p1}");
                }
            }
        }
    }
}
