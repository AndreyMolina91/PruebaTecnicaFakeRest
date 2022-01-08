using System;
namespace FakeRestAPI.Domain.Models
{
    public class ActivitiesModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime dueDate { get; set; }
        public bool completed { get; set; }
    }
}

