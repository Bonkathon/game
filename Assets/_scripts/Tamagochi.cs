using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tamagochi : MonoBehaviour
{
    Dictionary<string, TamagochiNeedsEnum> tamagochiNeeds = new();

    // Start is called before the first frame update
    void Start()
    {
        foreach (TamagochiNeedsEnum need in System.Enum.GetValues(typeof(TamagochiNeedsEnum)))
        {
            // tamagochiNeeds.Add(need, )
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NeedsDecay()
    {
        
    }
}
