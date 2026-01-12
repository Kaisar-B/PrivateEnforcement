using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.Entities.TargetObligatorParty
{
    public class BankAccount
    {
        public string BankName { get; set; }
        public string AccountIBAN { get; set; }
        public string? AccountNumber { get; set; }
    }
}
