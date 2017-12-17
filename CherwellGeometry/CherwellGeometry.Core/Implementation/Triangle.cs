using CherwellGeometry.Core.Infrastructure;

namespace CherwellGeometry.Core.Implementation
{
  /// <summary>
  /// Implementation of an ITriangle. This Triangle defines the coordinates of 
  /// each vertex of the triangle.
  /// </summary>
  public class Triangle : ITriangle
  {
    public Vertex Vertex1 { get; set; }
    public Vertex Vertex2 { get; set; }
    public Vertex Vertex3 { get; set; }

    /// <summary>
    /// Constructs a Triangle based on the vertices
    /// </summary>
    /// <param name="vertex1">coordinates of the first vertex</param>
    /// <param name="vertex2">coordinates of the second vertex</param>
    /// <param name="vertex3">coordinates of the third vertex</param>
    public Triangle(Vertex vertex1, Vertex vertex2, Vertex vertex3)
    {
      Vertex1 = vertex1;
      Vertex2 = vertex2;
      Vertex3 = vertex3;
    }
  }
}
