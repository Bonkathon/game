using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamagochiController : MonoBehaviour
{
    [SerializeField] Tamagochi _tamagochi;
    [SerializeField] TamagochiData _tamagochiData;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            InitializeTamagochi(_tamagochiData);
        }
    }

    public void InitializeTamagochi(TamagochiData tamaData)
    {
        GameObject tamaGO = Instantiate(tamaData.baseModel);
        tamaGO.transform.SetParent(_tamagochi.transform);
    }
}
