namespace RestApi
{
	using System;

	using RestApi.Controllers;
	using RestApi.Utility;

	/// <summary>
	///     This program controls the Rest API server
	/// </summary>
	internal class Program
	{
		#region Fields

		/// <summary>
		///     Denotes if the program is running
		/// </summary>
		private static bool _running = true;

		#endregion

		#region Main

		/// <summary>
		///     Main Program entry point
		/// </summary>
		/// <param name="args"></param>
		private static void Main ( string[] args )
		{
			var controller = new NoteController( RestApiConstants.Uri );

			Console.WriteLine( "Rest API command line control." );

			while ( _running )
			{
				// Listen for commands
				CommandType input;
				if ( Enum.TryParse( Console.ReadLine(), true, out input ) )
				{
					switch ( input )
					{
						case CommandType.Start:
							controller.Start();
							break;

						case CommandType.Stop:
							controller.Stop();
							break;

						case CommandType.Cls:
							Console.Clear();
							break;

						case CommandType.Exit:
							_running = false;
							break;
					}
				}
				else
				{
					Console.WriteLine( "Command not recognized. Try: start, stop, cls, or exit." );
				}
			}
		}

		#endregion
	}
}