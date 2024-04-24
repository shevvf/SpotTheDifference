using System;
using UnityEngine;

namespace Difference.Android
{
    public class AndroidPopupOnClose : AndroidJavaProxy
    {
        private readonly Action onCloseCallback;

        public AndroidPopupOnClose(Action onCloseCallback) : base("android.content.DialogInterface$OnClickListener")
        {
            this.onCloseCallback = onCloseCallback;
        }

        public void onClick(AndroidJavaObject dialog, int which)
        {
            onCloseCallback?.Invoke();
        }
    }
}
