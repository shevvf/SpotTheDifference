using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

namespace Difference.Purchaser
{
    public class IAPCore : IDetailedStoreListener
    {
        private IStoreController storeController;
        private IExtensionProvider storeExtensionProvider;

        private readonly IAPData iAPData = new();

        public Action<ProductDefinition> OnPurchaseSuccess;

        public void Initialize()
        {
            if (IsInitialized())
                return;

            InitializePurchasing();
        }

        private void InitializePurchasing()
        {
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

            var consumables = iAPData.consumables;
            consumables.ForEach(consumable =>
            {
                builder.AddProduct(consumable.Id, ProductType.Consumable,
                    new IDs {},
                    consumable.Payouts);
            });

            UnityPurchasing.Initialize(this, builder);
        }

        private bool IsInitialized()
        {
            return storeController != null && storeExtensionProvider != null;
        }

        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            storeController = controller;
            storeExtensionProvider = extensions;

            Debug.Log("Unity IAP Initialized");
        }

        public void OnInitializeFailed(InitializationFailureReason error)
        {
            Debug.Log("OnInitializeFailed: " + error);
        }

        public void OnInitializeFailed(InitializationFailureReason error, string message)
        {
            Debug.Log("OnInitializeFailed: " + error + $"{message}");
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
        {
            OnPurchaseSuccess?.Invoke(purchaseEvent.purchasedProduct.definition);

            return PurchaseProcessingResult.Complete;
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            Debug.Log("OnPurchaseFailed: " + product.definition.storeSpecificId + $" {failureReason}");
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
        {
            Debug.Log("OnPurchaseFailed: " + product.definition.storeSpecificId + $" {failureDescription}");
        }
    }
}