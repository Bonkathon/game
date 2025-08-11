using UnityEngine;

public class AddressablesPreload : MonoBehaviour
{
    [SerializeField] private string[] preloadAssets;

    void Start()
    {
        foreach (var asset in preloadAssets)
        {
            AddressablesLoader.Load<Object>(asset, _ => { Debug.Log($"Pré-carregado: {asset}"); });
        }
    }
}
