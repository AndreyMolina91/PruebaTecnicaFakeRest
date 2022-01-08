using System;
namespace FakeRestAPI.Infraestructure.Dto
{
    public class ActivitiesDto
    {
        public string title { get; set; }
        public DateTime dueDate { get; set; }
        public bool completed { get; set; }
    }
}
