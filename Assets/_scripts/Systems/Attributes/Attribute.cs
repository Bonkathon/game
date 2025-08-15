using System.Collections.Generic;
using UnityEngine;

public class Attribute
{
    public AttributeType Type { get; }
    public float Value { get; private set; }
    public float MaxValue { get; }

    private readonly List<AttributeEffect> _effects = new();

    public Attribute(AttributeType type, float initialValue, float maxValue)
    {
        Type = type;
        Value = initialValue;
        MaxValue = maxValue;
    }

    public void AddEffect(AttributeEffect effect)
    {
        _effects.Add(effect);
    }

    public void Update(float deltaTime)
    {
        // Debug.Log($"Ticking attribute {Type}.");
        for (int i = _effects.Count - 1; i >= 0; i--)
        {
            bool finished = _effects[i].UpdateEffect(deltaTime, ChangeValue);
            if (finished)
            {
                Debug.Log($"Removed attribute effect {i} on {_effects[i].AttributeType}.");
                _effects.RemoveAt(i);
            }
        }
    }

    private void ChangeValue(float amount)
    {
        Value = Mathf.Clamp(Value + amount, 0, MaxValue);
    }
}
