﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TNBase.Objects
{
    // Valid titles.
    public static class ListenerTitles
    {
        public const string MR = "Mr";
        public const string MS = "Ms";
        public const string MRS = "Mrs";
        public const string MISS = "Miss";
        public const string SIR = "Sir";
        public const string DOCTOR = "Doctor";
        public const string MASTER = "Master";
        public const string PROFESSOR = "Professor";
        public const string REV = "Rev";
        public const string LADY = "Lady";
        public const string LORD = "Lord";

        public static List<String> getAllTitles() {
            return new List<String>() { MR, MS, MRS, MISS, SIR, DOCTOR, MASTER, PROFESSOR, REV, LADY, LORD };    
        }
    }
}