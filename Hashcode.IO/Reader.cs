using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace Hashcode.IO
{
    public class Reader
    {
        public static async Task<AlbumPhoto> Read(Stream input)
        {
           var album = new AlbumPhoto();
            using (var reader = new StreamReader(input))
            {
                var line = reader.ReadLine();
                var numPhotos = int.Parse(line);
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
                    if (photo.orientation == Orientation.H)
                    {
                        album.Horizontals.Add(photo);
                    }
                    else
                    {
                        album.Verticals.Add(photo);
                    }
                }
                return album;
            }
            
        }
    }
}
