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
    }
}
