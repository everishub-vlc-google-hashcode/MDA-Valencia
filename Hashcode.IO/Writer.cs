using System.IO;
using System.Threading.Tasks;

namespace Hashcode.IO
{
    public class Writer
    {
        public static async Task Write(Slide[] slides, Stream stream)
        {
            using (var writer = new StreamWriter(stream))
            {
                await writer.WriteLineAsync($"{slides.Length}");
                foreach (var slide in slides)
                {
                    if(slide is HorizontalSlide)
                    {
                        var h = slide as HorizontalSlide;
                        await writer.WriteLineAsync($"{h.PhotoA.Index}");
                    }
                    if (slide is VerticalSlide)
                    {
                        var v = slide as VerticalSlide;
                        await writer.WriteLineAsync($"{v.PhotoA.Index} {v.PhotoB.Index}");
                    }
                }
            }
        }
    }
}
