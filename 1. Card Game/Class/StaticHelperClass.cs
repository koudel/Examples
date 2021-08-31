using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CardGame.Enum;

namespace CardGame.Class
{
    public static class StaticHelperClass
    {
        private static Random rng = new Random();

        public static string GetFileNamePart<E>(this E value) where E : System.Enum
        {
            return ((DescriptionAttribute)Attribute.GetCustomAttribute(
                value.GetType().GetFields(BindingFlags.Public | BindingFlags.Static)
                    .Single(x => x.GetValue(null).Equals(value)),
                typeof(DescriptionAttribute)))?.Description ?? value.ToString();
        }

        public static CardColorEnum GetCardColor(this CardTypeEnum cardType)
        {
            switch (cardType)
            {
                case CardTypeEnum.Hearts:
                case CardTypeEnum.Diamonds:
                    return CardColorEnum.Red;
                default:
                    return CardColorEnum.Black;
            }
        }

        public static List<T> Shuffle<T>(this List<T> list) where T : class
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }
    }
}
