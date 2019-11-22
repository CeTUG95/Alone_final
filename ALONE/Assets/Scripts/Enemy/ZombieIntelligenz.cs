using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIntelligenz : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float rotatingSpeed = 70f;

    private bool iswalking = false;
    private bool iswandering = false;
    private bool isrotateleft = false;
    private bool isrotateright = false;
  
    void Start()
    {
        
    }

   
    void Update()
    {
        if(iswandering ==false)
        {
            StartCoroutine(Wander());
        }
        if(isrotateright==true)
        {
            transform.Rotate(transform.up * Time.deltaTime * moveSpeed);
            GetComponent<Animator>().SetTrigger("move");
        }
        if (isrotateright == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -moveSpeed);
            GetComponent<Animator>().SetTrigger("move");
        }

        if (iswalking == true)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            GetComponent<Animator>().SetTrigger("move");
        }

    }

    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 4);
        int rotatewait = Random.Range(1, 3);
        int rotateright = Random.Range(1, 5);
        int walkwait = Random.Range(1,4);
        int walktime = Random.Range(1, 4);

        iswandering = true;

        yield return new WaitForSeconds(walkwait);
        iswalking = true;

        yield return new WaitForSeconds(walktime);
        iswalking = false;

        yield return new WaitForSeconds(rotatewait);
        if(rotateright == 1)
        {
            isrotateright = true;
            yield return new WaitForSeconds(rotTime);
            isrotateright = false;

        }
        if(rotateright==2)
        {
            isrotateleft = true;
            yield return new WaitForSeconds(rotTime);
            isrotateleft = false;
        }

    }
}
