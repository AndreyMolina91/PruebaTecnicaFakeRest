using System;
using CsvHelper.Configuration;
using FakeRestAPI.Domain.Models;

namespace FakeRestAPI.Infraestructure.Dto
{
    public class BookCsvMap : ClassMap<BooksModel>
    {
        public BookCsvMap()
        {
            Map(m => m.id).Name("ID_Register");
            Map(m => m.title).Name("Title");
            Map(m => m.description).Name("Description");
            Map(m => m.pageCount).Name("Pages");
            Map(m => m.excerpt).Name("Excerpt");
            Map(m => m.publishDate).Name("Published");
        }
    }
}
