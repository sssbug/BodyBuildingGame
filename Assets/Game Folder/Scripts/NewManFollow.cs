using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewManFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;


    void Update()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y, Mathf.Lerp(transform.position.z, target.position.z + offset.z, Time.deltaTime * 100f)); 
    }
}
 