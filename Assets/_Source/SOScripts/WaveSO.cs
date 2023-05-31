using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveSO", menuName = "ScriptableObjects/WaveSO", order = 1)]
public class WaveSO : ScriptableObject
{
    public int amountOfCloseCombatTurrets;
    public int amountOfRAyCastTurrets;
    public int amountOfRocketTurrets;
   
}
