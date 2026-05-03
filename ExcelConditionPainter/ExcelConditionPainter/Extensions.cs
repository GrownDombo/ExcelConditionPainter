using System;
using System.ComponentModel;
using System.Reflection;

namespace ExcelConditionPainter
{
    /// <summary>
    /// enum 설명 문자열처럼 공통으로 쓰는 확장 메서드 모음입니다.
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// enum 값의 DescriptionAttribute가 있으면 설명을, 없으면 이름을 반환합니다.
        /// </summary>
        public static string GetDescription(this Enum value)
        {
            // enum 값에 해당하는 필드 정보입니다.
            FieldInfo fi = value.GetType().GetField(value.ToString());
            // DescriptionAttribute 목록입니다.
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
