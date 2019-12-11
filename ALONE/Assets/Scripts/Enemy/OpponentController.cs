using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{
    public EnemyAi ai;
    public EnemyAi ai2;
    public EnemyAi ai3;
    public EnemyAi ai4;
    public EnemyAi ai5;
    public EnemyAi ai6;
    public EnemyAi ai7;
    public EnemyAi ai8;
    public EnemyAi ai9;
    public EnemyAi ai10;
    public EnemyAi ai11;
    public EnemyAi ai12;


    private AudioSource audioSource;
    public AudioClip clip;

    private int opponentsLeft;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void opponentHasDied()
    {
        opponentsLeft--;
        //print(opponentsLeft);

        if (opponentsLeft == 0)
        {
            //Debug.Log("all dead");
            audioSource.Stop();
        }
    }

    public void opponentHasAppeared()
    {
        opponentsLeft++;
        //print(opponentsLeft);
    }

    private void Update()
    {
        bool notProvoked = ai.GetIsProvoked();
        bool notProvoked2 = ai2.GetIsProvoked();
        bool notProvoked3 = ai3.GetIsProvoked();
        bool notProvoked4 = ai4.GetIsProvoked();
        bool notProvoked5 = ai5.GetIsProvoked();
        bool notProvoked6 = ai6.GetIsProvoked();
        bool notProvoked7 = ai7.GetIsProvoked();
        bool notProvoked8 = ai8.GetIsProvoked();
        bool notProvoked9 = ai9.GetIsProvoked();
        bool notProvoked10 = ai10.GetIsProvoked();
        bool notProvoked11 = ai11.GetIsProvoked();
        bool notProvoked12 = ai12.GetIsProvoked();

        if (!notProvoked && !notProvoked2 && !notProvoked3 && !notProvoked4 && !notProvoked5 && !notProvoked6 && !notProvoked7 && !notProvoked8 && !notProvoked9 && !notProvoked10 && !notProvoked11 && !notProvoked12)
        {
            audioSource.Play();

        }

    }

}
