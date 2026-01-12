using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Data.Domain.Entities.TargetObligatorParty
{
    /// <summary>
    ///     Debt representation
    /// </summary>
    public class DebtObligation
    {
        /// <summary>
        ///     Debt id
        /// </summary>
        public long DebtId { get; set; }

        /// <summary>
        ///     Amount of debt
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        ///     Currency of debt
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        ///     Serial number of debt order by enforcment
        /// </summary>
        public string DebtOrderNumber { get; set; }
    }
}
