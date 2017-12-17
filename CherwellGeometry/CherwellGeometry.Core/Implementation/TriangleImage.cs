using CherwellGeometry.Core.Infrastructure;
using CherwellGeometry.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CherwellGeometry.Core.Implementation
{
  /// <summary>
  /// Implementation of an ITriangleImage. This TriangleImage defines a structure that
  /// holds multiple triangles based on the overall image's width, height, and cathetus.
  /// </summary>
  public class TriangleImage : ITriangleImage
  {
    private List<TriangleImageSector> _sectors = new List<TriangleImageSector>();
    private int _width;
    private int _height;
    private int _cathetusLength;

    /// <summary>
    /// Constructs a TriangleImage based on the desired size of the image
    /// </summary>
    /// <param name="width">size in pixels of the width of the image</param>
    /// <param name="height">size in pixels of the height of the image</param>
    /// <param name="cathetusLength">length in pixels of the sides adjacent to the triangle's right angle</param>
    public TriangleImage(int width, int height, int cathetusLength)
    {
      _width = width;
      _height = height;
      _cathetusLength = cathetusLength;

      BuildImage();
    }

    /// <summary>
    /// Builds a triangle image based on the specified height and width
    /// </summary>
    private void BuildImage()
    {
      for (var row = 0; row < _height; row++)
      {
        for (var col = 0; col < _width; col++)
        {
          var cellChar = Convert.ToChar(row + 65).ToString();
          var lowerVertices = VerticesFromCell(row, col, false);
          var upperVertices = VerticesFromCell(row, col, true);

          _sectors.Add(new TriangleImageSector
          {
            Lower  = new NamedTriangle(TriangleFactory.BuildTriangle(lowerVertices), $"{cellChar}{(col * 2 + 1)}"),
            Upper  = new NamedTriangle(TriangleFactory.BuildTriangle(upperVertices), $"{cellChar}{(col + 1) * 2}"),
            Row    = row,
            Column = col
          });
        }
      }
    }

    /// <summary>
    /// Gets the vertices of a triangle based on a row and column, and
    /// whether the triangle is the upper or lower
    /// </summary>
    /// <param name="row">the row of the triangle in the image=</param>
    /// <param name="col">the column of the triangle in the image</param>
    /// <param name="upper">true if the triangle is in the upper position, false otherwise</param>
    /// <returns></returns>
    private (Vertex, Vertex, Vertex) VerticesFromCell(int row, int col, bool upper)
    {
      return ValueTuple.Create(
        new Vertex(col * _cathetusLength                                 , row * _cathetusLength),                                 
        new Vertex(col * _cathetusLength + (upper ? _cathetusLength : 0) , row * _cathetusLength + (upper ? 0 : _cathetusLength)), 
        new Vertex(col * _cathetusLength + _cathetusLength               , row * _cathetusLength + _cathetusLength)
      );
    }

    /// <summary>
    /// Finds a triangle name in the image based on 3 vertices of the triangle
    /// </summary>
    /// <param name="Vertex1">the first set of coordinates for a vertex of the triangle</param>
    /// <param name="Vertex2">the second set of coordinates for a vertex of the triangle</param>
    /// <param name="Vertex3">the third set of coordinates for a vertex of the triangle</param>
    /// <returns></returns>
    public string FindTriangleName(Vertex Vertex1, Vertex Vertex2, Vertex Vertex3)
    {
      return _sectors.Select(x => x.Lower)
        .Concat(_sectors.Select(x => x.Upper))
        .Where(x => x.Triangle.Vertex1.Equals(Vertex1))
        .Where(x => x.Triangle.Vertex2.Equals(Vertex2))
        .Where(x => x.Triangle.Vertex3.Equals(Vertex3))
        .Select(x => x.Name)
        .FirstOrDefault();
    }
    
    /// <summary>
    /// Finds a triangle in the image based on a row and column
    /// </summary>
    /// <param name="row">the row in which the triangle should exist defined as a character</param>
    /// <param name="column">the column in which the triangle should exist defined as int</param>
    /// <returns></returns>
    public ITriangle FindTriangle(char row, int column)
    {
      var upper = column % 2 == 0;
      var gridColumn = Math.Ceiling((double)column / 2) - 1;

      return _sectors.Where(x => x.Row == (((int)row) - (65)))
        .Where(x => x.Column == gridColumn)
        .Select(x => (upper ? x.Upper : x.Lower).Triangle)
        .FirstOrDefault();
    }

    /// <summary>
    /// Helper class for defining the TriangleImage
    /// </summary>
    private class TriangleImageSector
    {
      public NamedTriangle Upper { get; set; }
      public NamedTriangle Lower { get; set; }
      public int Row             { get; set; }
      public int Column          { get; set; }
    }
  }
}
