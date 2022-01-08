using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FakeRestAPI.Domain.Models;
using FakeRestAPI.Domain.Interfaces;
using AutoMapper;
using FakeRestAPI.Infraestructure.Dto;
using Microsoft.AspNetCore.Authorization;

namespace FakeRestAPI.Controllers
{
    [Route("api/Authors")]
    [ApiController]
    [Authorize]
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthorsController(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<IEnumerable<AuthorsDto>> GetAuthors()
        {
            var authorsList = await _unitOfWork.Authors.GetAll();
            var authorsListDto = _mapper.Map<IEnumerable<AuthorsDto>>(authorsList);
            return authorsListDto;
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorsDto>> GetAuthorsModel(int id)
        {
            var authorsModel = await _unitOfWork.Authors.GetT(id);

            var authorsDto = _mapper.Map<AuthorsDto>(authorsModel);

            return authorsDto;
        }

        // GET: api/Authors/5
        [HttpGet("Books/{id}")]
        public async Task<IEnumerable<AuthorsDto>> GetAuthorsByBookId(int id)
        {
            var authorsModelList = await _unitOfWork.Authors.GetAll(x=>x.idBook==id);

            var authorsDtoList = _mapper.Map<IEnumerable<AuthorsDto>>(authorsModelList);

            return authorsDtoList;
        }

        //// POST: api/Authors
        [HttpPost]
        public async Task<ActionResult<AuthorsDto>> PostAuthorsModel(AuthorsDto authorsDto)
        {
            var authorsModel = _mapper.Map<AuthorsModel>(authorsDto);
            await _unitOfWork.Authors.AddT(authorsModel);
            _unitOfWork.SaveData();
            return authorsDto;
        }

    }
}
