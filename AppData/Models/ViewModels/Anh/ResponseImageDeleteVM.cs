﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models.ViewModels.Anh
{
    public class ResponseImageDeleteVM
    {
        public string idProductDetail { get; set; }
        public List<string>? lstImageRemove { get; set; }
    }
}
