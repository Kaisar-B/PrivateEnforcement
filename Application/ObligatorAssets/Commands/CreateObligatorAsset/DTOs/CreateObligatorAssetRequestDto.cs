using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ObligatorAssets.Commands.CreateObligatorAsset.DTOs
{
    /// <summary>
    ///     DTO for creating new assets record for specific obligator
    /// </summary>
    public class CreateObligatorAssetRequestDto
    {
        /// <summary>
        ///     Id of obligator to which new record binds
        /// </summary>
        public long ObligatorId { get; set; }
        public string AssetName { get; set; }
        public string AssetDescription { get; set; }
        public decimal EstimatedAssetValue { get; set; }
    }
}
