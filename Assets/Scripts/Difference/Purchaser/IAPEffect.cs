using Difference.Infrastructure.Services.TimerService;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Purchasing;

namespace Difference.Purchaser
{
    public class IAPEffect : IDisposable
    {
        private readonly IAPCore iAPCore;
        private readonly ITimer timer;

        public IAPEffect(IAPCore iAPCore, ITimer timer)
        {
            this.iAPCore = iAPCore;
            this.timer = timer;
        }

        public void InitializeLevelIAP()
        {
            iAPCore.OnPurchaseSuccess += PurchaseSuccess;
        }

        public void Dispose()
        {
            iAPCore.OnPurchaseSuccess -= PurchaseSuccess;
        }

        public void PurchaseSuccess(ProductDefinition product)
        {
            switch (product.id)
            {
                case "ten_seconds":
                    AddTime(product.payout.quantity);
                    break;
                default:
                    break;
            }
        }

        public void AddTime(double timeInSeconds)
        {
            timer.CurrentTime += TimeSpan.FromSeconds(timeInSeconds);
        }
    }
}