using System;
namespace FakeRestAPI.Infraestructure.Dto
{
    public class PagerDto
    {
        public int Page { get; set; }

        public int objectsPerPage = 25;
        private readonly int maxObjectsPerPage = 50;

        public int ObjectsPerPage
        {
            get => objectsPerPage;
            set
            {
                //Si el usuario quiere ver mas de 50 registros por pagina
                //Entonces se le asigna el valor de 50 pues es el maximo permitido
                //De lo contrario se puede asignar el valor menos a 50 segun lo requiera
                objectsPerPage = (value > maxObjectsPerPage) ? maxObjectsPerPage : value;
            }
        }
    }
}
