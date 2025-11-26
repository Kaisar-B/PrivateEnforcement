using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Account.Obligator;

/// <summary>
///     Аккаунт должника
/// </summary>
internal class ObligatorAccount : BaseAccount
{
    /// <summary>
    ///     Сумма долга
    /// </summary>
    public decimal DebtAmount { get; set; }

    /// <summary>
    ///     Номер контракта по задолженности
    /// </summary>
    public string ObligationContractNumber { get; set; }

    /// <summary>
    ///     Активы должника
    /// </summary>
    public ICollection<ObligatorAssets> ObligatorAssets { get; set; }
}
