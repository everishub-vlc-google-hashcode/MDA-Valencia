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
        public static Slide[] Calculate(AlbumPhoto album)
        {
            var posibleSlides = GenerateSlides(album);
            var scores = CalculateScores(posibleSlides);
            var bestSlides = FindBestSlides(scores);

            return bestSlides;
        }
        private static List<Slide> GenerateSlides(AlbumPhoto album)
        {
            var slides = album.Horizontals
                 .Select(h => new HorizontalSlide
                 {
                     PhotoA = h
                 }).ToList<Slide>();
            
            for (int i = 0; i < album.Verticals.Count; i++)
            {
                for (int j = i; j < album.Verticals.Count; j++)
                {
                    var vs = new VerticalSlide
                    {
                        PhotoA = album.Verticals[i],
                        PhotoB = album.Verticals[j]
                    };
                    slides.Add(vs);
                }
            }

            return slides;
        }

        private static List<Score> CalculateScores(List<Slide> posibleSlides)
        {
            var scores = new List<Score>();
            for (int i = 0; i < posibleSlides.Count; i++)
            {
                for (int j = i+1; j < posibleSlides.Count; j++)
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

            return scores;
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
            if (slideA is VerticalSlide && slideB is VerticalSlide)
            {
                return !slideA.Indexes().Any(aix => slideB.Indexes().Contains(aix));
            }

            return true;

        }

        private static Slide[] FindBestSlides(Score[] scores)
        {
            return new Slide[0];
        }

       


    }
}
