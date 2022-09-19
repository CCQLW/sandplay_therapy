using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayKnapsack : MonoBehaviour
{
    static DisplayKnapsack instance;//单例模式
    public PropList proplist;//存放背包中所有的道具
    public Equipment equipmentPrafab;
    public GameObject knapsack;//背包
    void Awake()
    {
        if(instance != null)
        {
            Destroy(instance);
        }
        else instance = this;
    }
    void OnEnable()
    {
        updateKnapsack();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void insertProp(Prop prop)
    {
        Equipment equipment = Instantiate(instance.equipmentPrafab,instance.knapsack.transform);
        equipment.equipmentImage.sprite = prop.propImage;
        equipment.numberText.text = prop.propNumber.ToString();
    }

    public static void updateKnapsack()
    {
        for(int i = 0; i < instance.knapsack.transform.childCount; i++)
        {
            Destroy(instance.knapsack.transform.GetChild(i).gameObject);
        }
        for(int i = 0; i < instance.proplist.propList.Count; i++)
        {
            insertProp(instance.proplist.propList[i]);
        }
    }
}
