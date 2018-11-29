using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Puzzle.Infrastructure
{
    public static class Extensions
    {
        public static decimal Percent(this decimal number,int percent)
        {
            //return ((decimal) 80         *       25)/100;
            return ((decimal)number * percent) / 100;
        }

        public static decimal AddPercent(this decimal number,int percent)
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


        /// <summary>
        /// taken from my favourite package --> https://www.nuget.org/packages/ExtensionMinder/
        /// </summary>
        /// <param name="enumerationValue"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum enumerationValue)
        {
            if (enumerationValue == null)
                return null;
            var attributes =
                (DescriptionAttribute[])
                enumerationValue.GetType()
                    .GetField(enumerationValue.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : enumerationValue.ToString();
        }
    }
}
