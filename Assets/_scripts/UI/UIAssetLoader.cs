using UnityEngine;
using UnityEngine.UI;

public class UIAssetLoader : MonoBehaviour, IAddressableLoader<Sprite>
{
    [SerializeField] private Image targetImage;

    public void Load(string address, System.Action<Sprite> onLoaded)
    {
        AddressablesLoader.Load<Sprite>(address, sprite =>
        {
            targetImage.sprite = sprite;
            onLoaded?.Invoke(sprite);
        });
    }

    public void Release(Sprite asset)
    {
        if (asset != null)
            AddressablesLoader.Release(asset.name);
    }
}
