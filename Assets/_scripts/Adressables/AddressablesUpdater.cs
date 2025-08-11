using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressablesUpdater : MonoBehaviour
{
    public void CheckForUpdates()
    {
        Addressables.CheckForCatalogUpdates().Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded && handle.Result.Count > 0)
            {
                Debug.Log("Atualizações encontradas. Baixando...");
                Addressables.UpdateCatalogs(handle.Result);
            }
            else
            {
                Debug.Log("Nenhuma atualização encontrada.");
            }
        };
    }
}
