using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Account.Obligator;

namespace Domain.Entities.Account.Enforcement;

/// <summary>
///     Модель частного судебного исполнителя
/// </summary>
public class EnforcementAccount : BaseAccount
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

    /// <summary>
    ///     Работники ЧСИ
    /// </summary>
    public ICollection<EnforcementEmployee> Employees { get; set; }

    /// <summary>
    ///     Списко должников для ЧСИ
    /// </summary>
    public ICollection<ObligatorAccount> Obligators { get; set; }
}

