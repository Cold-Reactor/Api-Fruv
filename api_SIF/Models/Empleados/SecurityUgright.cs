using System;
using System.Collections.Generic;

namespace api_SIF.Models.Empleados
{
    public partial class SecurityUgright
    {
        public string TableName { get; set; }
        public int GroupId { get; set; }
        public string AccessMask { get; set; }
    }
}
