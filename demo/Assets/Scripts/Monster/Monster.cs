using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    //速度
    public float speed = 12f;
    //警戒范围
    public float alertScope = 100;
    //攻击范围
    public float attackScope = 10;
    //攻击间隔
    public float attackTime = 3;
    //是否攻击
    public bool attackFlag = true;
    //攻击时间
    public float attackingTime = 3;
    //普通技能组
    public FanAttack[] attackss;
    //终结技组
    public FanAttack[] finishArts;
    //消失中
    private bool disappear = false;
    //消失时间
    public float disTime = 5;
    //当前消失是将
    public float disTimeNow = 0;

    //是否死亡
    public bool dieTlag = false;
    //总生命值
    public float HPMax = 100;
    //当前生命值
    private float health = 100;
    //攻击力
    private float attack = 10;
    //防御
    private float defense = 10;
    //韧性
    private float toughness = 10;
    //转向速度
    private float turnSpeed = 0.01f;

    //目标坐标
    public Transform targetTransform;
    //是否检测到玩家
    public bool playFlag = false;

    //寻路组件
    public UnityEngine.AI.NavMeshAgent m_agent;

    public Animator anim;

    private Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //球形检测玩家
    public Collider[] DetectPlayer(){
        Collider[] plays = Physics.OverlapSphere(this.transform.position, alertScope, 1 << 7);
        return plays;
    }

    //转圈
    public void Turn()
    {
        targetRotation = Quaternion.LookRotation(targetTransform.transform.position - this.transform.position, Vector3.up);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, turnSpeed);
    }

    //调用消失脚本
    public void Disappear(){
        if(!disappear){
            disappear = true;
            this.GetComponent<Disappear>().FadeOut(disTime);
        }
    }

    public void SetHealth(float x){
        health += x;
    }

    public float GetHealth(){
        return health;
    }

    public void SetAttack(float x){
        attack += x;
    }

    public float GetAttack(){
        return attack;
    }

    public void SetDefense(float x){
        defense += x;
    }
    
    public float GetDefense(){
        return defense;
    }

    public void SetToughness(float x){
        toughness += x;
    }
    
    public float GetToughness(){
        return toughness;
    }

    public void SetSpeed(float x){
        speed += x;
    }
}
