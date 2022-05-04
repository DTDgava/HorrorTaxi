using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPos : MonoBehaviour
{
    public bool CanTalk; 
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "StartDialougeDed")
        {
            CanTalk = true;
         
        }
    }
}
