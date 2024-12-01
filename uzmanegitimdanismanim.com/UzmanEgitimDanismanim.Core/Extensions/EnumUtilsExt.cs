using System.ComponentModel;
using System.Reflection;
using UzmanEgitimDanismanim.Shared.Dtos.CustomDtos;

namespace UzmanEgitimDanismanim.Core.Extensions
{
    public static class EnumUtilsExt
    {
        /// <summary>
        ///     Bu fonksiyon kendisine verilen enum tipine göre enum id'lerini ve description bilgilerini alıp geriye selectmodel
        ///     list halinde döndürür
        ///     Genel olarak dropdownlist'ler için kullanılır
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<SelectModelDto> ConvertSelectModelList<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().Select(x => new SelectModelDto
            {
                Id = GetEnumNumber(x),
                Value = GetDescription(x)
            }).ToList();
        }

        public static int GetEnumNumber<T>(T enumValue)
        {
            return Convert.ToInt32(Convert.ChangeType(enumValue, ((Enum)(object)enumValue).GetTypeCode()));
        }

        public static T GetEnum<T>(int enumNumber)
        {
            var enumType = typeof(T);

            var value = (Enum)Enum.ToObject(enumType, enumNumber);
            if (Enum.IsDefined(enumType, value) == false)
                throw new NotSupportedException("Unable to convert value from database to the type: " + enumType);

            return (T)(object)value;
        }

        public static T GetEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static string GetDescription<T>(T value)
        {
            var enumType = typeof(T);

            var memberInfo = enumType.GetMember(value.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                var attribute = memberInfo[0].GetCustomAttribute(typeof(DescriptionAttribute), false);

                if (attribute != null) return ((DescriptionAttribute)attribute).Description;
            }

            return null;
        }

        public static string GetDescriptionById<T>(int enumNumber)
        {
            var enumEntity = GetEnum<T>(enumNumber);

            return GetDescription(enumEntity);
        }
    }
}
