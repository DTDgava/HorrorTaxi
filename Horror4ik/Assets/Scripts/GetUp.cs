using UnityEngine;

public class GetUp : MonoBehaviour
{
    private Animator animator;
    public float k = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (k == 0)
        {
            animator.SetBool("GetUp", true);
        }
    }

    private void Update()
    {
        if (k == 1)
        {
            animator.SetBool("GetUp", false);
        }
    }
}
