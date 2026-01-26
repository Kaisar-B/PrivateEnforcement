using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Account.Enforcement;

namespace Domain.Entities.Account.Obligator;

/// <summary>
///     Аккаунт должника
/// </summary>
public class ObligatorAccount : BaseAccount
{
    /// <summary>
    ///     Сумма долга
    /// </summary>
    public decimal? DebtAmount { get; set; }

    /// <summary>
    ///     Номер контракта по задолженности
    /// </summary>
    public string ObligationContractNumber { get; set; }

    /// <summary>
    ///     Город
    /// </summary>
    public string City { get; set; }

    /// <summary>
    ///     Регион
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    ///     Аккаунт ЧСИ - владелец должника 
    /// </summary>
    public long OwnerEnforcementAccountId { get; set; }
    public EnforcementAccount OwnerEnforcementAccount { get; set; }

    /// <summary>
    ///     Активы должника
    /// </summary>
    public ICollection<ObligatorAsset> ObligatorAssets { get; set; }
}
