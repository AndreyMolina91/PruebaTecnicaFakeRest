using System.ComponentModel.DataAnnotations.Schema;

namespace FakeRestAPI.Domain.Models
{
    public class CoverPhotosModel
    {
        public int id { get; set; }
        public int idBook { get; set; }
        [ForeignKey("idBook")]
        public BooksModel books { get; set; }
        public string url { get; set; }
    }
}
