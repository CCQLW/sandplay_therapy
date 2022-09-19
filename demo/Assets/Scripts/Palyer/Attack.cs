using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController playerController;
    public AnimatorController animatorController;
    public FanAttack fanAttack;
    private bool attack;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isAttack();
    }
    void isAttack()
    {
        if(playerController.health > 0)
        {
            if(Input.GetMouseButtonDown(0))
            {
                animatorController.setBool("attack", true);
                fanAttack.Attack();
            }
            if(Input.GetMouseButtonUp(0))
            {
                animatorController.setBool("attack", false);
            }
            if(Input.GetMouseButtonDown(1))
            {
                animatorController.setBool("thump", true);
                fanAttack.Attack();
            }
            if(Input.GetMouseButtonUp(1))
            {
                animatorController.setBool("thump", false);
            }
        }
    }
}
