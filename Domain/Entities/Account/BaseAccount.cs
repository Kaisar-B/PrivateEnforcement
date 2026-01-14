using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Account;

/// <summary>
///     Базовый доменный модель
/// </summary>
public abstract class BaseAccount : BaseDomainModel
{
    /// <summary>
    ///     ИИН удостоверения личности
    /// </summary>
    public string PassportNumber { get; set; }
    /// <summary>
    ///     Имя субъекта 
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Фамилия субъекта
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    ///     Логин
    /// </summary>
    public string Login { get; set; }
    
    /// <summary>
    ///     Пароль шифровка алгоритм sha1
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    ///     Заблокирован ли аккаунт
    /// </summary>
    public bool IsBlocked { get; set; }
}