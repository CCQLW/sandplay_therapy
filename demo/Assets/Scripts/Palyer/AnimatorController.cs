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
        if(Input.GetKey(KeyCode.S))setBool("backWalk", true);
        else setBool("backWalk", false);
        if(Input.GetKey(KeyCode.A))setBool("leftWalk", true);
        else setBool("leftWalk", false);
        if(Input.GetKey(KeyCode.D))setBool("rightWalk", true);
        else setBool("rightWalk", false);
        if(Input.GetKey(KeyCode.E))setBool("defend", true);
        else setBool("defend", false);


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
