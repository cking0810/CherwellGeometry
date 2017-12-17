using CherwellGeometry.Core.Infrastructure;

namespace CherwellGeometry.Core.Implementation
{
  /// <summary>
  /// Wrapper for an ITrangle that allow a name to be given to the ITrangle
  /// </summary>
  public class NamedTriangle
  {
    public ITriangle Triangle { get; set; }
    public string Name { get; set; }

    public NamedTriangle(ITriangle triangle, string name)
    {
      Triangle = triangle;
      Name = name;
    }
  }
}
