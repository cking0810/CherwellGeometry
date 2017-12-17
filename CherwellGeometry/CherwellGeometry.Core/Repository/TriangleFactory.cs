using CherwellGeometry.Core.Implementation;
using CherwellGeometry.Core.Infrastructure;

namespace CherwellGeometry.Core.Repository
{
  /// <summary>
  /// Constructs an ITriangle using a Triangle implementation
  /// </summary>
  public class TriangleFactory
  {
    /// <summary>
    /// Build an ITrangle using the coordines of its vertices
    /// </summary>
    /// <param name="Vertex1">first vertex</param>
    /// <param name="Vertex2">second vertex</param>
    /// <param name="Vertex3">third vertex</param>
    /// <returns></returns>
    public static ITriangle BuildTriangle(Vertex Vertex1, Vertex Vertex2, Vertex Vertex3)
    {
      return new Triangle(Vertex1, Vertex2, Vertex3);
    }

    /// <summary>
    /// Build an ITrangle using the coordines of its vertices
    /// </summary>
    /// <param name="Vertices">first, second, and third vertices</param>
    /// <returns></returns>
    public static ITriangle BuildTriangle((Vertex, Vertex, Vertex) Vertices)
    {
      return BuildTriangle(Vertices.Item1, Vertices.Item2, Vertices.Item3);
    }
  }
}
