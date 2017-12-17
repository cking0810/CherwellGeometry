using CherwellGeometry.Core.Implementation;
using CherwellGeometry.Core.Repository;
using NUnit.Framework;

namespace CherwellGeometry.Tests
{
  [TestFixture]
  public class TriangleImageTests
  {
    [TestCase('A', 1)]
    [TestCase('A', 2)]
    [TestCase('A', 12)]
    [TestCase('F', 9)]
    [TestCase('F', 12)]
    public void Should_Find_TriangleIn6x6(char row, int column)
    {
      var sut = TriangleImageFactory.BuildTriangleImage(6, 6, 10);

      var result = sut.FindTriangle(row, column);

      Assert.That(result, Is.Not.Null);
    }

    [TestCase('A', 0)]
    [TestCase('A', -1)]
    [TestCase('A', 13)]
    [TestCase('H', 1)]
    [TestCase('I', 13)]
    public void ShouldNot_Find_TriangleIn6x6(char row, int column)
    {
      var sut = TriangleImageFactory.BuildTriangleImage(6, 6, 10);

      var result = sut.FindTriangle(row, column);

      Assert.That(result, Is.Null);
    }

    [TestCase('A', 1,  0,  0,  0,  10, 10, 10)] // (0,0) (0,1) (1,1)
    [TestCase('A', 2,  0,  0,  10, 0,  10, 10)] // (0,0) (1,0) (1,1)
    [TestCase('A', 12, 50, 0,  60, 0,  60, 10)] // (5,0) (6,0) (6,10)
    [TestCase('F', 9,  40, 50, 40, 60, 50, 60)] // (4,5) (4,6) (5,6)
    [TestCase('F', 12, 50, 50, 60, 50, 60, 60)] // (5,5) (6,5) (6,6)
    public void Should_FindByLocation_TriangleIn6x6Specific(char row, int column, int vertex1x, int vertex1y, int vertex2x, int vertex2y, int vertex3x, int vertex3y)
    {
      var sut = TriangleImageFactory.BuildTriangleImage(6, 6, 10);

      var result = sut.FindTriangle(row, column);

      Assert.That(result.Vertex1.X, Is.EqualTo(vertex1x));
      Assert.That(result.Vertex1.Y, Is.EqualTo(vertex1y));
      Assert.That(result.Vertex2.X, Is.EqualTo(vertex2x));
      Assert.That(result.Vertex2.Y, Is.EqualTo(vertex2y));
      Assert.That(result.Vertex3.X, Is.EqualTo(vertex3x));
      Assert.That(result.Vertex3.Y, Is.EqualTo(vertex3y));
    }

    [TestCase("A1", 0, 0, 0, 10, 10, 10)] // (0,0) (0,1) (1,1)
    [TestCase("A2", 0, 0, 10, 0, 10, 10)] // (0,0) (1,0) (1,1)
    [TestCase("A12", 50, 0,  60, 0,  60, 10)] // (5,0) (6,0) (6,10)
    [TestCase("F9", 40, 50, 40, 60, 50, 60)] // (4,5) (4,6) (5,6)
    [TestCase("F12", 50, 50, 60, 50, 60, 60)] // (5,5) (6,5) (6,6)
    public void Should_FindByProperties_TriangleIn6x6Specific(string name, int vertex1x, int vertex1y, int vertex2x, int vertex2y, int vertex3x, int vertex3y)
    {
      var sut = TriangleImageFactory.BuildTriangleImage(6, 6, 10);

      var result = sut.FindTriangleName(
          new Vertex(vertex1x, vertex1y),
          new Vertex(vertex2x, vertex2y),
          new Vertex(vertex3x, vertex3y)
        );

      Assert.That(result, Is.EqualTo(name));
    }
  }
}
