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
		[OperationContract]
		[WebGet( UriTemplate = "/notes/{id}" )]
		string GetNote ( string id );

		[OperationContract]
		[WebGet( UriTemplate = "/notes" )]
		string GetNotes ();
	}
}