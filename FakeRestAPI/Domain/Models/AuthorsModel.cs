using System.ComponentModel.DataAnnotations.Schema;

namespace FakeRestAPI.Domain.Models
{
    public class AuthorsModel
    {
        public int id { get; set; }
        public int idBook { get; set; }
        [ForeignKey("idBook")]
        public BooksModel books { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
