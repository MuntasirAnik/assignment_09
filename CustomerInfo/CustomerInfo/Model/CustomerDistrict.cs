﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInfo.Model
{
    public class CustomerDistrict
    {
        public int Id { set; get; }
        public int Code { set; get; }
        public string Name  { set; get; }
        public string  Address { set; get; }

        public string Contact { set; get; }
        public string District { set; get; }
    }
}
