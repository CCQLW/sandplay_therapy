using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void setBool(string name, bool flag)
    {
        animator.SetBool(name, flag);
    }
    public void setFloat(string name, float val)
    {
        animator.SetFloat(name, val);
    }
}
