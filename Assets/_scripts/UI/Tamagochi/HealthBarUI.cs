using UnityEngine;
using UnityEngine.UI;

public class TamagochiHealthBarUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TamagochiNeedsController needs;

    private float _maxVida = 100f;

    private void Awake()
    {
        if (image == null) image = GetComponentInChildren<Image>();
        if (image != null) image.fillAmount = 1f;
        if (needs == null) needs = GetComponentInParent<TamagochiNeedsController>();
    }

    private void Start()
    {
        if (needs != null && needs.BaseData != null)
        {
            _maxVida = Mathf.Max(1f, needs.GetAttributeMaxValue(AttributeType.Health));
        }
    }

    private void Update()
    {
        if (needs == null || image == null) return;
        float vida = needs.GetAttributeValue(AttributeType.Health);
        image.fillAmount = Mathf.Clamp01(_maxVida > 0f ? vida / _maxVida : 0f);
    }
}
