using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared.Results;
public class BulkModificationResult
{
    public BulkModificationResult(int[] modifiedIds, int[] unModifiedIds)
    {
        ModifiedIds = modifiedIds;
        UnModifiedIds = unModifiedIds;
    }

    public int[] ModifiedIds { get; init; }
    public int[] UnModifiedIds { get; init; }
}
