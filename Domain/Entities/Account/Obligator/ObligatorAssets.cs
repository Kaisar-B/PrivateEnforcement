using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Account.Obligator;

/// <summary>
///     Модель для описание актива должника
/// </summary>
internal class ObligatorAssets : BaseDomainModel
{
    /// <summary>
    ///     Стоимость актива
    /// </summary>
    public decimal AssetsValue { get; set; }

    /// <summary>
    ///     Описание актива
    /// </summary>
    public string DescriptionOfAssets { get; set; }
}