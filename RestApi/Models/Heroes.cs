using System;
using System.Collections.Generic;

namespace RestApi.Models
{
    public partial class Heroes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Quirk { get; set; }
    }
}
