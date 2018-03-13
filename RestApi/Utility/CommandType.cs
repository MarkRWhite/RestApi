namespace RestApi.Utility
{
	/// <summary>
	/// Defines all possible command line commands
	/// </summary>
	public enum CommandType
	{
		/// <summary>
		///     Start the Rest API
		/// </summary>
		Start,

		/// <summary>
		///     Stop the Rest API
		/// </summary>
		Stop,

		/// <summary>
		///     Clear the Console screen
		/// </summary>
		Cls,

		/// <summary>
		///     Exit the command line utility
		/// </summary>
		Exit
	}
}