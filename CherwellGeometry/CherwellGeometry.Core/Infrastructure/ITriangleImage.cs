using CherwellGeometry.Core.Implementation;

namespace CherwellGeometry.Core.Infrastructure
{
  /// <summary>
  /// Defines the structure of an ITriangleImage
  /// </summary>
  public interface ITriangleImage
  {
    string FindTriangleName(Vertex Vertex1, Vertex Vertex2, Vertex Vertex3);
    ITriangle FindTriangle(char row, int column);
  }
}
