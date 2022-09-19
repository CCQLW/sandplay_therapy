using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour
{
    private Transform[] weapons;
    void Awake()
    {
        weapons = transform.GetComponentsInChildren<Transform>(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void switchWeapon(int pre, int st)
    {
        if(pre > 0 && pre < weapons.Length && st > 0 && st < weapons.Length && pre != st)
        {
            weapons[pre].gameObject.SetActive(false);
            transform.GetChild(st - 1).gameObject.SetActive(true);
        }   
        
    }
}
