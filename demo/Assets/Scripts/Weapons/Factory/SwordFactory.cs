using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFactory : WeaponFactory
{
    // Start is called before the first frame update
    public AttackEnemy createAttackEnemy()
    {
        return new SwordAttackEnemy();
    }
}
