using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FakeRestAPI.DataAccess;
using FakeRestAPI.Domain.Models;
using FakeRestAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace FakeRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ActivitiesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivitiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // POST: api/Activities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task PostActivitiesModel(ActivitiesModel activitiesModel)
        {
             await _unitOfWork.Activities.AddT(activitiesModel);
            _unitOfWork.SaveData();
        }

    }
}
