using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenRasta.Codecs.Spark.Configuration
{
	public static class MissingEnumerableExtensions
	{
		public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
		{
			foreach (var item in enumerable)
			{
				action(item);
			}
		}
	}
}