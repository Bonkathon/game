using System;
using UnityEngine;

public static class AddressablesLoader
{
    public static void Load<T>(string address, Action<T> onLoaded)
    {
        AddressablesManager.Instance.LoadAsset(address, onLoaded);
    }

    public static void Release(string address)
    {
        AddressablesManager.Instance.ReleaseAsset(address);
    }
}
