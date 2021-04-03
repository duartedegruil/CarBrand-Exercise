namespace CarBrandAPI.Utilities
{
    public static class Extensions
    {
		/// <summary>
		/// Indicates whether a specified string is null, empty, or consists only of white-space characters.
		/// </summary>
		/// <param name="text">The string to test.</param>
		/// <returns>true if the value parameter is null or System.String.Empty, or if value consists exclusively of white-space characters.</returns>
		public static bool IsNullOrWhiteSpace(this string text)
		{
			return string.IsNullOrWhiteSpace(text);
		}
	}
}
