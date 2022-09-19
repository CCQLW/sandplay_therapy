using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Prop", menuName = "Knapsack/New Prop")]
public class Prop : ScriptableObject
{
    public string propName;
    public Sprite propImage;
    public int propNumber;
    [TextArea]
    public string propInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
