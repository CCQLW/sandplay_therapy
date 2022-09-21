using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject door;
    private float initDoor_y;
    public bool openDoor = false;
    // Start is called before the first frame update
    void Start()
    {
        initDoor_y = door.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(openDoor == true)
        {
            StartCoroutine("Open");
        }
        if(door.transform.localPosition.y >= initDoor_y + 10.0f && openDoor == true)
        {
            StopCoroutine("Open");
            openDoor = false;
        }
        
    }
    IEnumerator Open()
    {
        while(door.transform.localPosition.y < initDoor_y + 10.0f)
        {
            Vector3 MoveValue = Vector3.zero;
            MoveValue += Vector3.up * 0.05f;
            door.transform.localPosition += MoveValue;
            if(door.transform.localPosition.y >= initDoor_y + 10.0f)
            {
                break;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
