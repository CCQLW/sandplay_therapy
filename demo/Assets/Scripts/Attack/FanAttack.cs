using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanAttack : MonoBehaviour
{
    public string attacks;      //攻击名称
    public float radius;//攻击范围
    public float angle;//攻击扇形角度
    public LayerMask layerMask;//检测到物体的层级
    public float injury;//伤害
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack()
    {
        Collider[] enemys = Physics.OverlapSphere(transform.position, radius, layerMask);
        if(enemys.Length > 0)
        {
            foreach(var enemy in enemys)
            {
                if(inFanAttack(enemy))
                {
                    print(enemy.name);
                }
            }
        }
        
    }
    public bool inFanAttack(Collider enemy)
    {
        Vector3 norvec = transform.rotation * Vector3.forward;//方向向量
        Vector3 temvec = enemy.gameObject.transform.position - transform.position;
        float enemy_angle = Mathf.Acos(Vector3.Dot(norvec.normalized, temvec.normalized)) * Mathf.Rad2Deg;
        if(enemy_angle <= angle * 0.5f)return true;
        return false;
    }
}
