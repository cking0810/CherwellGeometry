using CherwellGeometry.Core.Implementation;
using CherwellGeometry.Core.Infrastructure;

namespace CherwellGeometry.Core.Repository
{
  /// <summary>
  /// Constructs an ITriangleImage using a TriangleImage implementation
  /// </summary>
  public class TriangleImageFactory
  {
    /// <summary>
    /// Build an ITriangleImage using the coordinates of its vertices
    /// </summary>
    /// <param name="width">width in pixels of the image</param>
    /// <param name="height">height in pixels of the image</param>
    /// <param name="cathetusLength">length in pixels of the sides adjacent to the triangle's right angle</param>
    /// <returns></returns>
    public static ITriangleImage BuildTriangleImage(int width, int height, int cathetusLength)
    {
      return new TriangleImage(width, height, cathetusLength);
    }
  }
}
