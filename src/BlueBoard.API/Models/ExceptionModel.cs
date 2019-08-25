using System.Collections.Generic;

namespace BlueBoard.API.Models
{
    public class ExceptionModel
    {
        public string Code { get; set; }
        public bool HasErrors => Errors.Count != 0;
        public IList<string> Errors { get; set; }

        public ExceptionModel(string code, IList<string> errors)
        {
            Code = code;
            Errors = errors ?? new List<string>();
        }
    }
}
