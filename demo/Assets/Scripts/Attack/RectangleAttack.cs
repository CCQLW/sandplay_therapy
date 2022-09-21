using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleAttack : MonoBehaviour
{
    public string attacks;      //攻击名称
    public float length;        //攻击长度
    public float width;         //攻击宽度
    public Transform wideCenter; //宽度中心
    public LayerMask layerMask;//检测到物体的层级
    public float injury;        //伤害
    private float radius;       //圆半径
    public Vector2 p1, p2, p3, p4; //矩形四顶点,顺时针
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
        radius = Mathf.Sqrt(length * length + width * width * 0.25f);
        width /= 2.0f;
        float faceRotation = transform.rotation.y / 180 * Mathf.PI;
        p1 = new Vector2(transform.position.x + width * Mathf.Cos(faceRotation - 0.5f * Mathf.PI), 
            transform.position.z + width * Mathf.Sin(faceRotation - 0.5f * Mathf.PI));
        p2 = new Vector2(transform.position.x + width * Mathf.Cos(faceRotation + 0.5f * Mathf.PI),
            transform.position.z + width * Mathf.Sin(faceRotation + 0.5f * Mathf.PI));
        p3 = new Vector2(p2.x + length * Mathf.Cos(faceRotation), p2.y + length * Mathf.Sin(faceRotation));
        p4 = new Vector2(p1.x + length * Mathf.Cos(faceRotation), p1.y + length * Mathf.Sin(faceRotation));
        Collider[] enemys = Physics.OverlapSphere(transform.position, radius, layerMask);
        if (enemys.Length > 0)
        {
            foreach (var enemy in enemys)
            {
                if (InFanAttack(enemy))
                {
                    print(enemy.name);
                }
            }
        }

    }
    public bool InFanAttack(Collider enemy)
    {
        Vector2 p = new Vector2(enemy.transform.position.x, enemy.transform.position.z);
        //(p2-p1 X p-p1 ) *(p4-p3 X p-p3)  >= 0 && (p3-p2 X p-p2 ) *(p1-p4 X p-p4) >= 0 。
        if(GetCross(p1, p2, p) * GetCross(p3, p4, p) >= 0 && GetCross(p2, p3, p) * GetCross(p4, p1, p) >= 0)
        {
            return true;
        }
        return false;
    }
    
    private float GetCross(Vector2 p1, Vector2 p2 ,Vector2 p)
    {
        return (p2.x - p1.x) * (p.y - p1.y) - (p.x - p1.x) * (p2.y - p1.y);
    }
}
