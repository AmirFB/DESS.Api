using System;

namespace Dess.Api.Helpers
{
	public static class DessDateTime
	{
		public static long JavascriptDate(this DateTime dateTime) =>
			(long) dateTime.
		Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))
			.TotalMilliseconds;
	}
}