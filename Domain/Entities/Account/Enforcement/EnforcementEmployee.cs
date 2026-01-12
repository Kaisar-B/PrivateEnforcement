using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DAL.FluentAPIConfiguration;

namespace Domain.Entities.Account.Enforcement;
public class EnforcementEmployee : BaseAccount
{
    /// <summary>
    ///     ЧСИ работадатель
    /// </summary>
    public long EnforcementEmployerId { get; set; }
    public EnforcementAccount EnforcementEmployer { get; set; }

    /// <summary>
    ///     Позиция сотрудника в оргонизаций ЧСИ
    /// </summary>
    public string Position { get; set; }
}
