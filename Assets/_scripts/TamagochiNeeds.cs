using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Tamagochi Needs", menuName="Scriptable/Tamagochi/Needs", order=2)]
public class TamagochiNeeds : ScriptableObject
{
    public new string name;
    public float timeDecay;
}
