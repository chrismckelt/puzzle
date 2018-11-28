﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Puzzle.Infrastructure
{
    public static class Extensions
    {
        public static double Percent(this double number,int percent)
        {
            //return ((double) 80         *       25)/100;
            return ((double)number * percent) / 100;
        }

        public static double AddPercent(this double number,int percent)
        {
            return number + number.Percent(percent);
        }

        public static T DeepClone<T>(this T obj)
        {
            T objResult;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, obj);
                ms.Position = 0;
                objResult = (T)bf.Deserialize(ms);
            }
            return objResult;
        }
    }
}
