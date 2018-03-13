namespace RestApi.Models
{
	using System;

	using RestApi.Utility;

	/// <summary>
	///     This class defines the structure of a Note
	/// </summary>
	[Serializable]
	public class Note : IEquatable<Note>
	{
		#region Fields

		/// <summary>
		///     A random number generator used to create test data
		/// </summary>
		private static readonly Random _random = new Random();

		#endregion

		#region Constructors

		/// <summary>
		///     Create a new instance of a note
		/// </summary>
		public Note ()
		{
			this.Title = string.Empty;
			this.Description = string.Empty;
		}

		/// <summary>
		///     Test constructor
		/// </summary>
		/// <param name="test"></param>
		public Note ( bool test = false )
			: this()
		{
			if ( test )
			{
				// Generate random test data
				this.Title = Helpers.GetRandomText( _random.Next( 0, 40 ) );
				this.Description = Helpers.GetRandomText( _random.Next( 0, 100 ) );
				this.DueDate = Helpers.GetRandomDate();
			}
		}

		/// <summary>
		///     Create a new instance of a note by passing property values
		/// </summary>
		/// <param name="title">Defines the note Title</param>
		/// <param name="description">Defines the note Description</param>
		/// <param name="dueDate">Defines the due date for the note</param>
		public Note ( string title, string description, DateTime dueDate )
		{
			this.Title = title;
			this.Description = description;
			this.DueDate = dueDate;
		}

		#endregion

		#region Properties

		/// <summary>
		///     Defines the note Title
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		///     Defines the note Description
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		///     Defines the due date for the note
		/// </summary>
		public DateTime DueDate { get; set; }

		#endregion

		#region Public Methods

		/// <summary>
		///     Compares equality between Note objects
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public bool Equals ( Note other )
		{
			if ( ReferenceEquals( null, other ) )
			{
				return false;
			}
			if ( ReferenceEquals( this, other ) )
			{
				return true;
			}
			return this == other;
		}

		/// <summary>
		///     Compares equality between Note objects
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals ( object obj )
		{
			if ( ReferenceEquals( null, obj ) )
			{
				return false;
			}
			if ( ReferenceEquals( this, obj ) )
			{
				return true;
			}
			if ( obj.GetType() != this.GetType() )
			{
				return false;
			}
			return this.Equals( (Note)obj );
		}

		/// <summary>
		///     Calculates a unique hash for this object's properties
		/// </summary>
		/// <returns>A unique hash to represent this object's properties</returns>
		public override int GetHashCode ()
		{
			var hash = 722639;
			hash += this.Title != null ? this.Title.GetHashCode() : 0;
			hash += this.Description != null ? this.Description.GetHashCode() : 0;
			hash += this.DueDate != null ? this.DueDate.GetHashCode() : 0;
			return hash;
		}

		/// <summary>
		///     Determines Equality for two <see cref="Note" /> objects
		/// </summary>
		/// <param name="a">A note object to be compared</param>
		/// <param name="b">A note object to be compared</param>
		/// <returns></returns>
		public static bool operator == ( Note a, Note b )
		{
			// Check for equal reference
			if ( ReferenceEquals( a, b ) )
			{
				return true;
			}

			// Check for a null object
			if ( (object)a == null || (object)b == null )
			{
				return false;
			}

			// Compare properties
			return string.Equals( a.Title, b.Title ) && string.Equals( a.Description, b.Description ) && a.DueDate == b.DueDate;
		}

		/// <summary>
		///     Determines Inequality for two <see cref="Note" /> objects
		/// </summary>
		/// <param name="a">A note object to be compared</param>
		/// <param name="b">A note object to be compared</param>
		/// <returns></returns>
		public static bool operator != ( Note a, Note b )
		{
			return !( a == b );
		}

		#endregion
	}
}