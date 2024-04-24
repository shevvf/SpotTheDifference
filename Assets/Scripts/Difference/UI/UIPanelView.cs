using Difference.Infrastructure.Services.DestroyableService;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Difference.UI
{
    [Serializable]
    public class UIPanelView
    {
        [field: SerializeField] public DestroyableObject DestroyablePanel { get; private set; }

        [field: SerializeField] public Button Restart { get; private set; }
    }
}