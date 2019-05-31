using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WhereIsMyMovieBusiness.Dtos
{
    public class GeneralResponse<T> where T : class
    {
        public T Data { get; set; }
        public ErrorDto Error { get; set; }

    }

}
