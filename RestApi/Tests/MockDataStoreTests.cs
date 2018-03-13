namespace RestApi.Tests
{
	using System;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using RestApi.DataStore;
	using RestApi.Models;

	/// <summary>
	///     Tests for the <see cref="MockDataStore" /> Interface
	/// </summary>
	[TestClass]
	public class MockDataStoreTests
	{
		#region Fields

		/// <summary>
		///     A random number generator used to create test data
		/// </summary>
		private static readonly Random _random = new Random();

		/// <summary>
		///     A Test DataStore
		/// </summary>
		private IDataStore DataStore { get; set; }

		#endregion

		#region Tests

		[TestInitialize]
		public void Setup ()
		{
			// Generate mock data
			this.DataStore = new MockDataStore();
			for ( var i = 0; i < _random.Next( 1, 20 ); i++ )
			{
				this.DataStore.StoreNote( new Note( true ) );
			}
		}

		/// <summary>
		///     Validate that a note can be retrieved from the data store
		/// </summary>
		[TestMethod]
		public void GetNoteTest ()
		{
			// Validate missing note returns nothing
			var testId = _random.Next( 100, 1000 ); // Generate random noteId
			Note note = null;
			note = this.DataStore.GetNote( testId );

			Assert.IsNull( note );

			// Store a note with the selected Id
			this.DataStore.StoreNote( testId, new Note( true ) );
			note = this.DataStore.GetNote( testId );

			Assert.IsNotNull( note );
		}

		/// <summary>
		///     Validate that all notes can be retrieved from the data store
		/// </summary>
		[TestMethod]
		public void GetNotesTest ()
		{
			var notes = this.DataStore.GetNotes();
			Assert.IsNotNull( notes );
		}

		/// <summary>
		///     Validate that a note can be stored in the data store
		/// </summary>
		[TestMethod]
		public void StoreNoteTest ()
		{
			var testId = _random.Next( 100, 1000 ); // Generate random noteId
			var testNote = new Note( true );

			// Store the testNote
			this.DataStore.StoreNote( testId, testNote );
			var resultNote = this.DataStore.GetNote( testId );

			Assert.AreEqual( testNote, resultNote );
		}

		/// <summary>
		///     Validate that a note can be updated in the data store
		/// </summary>
		[TestMethod]
		public void UpdateNoteTest ()
		{
		}

		/// <summary>
		///     Validate that a note can be deleted from the data store
		/// </summary>
		[TestMethod]
		public void DeleteNoteTest ()
		{
		}

		/// <summary>
		///     Validate that all notes can be cleared from the data store
		/// </summary>
		[TestMethod]
		public void DeleteNotesTest ()
		{
		}

		#endregion
	}
}