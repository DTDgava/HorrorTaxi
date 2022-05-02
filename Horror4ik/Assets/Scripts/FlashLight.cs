using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject trigger;
    public GameObject mainFlashLight;
    public GameObject light1;

    private void Start()
    {
        light1.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && light1.activeSelf == false)
        {
            light1.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.F) && light1.activeSelf == true)
        {
            light1.SetActive(false);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Flash" && Input.GetKey(KeyCode.E))
        {
            trigger.SetActive(false);
            mainFlashLight.SetActive(true);
        }
    }



}
