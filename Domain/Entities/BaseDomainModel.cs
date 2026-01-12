using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

/// <summary>
///     Базовая модель для всех сущнестей 
/// </summary>
public abstract class BaseDomainModel
{
    protected BaseDomainModel() => CreationDateTime = DateTime.Now;

    /// <summary>
    ///     Время создание модели
    /// </summary>
    public DateTime CreationDateTime { get; init; }

    /// <summary>
    ///     Идентификатор объекта
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    ///     Был ли удален аккаунт (soft delete filter)
    /// </summary>
    public bool IsDeleted { get; set; }
}
