using System;
using System.Collections;
using System.Text;

namespace NameFix.AppCode
{
	public sealed class Utils
	{
		private Utils() {}

		public static DateTime ShiftDateTime(DateTime dtToShift, int byHours)
		{
			return dtToShift.AddHours(byHours);
		}

		public static DateTime ShiftDateTime(DateTime dtToShift, DateTime dtShiftAmount)
		{
			return ShiftDateTime(dtToShift, dtShiftAmount, true);
		}

		public static DateTime ShiftDateTime(DateTime dtToShift, DateTime dtShiftAmount, bool hoursOnly)
		{
			if(hoursOnly)
				dtShiftAmount = new DateTime(1, 1, 1, dtShiftAmount.Hour, dtShiftAmount.Minute, dtShiftAmount.Second);
			var ts = dtShiftAmount - DateTime.MinValue;
			return dtToShift.Add(ts);
		}

		public static string ByteArrToStr(byte[] v)
		{
			var sb = new StringBuilder();
			for(var i = 0; i < v.Length; i++)
			{
				if(i >= v.Length)
					break;
				var c = (char)v[i];

				if(c == 0x00)
					break;

				sb.Append((c < 0x20 ? "." : c.ToString()));
			}
			return sb.ToString();
		}

		#region Implode

		public static string Implode(string glue, IEnumerable items, string propertyName, string wrapper)
		{
			var sb = new StringBuilder();

			var enumerator = items.GetEnumerator();
			while(enumerator.MoveNext())
			{
				object val;
				if(!string.IsNullOrEmpty(propertyName))
				{
					val = enumerator.Current.GetType().GetProperty(propertyName).GetValue(enumerator.Current, null);
				}
				else
				{
					val = enumerator.Current;
				}

				var value = (val ?? string.Empty).ToString();

				if(!string.IsNullOrEmpty(wrapper))
				{
					value = wrapper + value + wrapper;
				}

				sb.Append(value);
				sb.Append(glue);
			}
			if(sb.Length >= glue.Length)
			{
				sb.Length = sb.Length - glue.Length;
			}

			return sb.ToString();
		}

		public static string Implode(string glue, IEnumerable items)
		{
			return Implode(glue, items, null, null);
		}

		#endregion Implode
	}
}