namespace RestApi.Tests
{
	using System.IO;
	using System.Net;
	using System.Text;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using RestApi.Controllers;
	using RestApi.Models;
	using RestApi.Services;
	using RestApi.Utility;

	/// <summary>
	///     Tests for the <see cref="NoteService" /> object
	/// </summary>
	[TestClass]
	public class ServiceTests
	{
		#region Setup

		/// <summary>
		///     Test setup
		/// </summary>
		[TestInitialize]
		public void Setup ()
		{
			// Start the controller in Test mode
			var controller = new NoteController( RestApiConstants.Uri, true, true );
		}

		#endregion

		#region Tests

		/// <summary>
		///     Retrieves a note from the DataStore
		/// </summary>
		[TestMethod]
		public void GetNoteTest ()
		{
			var requestUri = RestApiConstants.Uri + "/notes/0";
			var request = (HttpWebRequest)WebRequest.Create( requestUri );
			var response = (HttpWebResponse)request.GetResponse();

			var text = new StreamReader( response.GetResponseStream() ).ReadToEnd();

			// Deserialize response
			var result = NoteService.DeserializeJson<Note>( text );
		}

		/// <summary>
		///     Retrieves all notes from the DataStore
		/// </summary>
		[TestMethod]
		public void GetNotesTest ()
		{
			var requestUri = RestApiConstants.Uri + "/notes";
			var request = (HttpWebRequest)WebRequest.Create( requestUri );
			var response = (HttpWebResponse)request.GetResponse();

			var text = new StreamReader( response.GetResponseStream() ).ReadToEnd();

			// Deserialize response
			var results = NoteService.DeserializeJson<Note[]>( text );
		}

		/// <summary>
		///     Adds a new Note to the DataStore
		/// </summary>
		[TestMethod]
		public void AddNoteTest ()
		{
			// Setup Request
			var requestUri = RestApiConstants.Uri + "/notes/add";
			var request = (HttpWebRequest)WebRequest.Create( requestUri );
			request.Method = "POST";
			var writeStream = request.GetRequestStream();

			// Generate a random note
			var testNote = new Note( true );
			var jsonBytes = Encoding.ASCII.GetBytes( NoteService.SerializeJson( testNote ) );

			// Write Serialized Note to stream
			writeStream.Write( jsonBytes, 0, jsonBytes.Length );

			// Get Response
			var response = (HttpWebResponse)request.GetResponse();
			var text = new StreamReader( response.GetResponseStream() ).ReadToEnd();
		}

		/// <summary>
		///     Update a Note in the DataStore
		/// </summary>
		[TestMethod]
		public void UpdateNoteTest ()
		{
			// Setup Request
			var requestUri = RestApiConstants.Uri + "/notes/update/0";
			var request = (HttpWebRequest)WebRequest.Create( requestUri );
			request.Method = "PATCH";
			var writeStream = request.GetRequestStream();

			// Generate a random note
			var testNote = new Note( true );
			var jsonBytes = Encoding.ASCII.GetBytes( NoteService.SerializeJson( testNote ) );

			// Write Serialized Note to stream
			writeStream.Write( jsonBytes, 0, jsonBytes.Length );

			// Get Response
			var response = (HttpWebResponse)request.GetResponse();
			var text = new StreamReader( response.GetResponseStream() ).ReadToEnd();
		}

		#endregion
	}
}