using System;
using System.Collections.Generic;

namespace TmsId.Shared
{
    public class UserManagerResponse
    {
        public string message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> errors { get; set; }
        public DateTime? ExpireDate { get; set; }
    }

    public class LafargeGenericException : Exception
    {

    }
}
