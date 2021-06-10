﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NMT.Model.Entity
{
    public class Order
    {
        public string order_id { get; set; }

        public DateTime date { get; set; }

        public int culmulative_point { get; set; }

        public string employee_id { get; set; }

        public string customer_id { get; set; }

        public string discount_voucher_id { get; set; }
    }
}
