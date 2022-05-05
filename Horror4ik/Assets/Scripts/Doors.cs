using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Doors : MonoBehaviour
{
    [SerializeField] private Text OpenDoor;
    [SerializeField] public bool Key;
    [SerializeField] private float SpeedOpen;
    [SerializeField] private float AngleRotDoor;
    [SerializeField] private bool StartOpenDoor;
    [SerializeField] private GameObject Door;
    [SerializeField] private Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Door1")
        {
            OpenDoor.gameObject.SetActive(true);
            if (Key == true)
            {
                OpenDoor.text = "Press E To Open Door";
            }
            else if (Key == false)
            {
                OpenDoor.text = "No Key";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
       if(other.tag == "Door1")
        {
            OpenDoor.gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Door1" & Key == true & Input.GetKeyDown(KeyCode.E))
        {
            StartOpenDoor = true;
            animator.SetBool("OpenDoor", true);
        }
    }
    private void Update()
    {
        if(StartOpenDoor == true)
        {
                StartOpenDoor = false;
                Key = false;
                animator.SetBool("OpenDoor", false);
            Door.transform.rotation = new Quaternion(0, -95, 0, 0);
        }
    }
}
