using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Hashcode.IO
{
    public class Reader
    {
        public static async Task<ReadedDto[]> Read(Stream input)
        {
            var dtos = new List<ReadedDto>();
            using (var reader = new StreamReader(input))
            {
                while (!reader.EndOfStream)
                {

                    var line = await reader.ReadLineAsync();
                    var split = line.Split(' ');
                    var dto = new ReadedDto()
                    {
                        p0 = split[0],
                        p1 = split[1],
                    };
                    dtos.Add(dto);
                }
            }

            return dtos.ToArray();
        }
    }
}
