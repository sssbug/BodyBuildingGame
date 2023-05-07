using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    
    public Transform connectedNode;
    private Movement nodeScript;
    private void OnEnable()
    {
        nodeScript = GameObject.Find("Player").GetComponent<Movement>();
    }

    void Update()
    {
        
        if (connectedNode != null)
        {
            transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, connectedNode.position.x, Time.deltaTime * 11)
                , connectedNode.position.y
                , connectedNode.position.z + 1f);

        }
        else
        {
            nodeScript.node.Remove(gameObject);
            Destroy(gameObject);
        }
    }
    public void ObjectDestroy()
    {
        Destroy(gameObject);
    }
}
