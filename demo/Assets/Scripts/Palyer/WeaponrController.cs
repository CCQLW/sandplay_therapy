using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponrController : MonoBehaviour
{
    private int st_weapon = 3;
    public GameObject Weapon;
    private SwitchWeapons switchWeapons;
    // Start is called before the first frame update
    void Start()
    {
        switchWeapons = Weapon.GetComponent<SwitchWeapons>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            switchWeapons.switchWeapon(st_weapon, 1);
            st_weapon = 1;
        }
        if(Input.GetKey(KeyCode.Alpha2))
        {
            switchWeapons.switchWeapon(st_weapon, 2);
            st_weapon = 2;
        }
        if(Input.GetKey(KeyCode.Alpha3))
        {
            switchWeapons.switchWeapon(st_weapon, 3);
            st_weapon = 3;
        }

    }
}
