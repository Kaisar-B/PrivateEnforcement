using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ObligatorAssets.Commands.UpdateObligatorAsset.DTOs
{
    /// <summary>
    ///     DTO for updating assets record for specific obligator
    /// </summary>
    public class UpdateObligatorAssetRequestDto
    {
        /// <summary>
        ///     Id of obligator to which new record binds
        /// </summary>
        public long Id { get; set; }
        public string? AssetName { get; set; }
        public string? AssetDescription { get; set; }
        public decimal? EstimatedAssetValue { get; set; }
    }
}
