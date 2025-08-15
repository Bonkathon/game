using UnityEngine;

[CreateAssetMenu(fileName="New Tamagochi Data", menuName="Scriptables/Tamagochi/Data", order=1)]
public class TamagochiData : ScriptableObject
{
    public new string name;
    public TamagochiTypeEnum type;
    public GameObject egg;
    public GameObject baseModel;
    public GameObject evoModel;
}
