using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace FakeRestAPI.Infraestructure.Helpers
{
    public static class HttpContextExtensions
    {
        public async static Task PagerParams<T>(this HttpContext httpContext,
            IQueryable<T> queryable, int numberOfRecords )  
        {
            //Conteno de registros
            double quantity = await queryable.CountAsync();
            //Calculo de cantidad de paginas para enviarla al cliente
            double pagerQuantity = Math.Ceiling(quantity / numberOfRecords);
            //enviamos en el header la cantidad de paginas por registros por medio de la funcion
            httpContext.Response.Headers.Add("pagerQuantity", pagerQuantity.ToString());
        }
    }
}
