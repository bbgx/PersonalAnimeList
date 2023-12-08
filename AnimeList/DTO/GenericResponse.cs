using System.Dynamic;
using System.Net;

namespace AnimeList.DTO
{
    public class GenericResponse<T> where T : class
    {
        public HttpStatusCode HttpCode { get; set; }

        public T? ReturnData { get; set; }

        public ExpandoObject? ReturnError { get; set; }

    }
}
