namespace RestApi.DataStore
{
	using RestApi.Models;

	/// <summary>
	///     Defines the basic structure for storing and retrieving notes
	/// </summary>
	public interface IDataStore
	{
		/// <summary>
		///     Returns the note object with the specified Id from the DataStore
		/// </summary>
		/// <param name="id">The Note Id to lookup</param>
		/// <returns>The note with the specified Id</returns>
		Note GetNote ( int id );

		/// <summary>
		///     Returns all notes from the DataStore
		/// </summary>
		/// <returns>An array of all stored Notes</returns>
		Note[] GetNotes ();

		/// <summary>
		///     Stores a note in the DataStore
		/// </summary>
		/// <param name="note">The Note object to be stored</param>
		void StoreNote ( Note note );

		/// <summary>
		///     Stores a note in the DataStore
		/// </summary>
		/// <param name="id">The note Id</param>
		/// <param name="note">The Note object to be stored</param>
		void StoreNote ( int id, Note note );

		/// <summary>
		///     Update a note in the DataStore
		/// </summary>
		/// <param name="id">The note Id</param>
		/// <param name="note">The Note object to be stored</param>
		void UpdateNote(int id, Note note);

		/// <summary>
		///     Deletes the specified note from the DataStore
		/// </summary>
		/// <param name="id">The note to be deleted</param>
		void DeleteNote ( int id );

		/// <summary>
		///     Deletes all stored Notes in the DataStore
		/// </summary>
		void DeleteNotes ();
	}
}