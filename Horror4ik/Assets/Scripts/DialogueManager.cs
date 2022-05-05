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
    public FirstPersonController Player;
    public Transform move;
    public CheckPos CheckPos;
    bool Cantalk;
    bool needcheck = true;
    [SerializeField] public Doors door;

    void Start()
    {
        sentences = new Queue<string>();
        TriggerDed.SetActive(true);
        dialougeText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Dialouge1")
        {
            CatScene.SetActive(true);
            door.Key = true;
        }
    }

    public void StartDialouge(Dialouge dialouge)
    {
        Player.playerCanMove = false;
        dialougeText.gameObject.SetActive(true);
        animator.SetBool("isOpen", true);
        nameText.text = dialouge.name;

        sentences.Clear();

        foreach (string sentece in dialouge.sentences)
        {
            sentences.Enqueue(sentece);
        }

        DisplayNextSentence();
        Cantalk = false;
        needcheck = false;
    }
    private void Update()
    {
        if (needcheck == true)
        {
            Cantalk = CheckPos.CanTalk;
        }
        if (Cantalk == true)
        {
            StartDialouge(dialouge);
        }
        if (Input.GetKeyDown(KeyCode.Space) & dialougeText.gameObject.activeSelf == true)
        {
            DisplayNextSentence();
        }
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialouge();
            return;
        }
        string sentence = sentences.Dequeue();

        dialougeText.text = sentence;
    }

    void EndDialouge()
    {
        CatScene.SetActive(false);
        dialougeText.gameObject.SetActive(false);
        animator.SetBool("isOpen", false);
        TriggerDed.SetActive(false);
        CatScene.SetActive(false);
        Player.playerCanMove = true;
    }

}
