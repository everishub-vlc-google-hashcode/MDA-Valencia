using Hashcode.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Hashcode.Algorithm
{
    public class Calculator
    {
        public static Slide[] Calculate(Photo[] photos)
        {
            var posibleSlides = GenerateSlides(photos);
            var scores = CalculateScores(posibleSlides);
            var bestSlides = FindBestSlides(scores);

            return bestSlides;
        }
        private static Slide[] GenerateSlides(Photo[] photos)
        {
            var hp = photos
                 .Where(h => h.orientation == Orientation.H);
            var slides = hp
                 .Select(h => new HorizontalSlide
                 {
                     PhotoA = h
                 }).ToList<Slide>();

            var vp = photos
                 .Where(h => h.orientation == Orientation.V).ToArray();
            for (int i = 0; i < vp.Length; i++)
            {
                for (int j = i; j < vp.Length; j++)
                {
                    var vs = new VerticalSlide
                    {
                        PhotoA = vp[i],
                        PhotoB = vp[j]
                    };
                    slides.Add(vs);
                }
            }

            return slides.ToArray();
        }

        private static Score[] CalculateScores(Slide[] posibleSlides)
        {
            throw new NotImplementedException();
        }

        private static Slide[] FindBestSlides(Score[] scores)
        {
            throw new NotImplementedException();
        }

       


    }
}
