using System.Collections.Generic;
using UnityEngine.Purchasing;

namespace Difference.Purchaser
{
    public class IAPData
    {
        public List<IAPConsumable> consumables = new()
        {
            new IAPConsumable
            {
                Id = "ten_seconds",
                Payouts = new List<PayoutDefinition>
                {
                    new (PayoutType.Other, "", 10d,"")
                }
            }
        };
    }
}