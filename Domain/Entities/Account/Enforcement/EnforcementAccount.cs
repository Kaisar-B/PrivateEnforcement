using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Account.Enforcement;

/// <summary>
///     Модель частного судебного исполнителя
/// </summary>
internal class EnforcementAccount : BaseAccount
{
    /// <summary>
    ///     Название организации
    /// </summary>
    public string EnforcementName { get; set; }

    /// <summary>
    ///     Номер лицензии
    /// </summary>
    public string LicenseNumber { get; set; }

    /// <summary>
    ///     Город работы частного судебного исполнителя
    /// </summary>
    public string City { get; set; }

    /// <summary>
    ///     Страна работы частного судебного исполнителя
    /// </summary>
    public string Country { get; set; }
}

