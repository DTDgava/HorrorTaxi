using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text nameText;
    public Text dialougeText;
    public GameObject startDialouge;

    public Animator Ded;
    public Animator animator;
    public GameObject TriggerDed;
    public Dialouge dialouge;
    public GameObject CatScene;
    void Start()
    {
        sentences = new Queue<string> ();
        startDialouge.SetActive(false);
        TriggerDed.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Dialouge1")
        {
            CatScene.SetActive(true);
            startDialouge.SetActive(true);

            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void StartDialouge(Dialouge dialouge) 
    {
        animator.SetBool("isOpen", true);
        nameText.text = dialouge.name;

        sentences.Clear();

        foreach(string sentece in dialouge.sentences)
        {
            sentences.Enqueue(sentece); 
        }

        DisplayNextSentence();
        startDialouge.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextSentence();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartDialouge(dialouge);
        }
    }
    public void DisplayNextSentence()
    {
        Debug.Log("snus");
        if(sentences.Count == 0)
        {
            EndDialouge();
            return;
        }
        string sentence = sentences.Dequeue();

        dialougeText.text = sentence;
    }

    void EndDialouge()
    {
        Debug.Log("End dialouge");
        startDialouge.SetActive(false);
        animator.SetBool("isOpen", false);
        Cursor.lockState = CursorLockMode.Locked;
        TriggerDed.SetActive(false);
        CatScene.SetActive(false);
    }
   
}
