using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammunition : MonoBehaviour
{
    [SerializeField] int ammoAmount;
    [SerializeField] Text ammoText;

    public int GetCurrentAmmo()
    {
        return ammoAmount;
    }

    public void IncreaseCurrentAmmo(int amount)
    {
        ammoAmount += amount;
        ammoText.text = "M4A1: " + ammoAmount;
    }

    public void ReduceCurrentAmmo()
    {
        ammoAmount--;
        ammoText.text = "M4A1: " + ammoAmount;
    }
}

