using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FakeRestAPI.Models;
using FakeRestAPI.Domain.Interfaces;
using AutoMapper;
using FakeRestAPI.Infraestructure.Dto;
using Newtonsoft.Json;
using System.Net.Http;
using System;

namespace FakeRestAPI.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _responseDto;

        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _responseDto = new ResponseDto();
        }

        [HttpPost("Register")]
        public async Task<ActionResult> CreateUsers(UsersDto usersDto)
        {
            var response = await _unitOfWork.Users.UserRegister(
                new UsersModel
                {
                    UserName = usersDto.UserName

                }, usersDto.Password);

            if (response == "UserExist")
            {
                _responseDto.IsSuccess = false;
                _responseDto.DisplayMessage = "User already exist";
                return BadRequest(_responseDto);
            }

            if (response == "ErrorRegister")
            {
                _responseDto.IsSuccess = false;
                _responseDto.DisplayMessage = "Creating User error";
                return BadRequest(_responseDto);
            }
            _responseDto.DisplayMessage = "User created";
            _responseDto.Result = response;
            return Ok(_responseDto);

        }

        [HttpPost("Login")]
        public async Task<ActionResult> UsersLogin(UsersDto usersDto)
        {
            var response = await _unitOfWork.Users.UserLogin(usersDto.UserName, usersDto.Password);

            if (response=="nouser")
            {
                _responseDto.IsSuccess = false;
                _responseDto.DisplayMessage = "User dont exist!";
                return BadRequest(_responseDto);
            }
            if (response== "wrongpassword")
            {
                _responseDto.IsSuccess = false;
                _responseDto.DisplayMessage = "password doesnt match";
                return BadRequest(_responseDto);
            }
            _responseDto.Result = response;
            _responseDto.DisplayMessage = "User Connected";
            return Ok(_responseDto);
        }


        [HttpGet("Users")] //Consumo de web/api/get/users solo los de FakeRestApi
        public async Task<IEnumerable<UsersDto>> GetActivities()
        {
            var _httpClient = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fakerestapi.azurewebsites.net/api/v1/Users"),

            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var responseToReturn = JsonConvert.DeserializeObject<IEnumerable<UsersDto>>(body);
                return responseToReturn;
            }
        }
    }
}
