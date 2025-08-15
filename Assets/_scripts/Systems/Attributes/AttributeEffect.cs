using System;

public enum EffectDurationType
{
    Overtime,
    Constant,
    Instant,
}

public enum EffectChangeType
{
    Increase,
    Decrease
}

[System.Serializable]
public class AttributeEffect
{
    public AttributeType AttributeType = AttributeType.Hunger; 
    public EffectDurationType DurationType = EffectDurationType.Instant;
    public EffectChangeType ChangeType = EffectChangeType.Increase;
    public float Amount = 0f;
    public float Duration = 0f;

    [NonSerialized] private float _timeElapsed;

    public AttributeEffect() { }

    public AttributeEffect(EffectDurationType durationType, EffectChangeType changeType, float amount, float duration = 0f)
    {
        DurationType = durationType;
        ChangeType = changeType;
        Amount = amount;
        Duration = duration;
        _timeElapsed = 0f;
    }

    // Retorna true se efeito terminou
    public bool UpdateEffect(float deltaTime, Action<float> applyChange)
    {
        switch (DurationType)
        {
            case EffectDurationType.Instant:
                applyChange(ChangeType == EffectChangeType.Increase ? Amount : -Amount);
                return true; // efeito concluído

            case EffectDurationType.Overtime:
                if (_timeElapsed < Duration)
                {
                    _timeElapsed += deltaTime;
                    float deltaAmount = (Amount * deltaTime) / Duration;
                    applyChange(ChangeType == EffectChangeType.Increase ? deltaAmount : -deltaAmount);
                    return false; // ainda ativo
                }
                return true; // concluído

            case EffectDurationType.Constant:
                applyChange(ChangeType == EffectChangeType.Increase ? Amount * deltaTime : -Amount * deltaTime);
                return false; // nunca expira sozinho
            default:
                return true;
        }
    }
}
