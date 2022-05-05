using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSecondScene : MonoBehaviour
{
    [SerializeField] private float TimeForGetUp;
    [SerializeField] private FirstPersonController Player;
    [SerializeField] private Animator animator;
        // Start is called before the first frame update
    void Start()
    {
        Player.playerCanMove = false;
        animator.SetBool("UnSleep", true);

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > TimeForGetUp)
        {
            animator.SetBool("UnSleep", false);

            Player.playerCanMove = true;
        }
    }
}
