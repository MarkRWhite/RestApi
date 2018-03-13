namespace RestApi.Services
{
	using System.Net;
	using System.ServiceModel;
	using System.ServiceModel.Web;

	using Newtonsoft.Json;

	using RestApi.DataStore;
	using RestApi.Models;

	/// <summary>
	///     A service that enables receiving and responding to REST requests
	/// </summary>
	[ServiceBehavior( InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single )]
	public class NoteService : INoteService
	{
		#region Fields

		/// <summary>
		///     Contains all <see cref="Note" /> objects
		/// </summary>
		private readonly IDataStore _dataStore;

		#endregion

		#region Constructors

		/// <summary>
		///     Creates a new isntance of a <see cref="NoteService" />
		/// </summary>
		public NoteService ( IDataStore dataStore )
		{
			this._dataStore = dataStore;
		}

		#endregion

		#region Service Implementation Methods

		/// <summary>
		///     Returns the note object with the specified Id from the DataStore
		/// </summary>
		/// <param name="id">The Note Id to lookup</param>
		/// <returns>The note with the specified Id</returns>
		public string GetNote ( string id )
		{
			int inputId;
			if ( int.TryParse( id, out inputId ) )
			{
				var resultNote = this._dataStore.GetNote( inputId );
				if ( resultNote == null )
				{
					throw new WebFaultException<string>( "Note Id does not exist", HttpStatusCode.NotFound );
				}

				return SerializeJson( resultNote );
			}

			throw new WebFaultException<string>( "Invalid Note Id format", HttpStatusCode.BadRequest );
		}

		/// <summary>
		///     Returns all notes from the DataStore
		/// </summary>
		/// <returns></returns>
		public string GetNotes ()
		{
			return SerializeJson( this._dataStore.GetNotes() );
		}

		#endregion

		#region Static Methods

		/// <summary>
		///     Create an object of the specified type from a JSON string
		/// </summary>
		/// <param name="json">The JSON string to deserialize</param>
		/// <returns>The Note created from the JSON string</returns>
		public static T DeserializeJson<T> ( string json )
		{
			return (T)JsonConvert.DeserializeObject( json, typeof(T) );
		}

		/// <summary>
		///     Create a JSON string from a <see cref="Note" />
		/// </summary>
		/// <param name="note">The Note to serialze</param>
		/// <returns>The serialzed JSON string</returns>
		public static string SerializeJson ( Note note )
		{
			return JsonConvert.SerializeObject( note, Formatting.Indented );
		}

		/// <summary>
		///     Create a JSON string from an array of  <see cref="Note" />  objects
		/// </summary>
		/// <param name="notes">The Note array to serialze</param>
		/// <returns>The serialzed JSON string</returns>
		public static string SerializeJson ( Note[] notes )
		{
			return JsonConvert.SerializeObject( notes, Formatting.Indented );
		}

		#endregion
	}
}