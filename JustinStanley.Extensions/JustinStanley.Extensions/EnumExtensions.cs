using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace JustinStanley.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// extension method for Enum - returns a list of string values.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static List<string> EnumToListOfString(this Enum e)
        {
            return Enum.GetNames(e.GetType()).ToList();
        }

        /// <summary>
        /// returns a list of string values for an enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<string> EnumToListOfString<T>() where T : IConvertible
        {
            Type enumType = typeof(T);
            // Can't use type constraints on value types, so have to do check like this
            if (enumType.BaseType != typeof(Enum))
            {
                throw new ArgumentException("T must be of type System.Enum");
            }
            else
            {
                return Enum.GetNames(enumType).ToList();

            }
        }

        /// <summary>
        /// returns a dictionary for a given enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Dictionary<int, string> EnumToDictionary<T>() where T : IConvertible
        {
            Type enumType = typeof(T);
            // Can't use type constraints on value types, so have to do check like this
            if (enumType.BaseType != typeof(Enum))
            {
                throw new ArgumentException("T must be of type System.Enum");
            }

            return Enum.GetValues(enumType).Cast<int>().ToDictionary(x => x, x => Enum.GetName(enumType, x));
        }

        /// <summary>
        /// returns a dictionary for a given enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Dictionary<int, string> EnumToDictionary(this Enum e)
        {
            return Enum.GetValues(e.GetType()).Cast<int>().ToDictionary(x => x, x => Enum.GetName(e.GetType(), x));
        }

        /// <summary>
        /// Retrieves an enums from the  <see cref="System.ComponentModel.Description"/>. 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumDescription(this Enum value)
        {
            System.Reflection.FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        /// <summary>
        /// will parse a string value into an Enum value. if string is not present in the Enm, will return the default enum value.
        /// NOTE: insure that the enum has a default value. else, 0 will be returned.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ParseEnum<T>(string value) where T : IConvertible
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value, true);
            }
            catch
            {
                return default(T);
            }
        }
        /// <summary>
        /// validates if an string value exists in the enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEnumValueValid<T>(this string value) where T : IConvertible
        {
            try
            {
                if (Enum.IsDefined(typeof(T), value))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
