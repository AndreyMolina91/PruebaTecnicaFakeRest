using System.Collections.Generic;

namespace FakeRestAPI.Infraestructure.Dto
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; }
        public List<string> ErrorMessage { get; set; }
    }
}
