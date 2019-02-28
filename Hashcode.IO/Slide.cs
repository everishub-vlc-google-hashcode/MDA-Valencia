using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Hashcode.IO
{
    public abstract class Slide
    {
        public abstract string[] Tags();
        public abstract int[] Indexes();
    }

    public class VerticalSlide : Slide
    {
        public Photo PhotoA { get; set; }

        public Photo PhotoB { get; set; }

        public override int[] Indexes()
        {
            return new[] { PhotoA.Index, PhotoB.Index };
        }

        public override string[] Tags()
        {
            return PhotoA.Tags.Union(this.PhotoB.Tags).ToArray();
        }
    }

    public class HorizontalSlide : Slide
    {
        public Photo PhotoA { get; set; }

        public override string[] Tags()
        {
            return this.PhotoA.Tags;
        }

        public override int[] Indexes()
        {
            return new[] { PhotoA.Index};
        }
    }

    public class Score
    {
        public int Points { get; set; }
        public Slide A { get; set; }
        public Slide B { get; set; }
    }
}
