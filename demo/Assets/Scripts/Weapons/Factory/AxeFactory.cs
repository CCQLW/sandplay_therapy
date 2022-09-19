using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeFactory : WeaponFactory
{
    public AttackEnemy createAttackEnemy()
    {
        return new AxeAttackEnemy();
    }
}
