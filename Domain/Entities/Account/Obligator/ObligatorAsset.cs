using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Account.Obligator;

/// <summary>
///     Модель для описание актива должника
/// </summary>
public class ObligatorAsset : BaseDomainModel
{
    /// <summary>
    ///     Стоимость актива
    /// </summary>
    public decimal AssetValue { get; set; }

    /// <summary>
    ///     Имя актива
    /// </summary>
    public string AssetName { get; set; }

    /// <summary>
    ///     Описание актива
    /// </summary>
    public string DescriptionOfAsset { get; set; }

    /// <summary>
    ///     Владелец-должник актива
    /// </summary>
    public long OwnerObligatorAccountId { get; set; }
    public ObligatorAccount OwnerObligatorAccount { get; set; }
}