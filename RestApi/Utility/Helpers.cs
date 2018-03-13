namespace RestApi.Utility
{
	using System;
	using System.Text;

	/// <summary>
	///     Contains helper methods used throughout the program
	/// </summary>
	public static class Helpers
	{
		#region Fields

		/// <summary>
		///     A random number generator used to create test data
		/// </summary>
		private static readonly Random _random = new Random();

		#endregion

		#region Static Methods

		/// <summary>
		///     Creates a string of random text of the specified length
		/// </summary>
		/// <returns>A random string of characters</returns>
		public static string GetRandomText ( int length )
		{
			const byte AsciiStart = 32; // Ascii character start
			const byte AsciiEnd = 127; // Ascii character end

			if ( length < 1 )
			{
				return string.Empty;
			}

			var results = new byte[length];
			for ( var i = 0; i < results.Length; i++ )
			{
				results[i] = (byte)_random.Next( AsciiStart, AsciiEnd );
			}

			return Encoding.ASCII.GetString( results );
		}

		/// <summary>
		///     Returns a random DateTime object
		/// </summary>
		/// <returns>The random DateTime</returns>
		public static DateTime GetRandomDate ()
		{
			var year = _random.Next( 1970, 2050 );
			var month = _random.Next( 1, 13 );
			var day = _random.Next( 1, 31 );
			return new DateTime( year, month, 1 ).AddDays( day ); // Random date
		}

		#endregion
	}
}