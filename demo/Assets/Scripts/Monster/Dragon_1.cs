using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_1 : Monster
{

    Vector3 lastpos;                    //上帧坐标
    bool violent = false;               //是否狂暴
    private int attacks;                //普遍技能编号
    private bool flyAttack = false;     //是否飞行攻击
    private int index;                  //终结技索引

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();                            //获取Animator组件
        m_agent = GetComponent<UnityEngine.AI.NavMeshAgent>();      //获取寻路组件
        lastpos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var animTime = anim.GetCurrentAnimatorStateInfo(0);
        if(dieTlag){
            if(animTime.normalizedTime >= 0.99999f && animTime.IsName("Die")){
                Disappear();
                disTimeNow += Time.deltaTime;
                if(disTimeNow >= disTime){
                    this.gameObject.SetActive(false);
                }
            }
        }
        else{
            //四分之一血下狂暴
            if(!violent && GetHealth() < (HPMax * 0.25)){
                violent = true;
                attackTime = 2;
            }
            //死亡
            if(GetHealth() <= 0){
                anim.SetTrigger("die");
                dieTlag = true;
            }
            flyAttack = animTime.IsTag("Fly Attack");
            Vector3 curpos = transform.position;
            float _speed = (Vector3.Magnitude(curpos - lastpos) / Time.deltaTime);  //获取移动速度
            lastpos = curpos;
            if(!playFlag){
                //球形检测玩家
                Collider[] plays = DetectPlayer();
                if(plays.Length > 0){
                    targetTransform = plays[0].gameObject.transform;
                    playFlag = true;
                    anim.SetTrigger("scream");
                }
            }
            else if(animTime.IsName("Scream 1")){
                m_agent.isStopped = true;
            }
            else {
                Pathfinding();
                Transform myTransform = this.transform;
                Vector3 diffPosition = targetTransform.position - myTransform.position;     //获取差值
                float distance = diffPosition.magnitude;
                float dot = Vector3.Dot(diffPosition.normalized, myTransform.forward);      //获取夹角
                if(distance < attackScope){
                    m_agent.isStopped = true;
                    if(!attackFlag){
                        if(violent && !flyAttack){
                            index = Random.Range(0, finishArts.Length * 4);
                            if(index < finishArts.Length){
                                flyAttack = true;
                                anim.SetTrigger(finishArts[index].attacks);
                            }
                        }
                        if(!flyAttack){
                            attackFlag = true;
                            attacks = Random.Range(0, attackss.Length);
                            anim.Play(attackss[attacks].attacks);
                        }
                        Attack();
                    }
                    else{
                        attackingTime += Time.deltaTime;
                        if(attackingTime > attackTime){
                            if(dot < 0.99){
                                Turn();
                                _speed = 1;
                            }
                        }
                        if(attackingTime > attackTime * 2){
                            attackFlag = false;
                            attackingTime = 0;
                        }
                    }
                }
                else if(distance < alertScope){
                    anim.SetFloat("speed", speed);
                    m_agent.isStopped = false;
                }
                else if(distance > alertScope){
                    m_agent.isStopped = true;
                    anim.SetFloat("speed", 0f);
                    playFlag = false;
                }
            }
            anim.SetFloat("speed", _speed);
        }
    }

    public void Attack(){
        if(flyAttack && index < finishArts.Length){
            finishArts[index].Attack();
        }
        else{
            attackss[attacks].Attack();
        }
    }

    void AnimUpdate(){
        
    }

    void Pathfinding(){
        //获得寻路组件
        m_agent.speed = speed;
        m_agent.SetDestination(targetTransform.position);
    }
}
