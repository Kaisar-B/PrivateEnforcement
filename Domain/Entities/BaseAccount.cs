using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.Entities
{
    /// <summary>
    ///     Base model for account
    /// </summary>
    public abstract class BaseAccount
    {
        /// <summary>
        ///     Account id
        /// </summary>
        public long AccountId { get; set; }

        /// <summary>
        ///     Name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        ///     Surname
        /// </summary>
        public string? Surname { get; set; }

        /// <summary>
        ///     Non actual account 
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        ///     Creation date of account
        /// </summary>
        public DateTime? CreatedDate { get; set; }
    }
}
