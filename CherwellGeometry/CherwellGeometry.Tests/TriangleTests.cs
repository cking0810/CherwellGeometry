using CherwellGeometry.Core.Implementation;
using CherwellGeometry.Core.Repository;
using NUnit.Framework;

namespace CherwellGeometry.Tests
{
  [TestFixture]
  public class TriangleTests
  {
    [TestCase(0, 0, 1, 0, 1, 1)]
    [TestCase(0, 1, 0, 2, 1, 2)]
    public void Should_Build_Triangle(int vertex1x, int vertex1y, int vertex2x, int vertex2y, int vertex3x, int vertex3y)
    {
      var sut = TriangleFactory.BuildTriangle(
          new Vertex(vertex1x, vertex1y),
          new Vertex(vertex2x, vertex2y),
          new Vertex(vertex3x, vertex3y)
        );

      Assert.That(sut.Vertex1.X, Is.EqualTo(vertex1x));
      Assert.That(sut.Vertex1.Y, Is.EqualTo(vertex1y));
      Assert.That(sut.Vertex2.X, Is.EqualTo(vertex2x));
      Assert.That(sut.Vertex2.Y, Is.EqualTo(vertex2y));
      Assert.That(sut.Vertex3.X, Is.EqualTo(vertex3x));
      Assert.That(sut.Vertex3.Y, Is.EqualTo(vertex3y));
    }
  }
}
