using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoShotgun: MonoBehaviour
{
    [SerializeField] int ammoAmount;
    [SerializeField] Text ammoText;

    public int GetCurrentAmmo()
    {
        return ammoAmount;
    }

    public void ReduceCurrentAmmo()
    {
        ammoAmount--;
        ammoText.text = "Shotgun: " + ammoAmount;
    }

    public void IncreaseCurrentAmmo(int amount)
    {
        ammoAmount += amount;
        ammoText.text = "Shotgun: " + ammoAmount;
    }
}