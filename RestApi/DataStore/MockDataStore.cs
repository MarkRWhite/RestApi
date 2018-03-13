namespace RestApi.DataStore
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using RestApi.Models;

	/// <summary>
	///     This represents a mock data store used to simulate the storing of <see cref="Note" /> objects
	/// </summary>
	public class MockDataStore : IDataStore
	{
		#region Fields

		/// <summary>
		///     Contains all stored Note objects
		/// </summary>
		private readonly Dictionary<int, Note> _notes;

		/// <summary>
		///     Controls access to the MockDataStore
		/// </summary>
		private readonly object _lock = new object();

		/// <summary>
		///     A random number generator used to create test data
		/// </summary>
		private static readonly Random _random = new Random();

		#endregion

		#region Constructors

		/// <summary>
		///     Creates a new instance of the mock data store
		/// </summary>
		public MockDataStore ()
		{
			this._notes = new Dictionary<int, Note>();
		}


		/// <summary>
		/// Test constructor for MockDataStore
		/// </summary>
		/// <param name="test">If the MockDataStore should generate test data</param>
		public MockDataStore ( bool test = false )
			: this()
		{
			if ( test )
			{
				// Generate random test Notes
				for ( var i = 0; i < _random.Next( 0, 20 ); i++ )
				{
					this._notes.Add( i, new Note( true ) );
				}
			}
		}

		#endregion

		#region Public Methods

		/// <summary>
		///     Returns the note object with the specified Id from the DataStore
		/// </summary>
		/// <param name="id"></param>
		/// <returns>The note with the specified Id</returns>
		public Note GetNote ( int id )
		{
			lock ( this._lock )
			{
				if ( this._notes.ContainsKey( id ) )
				{
					return this._notes[id];
				}

				return null;
			}
		}

		/// <summary>
		///     Returns all notes from the DataStore
		/// </summary>
		/// <returns>An array of all stored Notes</returns>
		public Note[] GetNotes ()
		{
			lock ( this._lock )
			{
				return this._notes.Values.ToArray();
			}
		}

		/// <summary>
		///     Stores a note in the DataStore using the next available Id
		/// </summary>
		/// <param name="note">The Note object to be stored</param>
		public void StoreNote ( Note note )
		{
			lock ( this._lock )
			{
				var nextId = 0;
				if ( this._notes.Count > 0 )
				{
					nextId = this._notes.Keys.Max() + 1;
				}

				this._notes.Add( nextId, note );
			}
		}

		/// <summary>
		///     Stores a note in the DataStore by Id
		/// </summary>
		/// <param name="id">The note Id</param>
		/// <param name="note">The Note object to be stored</param>
		public void StoreNote ( int id, Note note )
		{
			lock ( this._lock )
			{
				if ( !this._notes.ContainsKey( id ) )
				{
					this._notes.Add( id, note );
				}
			}
		}

		/// <summary>
		///     Updates a note in the DataStore by Id
		/// </summary>
		/// <param name="id">The note Id</param>
		/// <param name="note">The Note object to be updated</param>
		public void UpdateNote ( int id, Note note )
		{
			lock ( this._lock )
			{
				if ( this._notes.ContainsKey( id ) )
				{
					this._notes[id] = note;
				}
			}
		}

		/// <summary>
		///     Deletes the specified note from the DataStore
		/// </summary>
		/// <param name="id">The note to be deleted</param>
		public void DeleteNote ( int id )
		{
			lock ( this._lock )
			{
				if ( this._notes.ContainsKey( id ) )
				{
					this._notes[id] = null;
				}
			}
		}

		/// <summary>
		///     Deletes all stored Notes in the DataStore
		/// </summary>
		public void DeleteNotes ()
		{
			lock ( this._lock )
			{
				this._notes.Clear();
			}
		}

		#endregion
	}
}