using System;
using FakeRestAPI.Domain.Models;

namespace FakeRestAPI.Domain.Interfaces
{
    public interface IBooksRepo : IGeneralAsyncRepo<BooksModel>
    {
    }
}
