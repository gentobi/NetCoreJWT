﻿using System.Collections.Generic;

namespace NetCoreAuth.Models.DataModels
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Permissions { get; set; }
    }
}
