using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whoDoIFollow : MonoBehaviour
{
    public GameObject whereDoILook;
    public Vector3 offset = new Vector3(0, 0, 1);

    
    void FixedUpdate()
    {
        transform.position = new Vector3(
                whereDoILook.transform.position.x + offset.x,
                whereDoILook.transform.position.y + offset.y,
                whereDoILook.transform.position.z + offset.z);
    }
}
