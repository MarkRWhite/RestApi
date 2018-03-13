namespace RestApi.Controllers
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Web;

	using RestApi.DataStore;
	using RestApi.Models;
	using RestApi.Services;

	/// <summary>
	///     Hosts the Rest server
	/// </summary>
	public class NoteController
	{
		#region Fields

		/// <summary>
		///     The Rest web service host
		/// </summary>
		private readonly WebServiceHost _webHost;

		/// <summary>
		///     Contains all <see cref="Note" /> objects
		/// </summary>
		private readonly IDataStore _dataStore;

		#endregion

		/// <summary>
		///     Creates a new instance of a NoteController to host the Rest Api service
		/// </summary>
		/// <param name="uri">The URI where the Rest Api should be hosted.</param>
		/// <param name="start">Denotes if the controller should start the service immediately</param>
		/// <param name="test">Denotes whether to run in test mode</param>
		public NoteController ( string uri, bool start = false, bool test = false )
		{
			this._dataStore = new MockDataStore( test );
			this._webHost = new WebServiceHost( new NoteService( this._dataStore ), new Uri( uri ) );

			if ( start )
			{
				this.Start();
			}
		}

		/// <summary>
		///     Start the Rest service
		/// </summary>
		public void Start ()
		{
			if ( this._webHost.State != CommunicationState.Opened )
			{
				try
				{
					this._webHost.Open();
					Console.WriteLine( "Starting Rest API service..." );
				}
				catch ( Exception ex )
				{
					Console.WriteLine( $"Exception encountered while attempting to start the Rest service.  {ex.Message}" );
				}
			}
		}

		/// <summary>
		///     Stop the Rest service
		/// </summary>
		public void Stop ()
		{
			if ( this._webHost.State != CommunicationState.Closed )
			{
				try
				{
					this._webHost.Close();
					Console.WriteLine( "Closing Rest API service." );
				}
				catch ( Exception ex )
				{
					Console.WriteLine( $"Exception encountered while attempting to stop the Rest service.  {ex.Message}" );
				}
			}
		}
	}
}