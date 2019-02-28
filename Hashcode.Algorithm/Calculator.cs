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
            var scores = new List<Score>();
            for (int i = 0; i < posibleSlides.Length; i++)
            {
                for (int j = i+1; j < posibleSlides.Length; j++)
                {
                    var slideA = posibleSlides[i];
                    var slideB = posibleSlides[j];
                    var score = CalculateScore(slideA, slideB);
                    if(score > 0)
                    {
                        scores.Add(new Score {
                            Points = score,
                            A = slideA,
                            B = slideB
                        });
                        scores.Add(new Score
                        {
                            Points = score,
                            A = slideB,
                            B = slideA
                        });
                    }
                }
            }

            return scores.ToArray();
        }

        private static int CalculateScore(Slide slideA, Slide slideB)
        {
            if (!CanCompareSlides(slideA, slideB))
            {
                return -1;
            }

            var left = slideA.Tags().Except(slideB.Tags()).Count();
            var intersect = slideA.Tags().Intersect(slideB.Tags()).Count();
            var right = slideB.Tags().Except(slideA.Tags()).Count();
            var values = new[] { left, intersect, right };
            return values.Min();
        }

        private static bool CanCompareSlides(Slide slideA, Slide slideB)
        {
            return !slideA.Indexes().Any(aix => slideB.Indexes().Contains(aix));
        }

        private static Slide[] FindBestSlides(Score[] scores)
        {
            throw new NotImplementedException();
        }

       


    }
}
