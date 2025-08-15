using System.Collections.Generic;
using UnityEngine;

public class TamagochiNeedsController : MonoBehaviour
{
    [Header("Dados base do Tamagochi")]
    public TamagochiAttributeData BaseData;

    private Dictionary<AttributeType, Attribute> _attributes = new();

    private void Awake()
    {
        if (BaseData == null)
        {
            Debug.LogError("BaseData não definido no TamagochiNeedsController.");
            return;
        }

        foreach (TamagochiBaseAttribute attr in BaseData.BaseAttributes)
        {
            Attribute _attr = new Attribute(attr.AttributeType, attr.MaxValue, attr.MaxValue);
            _attributes.Add(_attr.Type, _attr);
        }

        foreach (AttributeEffect effect in BaseData.InitialEffects)
        {
            AddEffect(effect.AttributeType, effect);
        }
    }

    private void Update()
    {
        float dt = Time.deltaTime;
        foreach (var attr in _attributes.Values)
            attr.Update(dt);

        // Debug.Log($"Health: {_attributes[AttributeType.Health].Value}");
    }

    #region Funções públicas

    public float GetAttributeValue(AttributeType type)
    {
        return _attributes.TryGetValue(type, out var attr) ? attr.Value : 0f;
    }

    public float GetAttributeMaxValue(AttributeType type)
    {
        return _attributes.TryGetValue(type, out var attr) ? attr.MaxValue : 0f;
    }

    #endregion

    #region Helpers privados

    private void AddEffect(AttributeType type, AttributeEffect effect)
    {
        if (_attributes.TryGetValue(type, out var attr))
        {
            attr.AddEffect(effect);
        }
    }

    #endregion
}
