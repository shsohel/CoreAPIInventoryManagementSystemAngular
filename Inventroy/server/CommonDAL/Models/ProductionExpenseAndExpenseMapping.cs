using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class ProductionExpenseAndExpenseMapping
    {
        public long Id { get; set; }
        public long ProductionExpenseId { get; set; }
        public long ExpenseId { get; set; }
    }
}
