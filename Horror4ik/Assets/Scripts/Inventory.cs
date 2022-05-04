using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject Note;
    [SerializeField] private GameObject ReadNote;
    [SerializeField] private string[] BackFrontPaper;
    [SerializeField] bool back = false;
    [SerializeField] private FirstPersonController FRCPlayer;
    [SerializeField] private Text TextNote;
    bool InTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Note")
        {
            ReadNote.SetActive(true);
            InTrigger = true;
        }
    }
    private void Update()
    {
        if (InTrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.E) & ReadNote.activeSelf == true)
            {
                Note.SetActive(true);
                FRCPlayer.enabled = false;
                ReadNote.SetActive(false);
            }
            if (Note.activeSelf == true)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Note.SetActive(false);
                    FRCPlayer.enabled = true;
                    ReadNote.SetActive(true);
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    if (back == true)
                    {
                        back = false;
                        TextNote.text = BackFrontPaper[0];

                    }
                    else if (back == false)
                    {
                        back = true;
                        TextNote.text = BackFrontPaper[1];
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Note")
        {
            ReadNote.SetActive(false);
            InTrigger = false;
        }
    }
}
