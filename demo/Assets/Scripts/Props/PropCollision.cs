using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropCollision : MonoBehaviour
{
    public Prop prop;
    public PropList proplist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.name.Equals("Player"))
        {
            
            if(!proplist.propList.Contains(prop))proplist.propList.Add(prop);
            prop.propNumber += 1;
            DisplayKnapsack.updateKnapsack();
            Destroy(this.gameObject);
        }
    }
}
