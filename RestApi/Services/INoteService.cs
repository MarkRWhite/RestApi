namespace RestApi.Services
{
	using System.ServiceModel;
	using System.ServiceModel.Web;

	/// <summary>
	///     Defines the service actions
	/// </summary>
	[ServiceContract( Name = "RestApi" )]
	public interface INoteService
	{
		/// <summary>
		///     Returns the note object with the specified Id from the DataStore
		/// </summary>
		/// <param name="id">The Note Id to lookup</param>
		/// <returns>The note with the specified Id</returns>
		[OperationContract]
		[WebGet( UriTemplate = "/notes/{id}" )]
		string GetNote ( string id );

		/// <summary>
		///     Returns all notes from the DataStore
		/// </summary>
		/// <returns></returns>
		[OperationContract]
		[WebGet( UriTemplate = "/notes" )]
		string GetNotes ();

		/// <summary>
		///     Store a new note in the DataStore
		/// </summary>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke( UriTemplate = "/notes/add", Method = "POST", RequestFormat = WebMessageFormat.Json )]
		string StoreNote ();

		/// <summary>
		///     Updates an existing Note in the DataStore
		/// </summary>
		/// <param name="id">The Id of the note to be updated</param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke( UriTemplate = "/notes/update/{id}", Method = "PATCH", RequestFormat = WebMessageFormat.Json )]
		string UpdateNote ( string id );
	}
}