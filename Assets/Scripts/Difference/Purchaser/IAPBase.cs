using System.Collections.Generic;
using UnityEngine.Purchasing;

namespace Difference.Purchaser
{
    public class IAPBase
    {
        public string Id { get; set; }
        public List<PayoutDefinition> Payouts { get; set; }
    }
}