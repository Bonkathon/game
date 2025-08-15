using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TamagochiBaseAttribute
{
    public AttributeType AttributeType = AttributeType.Hunger;
    public float MaxValue = 100f;
}

[CreateAssetMenu(fileName = "New TamagochiAttributeData", menuName = "Tamagochi/AttributeData")]
public class TamagochiAttributeData : ScriptableObject
{
    [Header("Atributos base")]
    public List<TamagochiBaseAttribute> BaseAttributes = new List<TamagochiBaseAttribute>();

    [Header("Efeitos iniciais")]
    public List<AttributeEffect> InitialEffects = new();
}
