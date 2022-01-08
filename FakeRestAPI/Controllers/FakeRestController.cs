using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CsvHelper;
using FakeRestAPI.Domain.Interfaces;
using FakeRestAPI.Domain.Models;
using FakeRestAPI.Infraestructure.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FakeRestAPI.Controllers
{
    [Route("api/FakeRest")]
    [ApiController]
    [Authorize]
    public class FakeRestController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public FakeRestController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("Activities")] //Consumo de web/api/get
        public async Task<IEnumerable<ActivitiesDto>> GetActivities()
        {
            var _httpClient = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fakerestapi.azurewebsites.net/api/v1/Activities"),
                
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var responseToReturn = JsonConvert.DeserializeObject<IEnumerable<ActivitiesDto>>(body);
                return responseToReturn; 
            }
        }

        [HttpGet("Activities/{id}")] //Consumo de web/api/get
        public async Task<ActionResult<ActivitiesDto>> GetActivityById([FromRoute]int id)
        {
            var _httpClient = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://fakerestapi.azurewebsites.net/api/v1/Activities/{id}")
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var responseToReturn = JsonConvert.DeserializeObject<ActivitiesDto>(body);
                var activitiesModel = _mapper.Map<ActivitiesModel>(responseToReturn);
                var modelToCompare = await _unitOfWork.Activities.GetFirst(x=>x.title == activitiesModel.title);
                if (activitiesModel.title == modelToCompare.title)
                {
                    return BadRequest("Activity exist in Data Base");
                }
                await _unitOfWork.Activities.AddT(activitiesModel);
                _unitOfWork.SaveData();
                return responseToReturn;
            }
        }

        [HttpPost("Activities")]
        public async Task<ActivitiesDto> Post(ActivitiesDto activitiesDto)
        {
            var _httpClient = new HttpClient();

            //serializar
            string activitiesJson = JsonConvert.SerializeObject(activitiesDto);
            //request
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://fakerestapi.azurewebsites.net/api/v1/Activities"),
                Content = new StringContent(activitiesJson, Encoding.UTF8)
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }
            };
            //response
            using (var response=await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                //deserealizar string a Json
                var responseToReturn = JsonConvert.DeserializeObject<ActivitiesDto>(body);
                return responseToReturn;
            }
        }

        [HttpGet("csv")]
        public async Task<FileStreamResult> GetCsv()
        {
            var booksList = await _unitOfWork.Books.GetAll();
            var reportBooks = _mapper.Map<IEnumerable<BooksDto>>(booksList);
            var stream = new MemoryStream();
            using(var writeFile = new StreamWriter(stream, leaveOpen: true))
            {
                var csv = new CsvWriter(writeFile, CultureInfo.CurrentCulture);
                csv.Context.RegisterClassMap<BookCsvMap>();
                await csv.WriteRecordsAsync(reportBooks);
            }
            stream.Position = 0;
            return File(stream, "application/octet-stream", "books-list.csv");
            //Blob sin ser descargado desde el Front solo desde Swagger.
        }
    }
}