﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FangZhouShuMa.ApplicationCore.Models.ProductReport
{
    public class ProductCustomFieldGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductCustomFieldModel> ProductCustomFieldModels { get; set; }
    }
}
