using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FakeRestAPI.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using FakeRestAPI.Domain.Interfaces;
using FakeRestAPI.Infraestructure.Dto;
using FakeRestAPI.DataAccess;
using FakeRestAPI.Infraestructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace FakeRestAPI.Controllers
{
    [Route("api/Books")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _context;

        public BooksController(IMapper mapper, IUnitOfWork unitOfWork, AppDbContext context)
        {
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<IEnumerable<BooksDto>> GetBooks([FromQuery] PagerDto pagerDto)
        {
            ////Pager debe ir en la cabecera de la respuesta http
            //var queryable = _context.Books.AsQueryable();
            ////Agregamos en el header de la respuesta http la cantidad de registros por medio del dto
            //await HttpContext.PagerParams(queryable, pagerDto.ObjectsPerPage);
            ////lista de entidades con la paginacion aplicada
            //var entities = await queryable.Paginate(pagerDto).ToListAsync();
            ////retornamos las entidades con la paginación
            //return _mapper.Map<IEnumerable<BooksDto>>(entities);

            var booksList = await _unitOfWork.Books.GetAll();
            var booksListDto = _mapper.Map<IEnumerable<BooksDto>>(booksList);
            return booksListDto;
        }

        //// GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BooksDto>> GetBooksModel(int id)
        {
            var booksModel = await _unitOfWork.Books.GetT(id);

            if (booksModel == null)
            {
                return NotFound();
            }

            var booksDto = _mapper.Map<BooksDto>(booksModel);

            return booksDto;
        }



        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<BooksDto>> PostBooksModel(BooksDto booksDto)
        {
            var bookModel = _mapper.Map<BooksModel>(booksDto);
            await _unitOfWork.Books.AddT(bookModel);
            _unitOfWork.SaveData();
            return booksDto;
        }

    }
}
