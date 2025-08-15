using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Tamagochi Needs", menuName="Scriptables/Tamagochi/Needs", order=2)]
public class TamagochiNeedsType : ScriptableObject
{
    public new string name;
    public float timeDecay;
}
