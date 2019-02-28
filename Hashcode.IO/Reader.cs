using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace Hashcode.IO
{
    public class Reader
    {
        public static async Task<Photo[]> Read(Stream input)
        {
           
            using (var reader = new StreamReader(input))
            {
                var line = reader.ReadLine();
                var numPhotos = int.Parse(line);
                var photos = new Photo[numPhotos];
                for (var i = 0;i<numPhotos;i++)
                {

                    line = await reader.ReadLineAsync();
                    var split = line.Split(' ');
                    var photo = new Photo()
                    {
                        Index = i,
                        orientation = split[0] == "H" ? Orientation.H : Orientation.V,
                        NumTags = int.Parse(split[1]),
                        Tags = split.Skip(2).ToArray()
                    };
                    photos[i] = photo;
                }
                return photos;
            }
            
        }
    }
}
