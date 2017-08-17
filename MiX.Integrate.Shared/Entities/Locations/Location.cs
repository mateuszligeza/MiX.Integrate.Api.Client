﻿namespace MiX.Integrate.Shared.Entities.Locations
{
	/// <summary>
	/// defines a Location for a shape on a map.
	/// </summary>
	public class Location
	{
		/// <summary>Geographic coordinate</summary>
		public class Coordinate
		{
			/// <summary>Longitude of coordinate</summary>
			public float Longitude { get; set; }
			/// <summary>Latitude of coordinate</summary>
			public float Latitude { get; set; }
		}

		/// <summary>Unique Id for the location</summary>
		public long LocationId { get; set; }
		/// <summary>Name of the location</summary>
		public string Name { get; set; }
		/// <summary>Address of the location</summary>
		public string Address { get; set; }
		/// <summary>Type of location</summary>
		public LocationType LocationType { get; set; }

		/// <summary>Centre coordinate of the location</summary>
		public Coordinate Centre { get; set; }
		/// <summary>Radius of the shape</summary>
		public decimal RadiusKilometers { get; set; }

		/// <summary>Upper left coordinate of the bounding rectangle around the shape</summary>
		public Coordinate BoundingUpperLeft { get; set; }
		/// <summary>Lower right coordinate of the bounding rectangle around the shape</summary>
		public Coordinate BoundingLowerRight { get; set; }

		/// <summary>The type of shape describing the location</summary>
		public ShapeType ShapeType { get; set; }
		/// <summary>The Well Known Text describing the outline of the shape</summary>
		public string ShapeWkt { get; set; }

		/// <summary>Signifies that the location has been logically deleted from the system.</summary>
		public bool IsDeleted { get; set; }

	}
}
