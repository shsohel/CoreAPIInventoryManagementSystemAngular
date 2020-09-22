using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class Expenses
    {
        public long Id { get; set; }
        public int ExpenseTypeId { get; set; }
        public int ExpenseHeadId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int Responsible { get; set; }
        public string Note { get; set; }
        public bool IsAdjustmentPayment { get; set; }
        public bool IsLocked { get; set; }
        public byte Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
