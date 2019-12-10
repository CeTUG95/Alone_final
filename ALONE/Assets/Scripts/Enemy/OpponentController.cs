using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{

    //public EnemyAi[] enemies;

    
    public EnemyAi ai;
    public EnemyAi ai2;
    public EnemyAi ai3;
    public EnemyAi ai4;
    public EnemyAi ai5;
    public EnemyAi ai6;
    public EnemyAi ai7;
    public EnemyAi ai8;
    public EnemyAi ai9;
    

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
        print(opponentsLeft);

        if (opponentsLeft == 0)
        {
            Debug.Log("all dead");
            audioSource.Stop();
        }
    }

    public void opponentHasAppeared()
    {
        opponentsLeft++;
        print(opponentsLeft);
    }

    private void Update()
    {

        /*
        foreach (EnemyAi enemy in enemies)
        {
            bool notProvoked = enemy.GetIsProvoked();

            if (enemies.Length == 1 || !notProvoked)
            {
                //if (!notProvoked)
                //{
                    Debug.Log("HI, HIER BIN ICH");
                    audioSource.Play();
                //}
            }
            
            
        }
        */
        
        bool notProvoked = ai.GetIsProvoked();
        bool notProvoked2 = ai2.GetIsProvoked();
        bool notProvoked3 = ai3.GetIsProvoked();
        bool notProvoked4 = ai4.GetIsProvoked();
        bool notProvoked5 = ai5.GetIsProvoked();
        bool notProvoked6 = ai6.GetIsProvoked();
        bool notProvoked7 = ai7.GetIsProvoked();
        bool notProvoked8 = ai8.GetIsProvoked();
        bool notProvoked9 = ai9.GetIsProvoked();
        

        
        if (!notProvoked && !notProvoked2 && !notProvoked3 && !notProvoked4 && !notProvoked5 && !notProvoked6 && !notProvoked7 && !notProvoked8 && !notProvoked9)
        {
            audioSource.Play();

        }

        // calls exceptions on setDestination for enemy
        /*
        if (notProvoked || notProvoked2 ||  notProvoked3 ||  notProvoked4 ||  notProvoked5 || notProvoked6 ||  notProvoked7 || notProvoked8 || notProvoked9)
        {
            ai.EngageTarget();
            ai2.EngageTarget();
            ai3.EngageTarget();
            ai4.EngageTarget();
            ai5.EngageTarget();
            ai6.EngageTarget();
            ai7.EngageTarget();
            ai8.EngageTarget();
            ai9.EngageTarget();
        }
        */

    }

}
