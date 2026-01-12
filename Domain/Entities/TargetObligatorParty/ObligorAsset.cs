using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.Entities.TargetObligatorParty
{
    /// <summary>
    ///     Assets of obligor
    /// </summary>
    public class ObligorAsset
    {
        /// <summary>
        ///     Assets id
        /// </summary>
        public long AssetId { get; set; }

        /// <summary>
        ///     Assets name
        /// </summary>
        public string AssetName { get; set; }

        /// <summary>
        ///     Estimated value of assets
        /// </summary>
        public decimal EstimatedValue { get; set; }

        /// <summary>
        ///     Serial number / Passport number of asset
        /// </summary>
        public string PassportNumberAsset { get; set; }

        /// <summary>
        ///     Description of asset
        /// </summary>
        public string Description { get; set; }
    }
}
