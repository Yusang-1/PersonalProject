using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public float gold {  get; private set; }

    public void Start()
    {
        gold = 0;
    }
    public void GetGold(float add)
    {
        gold += add;
    }
}
