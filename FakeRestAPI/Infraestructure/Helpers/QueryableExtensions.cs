using System;
using System.Linq;
using FakeRestAPI.Infraestructure.Dto;

namespace FakeRestAPI.Infraestructure.Helpers
{
    public static class QueryableExtensions
    {
        //Clase de extension de los queryable para utilizarla en la consulta entityframework
        //del metodo para listar los objectos de la base de datos
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PagerDto pagerDto)
        {
            //pagina actual - 1 multiplicado por paginacion y cantidad de registros por pagina
            //Take para tomar ese dato y enviarlo por parametro
            return queryable.Skip((pagerDto.Page - 1) * pagerDto.ObjectsPerPage)
                .Take(pagerDto.ObjectsPerPage);
        }
    }
}
