namespace CherwellGeometry.Core.Implementation
{
  /// <summary>
  /// Structure for holding coordinates 
  /// </summary>
  public struct Vertex
  {
    public int X { get; set; }
    public int Y { get; set; }

    public Vertex(int x, int y)
    {
      X = x;
      Y = y;
    }
  }
}
