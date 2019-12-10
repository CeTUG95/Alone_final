using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUi : MonoBehaviour
{

    [SerializeField] Canvas impact;
    [SerializeField] float impactTime = 0.3f;

    void Start()
    {
        impact.enabled = false;
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(ShowBlood());
    }
    
    IEnumerator ShowBlood()
    {
        impact.enabled = true;
        yield return new WaitForSeconds(impactTime);
        impact.enabled = false;
    }
}
