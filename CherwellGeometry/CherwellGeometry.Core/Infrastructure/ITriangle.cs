using CherwellGeometry.Core.Implementation;

namespace CherwellGeometry.Core.Infrastructure
{
  /// <summary>
  /// Defines the structure of an ITriangle
  /// </summary>
  public interface ITriangle
  {
    Vertex Vertex1 { get; set; }
    Vertex Vertex2 { get; set; }
    Vertex Vertex3 { get; set; }
  }
}
