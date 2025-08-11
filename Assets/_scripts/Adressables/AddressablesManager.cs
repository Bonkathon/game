using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;
using System.Collections.Generic;

public class AddressablesManager : MonoBehaviour
{
    private static AddressablesManager _instance;
    public static AddressablesManager Instance => _instance;

    private Dictionary<string, AsyncOperationHandle> _loadedAssets = new();

    private void Awake()
    {
        if (_instance == null) { _instance = this; DontDestroyOnLoad(gameObject); }
        else Destroy(gameObject);
    }

    public void LoadAsset<T>(string address, Action<T> onLoaded)
    {
        if (_loadedAssets.ContainsKey(address))
        {
            onLoaded?.Invoke((T)_loadedAssets[address].Result);
            return;
        }

        var handle = Addressables.LoadAssetAsync<T>(address);
        handle.Completed += op =>
        {
            if (op.Status == AsyncOperationStatus.Succeeded)
            {
                _loadedAssets[address] = op;
                onLoaded?.Invoke(op.Result);
            }
            else
            {
                Debug.LogError($"Falha ao carregar: {address}");
            }
        };
    }

    public void ReleaseAsset(string address)
    {
        if (_loadedAssets.TryGetValue(address, out var handle))
        {
            Addressables.Release(handle);
            _loadedAssets.Remove(address);
        }
    }
}
