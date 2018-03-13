namespace RestApi.Tests
{
	using System;
	using System.Linq;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using RestApi.Models;
	using RestApi.Services;

	/// <summary>
	///     Tests for the <see cref="Note" /> object
	/// </summary>
	[TestClass]
	public class NoteTests
	{
		#region Fields

		/// <summary>
		///     A random number generator used to create test data
		/// </summary>
		private static readonly Random _random = new Random();

		#endregion

		#region Tests

		/// <summary>
		///     Serialize a note, then deserialze and validate they are equal
		/// </summary>
		[TestMethod]
		public void SerializationTest ()
		{
			// Serialize and deserialize a Note
			var testNote = new Note( true );
			var data = NoteService.SerializeJson( testNote );
			var resultNote = NoteService.DeserializeJson<Note>( data );

			Assert.AreEqual( testNote, resultNote );

			// Serialize and deserialize a Note array
			var testNotes = new Note[_random.Next( 0, 20 )];
			for ( var i = 0; i < testNotes.Length; i++ )
			{
				testNotes[i] = new Note( true );
			}

			data = NoteService.SerializeJson( testNotes );
			var resultNotes = NoteService.DeserializeJson<Note[]>( data );

			Assert.IsTrue( testNotes.SequenceEqual( resultNotes ) );
		}

		#endregion
	}
}