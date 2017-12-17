using CherwellGeometry.Core.Implementation;
using CherwellGeometry.Core.Infrastructure;
using CherwellGeometry.Core.Repository;
using System.Web.Http;

namespace CherwellGeometry.API.Controllers
{
  public class TriangleController : ApiController
  {
    private ITriangleImage TriangleImage = TriangleImageFactory.BuildTriangleImage(6, 12, 10);

    [Route("api/Triangle/GetCoordinates/{row}/{column}")]
    public ITriangle GetCoordinates(char row, int column)
    {
      return TriangleImage.FindTriangle(row, column);
    }

    [Route("api/Triangle/GetLocation/{vertex1x}/{vertex1y}/{vertex2x}/{vertex2y}/{vertex3x}/{vertex3y}")]
    public string GetLocation(int vertex1x, int vertex1y, int vertex2x, int vertex2y, int vertex3x, int vertex3y)
    {
      return TriangleImage.FindTriangleName(
          new Vertex(vertex1x, vertex1y),
          new Vertex(vertex2x, vertex2y),
          new Vertex(vertex3x, vertex3y)
          );
    }
  }
}
