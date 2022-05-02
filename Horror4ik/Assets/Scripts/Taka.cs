using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Taka : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private GameObject car;

    [SerializeField] private Animator animator;
    private void Update()
    {
        car.transform.position = new Vector3(4.3f, 0.85f, car.transform.position.z + speed * Time.deltaTime);
    }

    private void Awake()
    {
        animator.SetBool("UnSleep", true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Sleep")
        {
            animator.SetBool("Sleep", true);
        }
        if(other.transform.tag == "SceneLoader")
        {
            SceneManager.LoadScene("NazikGavno");
        }
    }
}
