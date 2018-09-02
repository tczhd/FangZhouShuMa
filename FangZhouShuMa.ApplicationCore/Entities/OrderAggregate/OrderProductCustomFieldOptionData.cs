﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte
{
    public class OrderProductCustomFieldOptionData : BaseEntity
    {
        public int OrderProductCustomFieldId { get; set; }
        public int ProductCustomFieldOptionsId { get; set; }
        public decimal Price { get; set; }
        public virtual OrderProductCustomFieldData OrderProductCustomFieldData { get; set; }
    }
}