public interface IAddressableLoader<T>
{
    void Load(string address, System.Action<T> onLoaded);
    void Release(T asset);
}
