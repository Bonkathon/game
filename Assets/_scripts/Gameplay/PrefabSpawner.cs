using UnityEngine;

public class PrefabSpawner : MonoBehaviour, IAddressableLoader<GameObject>
{
    public void Load(string address, System.Action<GameObject> onLoaded)
    {
        AddressablesLoader.Load<GameObject>(address, prefab =>
        {
            Instantiate(prefab, Vector3.zero, Quaternion.identity);
            onLoaded?.Invoke(prefab);
        });
    }

    public void Release(GameObject asset)
    {
        if (asset != null)
            AddressablesLoader.Release(asset.name);
    }
}
