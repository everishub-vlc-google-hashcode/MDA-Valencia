﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Hashcode.IO
{
    public class Photo
    {
        public int Index { get; set; }

        public  Orientation orientation { get; set; }

        public int NumTags { get; set; }

        public string[] Tags { get; set; }
    }

    public enum Orientation
    {
        H,V
    }
}