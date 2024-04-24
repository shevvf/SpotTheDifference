using System;
using UnityEngine;

namespace Difference.Android
{
    public class AndroidPopup
    {
        public void ShowPopup(string title, string message, Action onCloseCallback = null)
        {
            AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject alertDialogBuilder = new("android.app.AlertDialog$Builder", activity);

            alertDialogBuilder.Call<AndroidJavaObject>("setTitle", title)
                .Call<AndroidJavaObject>("setMessage", message)
                .Call<AndroidJavaObject>("setPositiveButton", "OK", new AndroidPopupOnClose(onCloseCallback));

            AndroidJavaObject alertDialog = alertDialogBuilder.Call<AndroidJavaObject>("create");
            alertDialog.Call("setCanceledOnTouchOutside", false);
            alertDialog.Call("setCancelable", false);
            alertDialog.Call("show");
        }
    }
}