using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

namespace Difference.UI
{
    public class UIMainView : MonoBehaviour
    {
        [field: SerializeField] public Transform Canvas { get; private set; }
        [field: SerializeField] public TMP_Text Timer { get; private set; }
        [field: SerializeField] public TMP_Text Level { get; private set; }
        [field: SerializeField] public Button IAP { get; private set; }
    }
}