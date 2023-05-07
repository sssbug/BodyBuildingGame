using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectController : MonoBehaviour
{
    public GameObject target;
    private Movement player;
    public List<GameObject> gateList = new List<GameObject>();


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Movement>();

    }

    private void Update()
    {
        if (target != null)
        {
            target.transform.position = Vector3.Lerp(target.transform.position, transform.position + Vector3.forward, 0.1f);
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 6)
        {
            Collect(other);
        }
        else if (other.gameObject.layer == 8)
        {

            player.isStop = false;
            player.colliderr = other;
            player.startWait = true;
            Destroy(other.gameObject);


        }

    }

    private void Collect(Collider other)
    {
        target = other.gameObject;
        other.gameObject.AddComponent<CollectController>();
        other.gameObject.AddComponent<Rigidbody>();
        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        other.gameObject.GetComponent<Rigidbody>().useGravity = false;
        other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        other.gameObject.AddComponent<Node>();
        other.gameObject.GetComponent<Node>().connectedNode = transform;
        other.gameObject.layer = 7;
        other.gameObject.AddComponent<RotateMovement>();

        player.node.Add(other.gameObject);
        player.isScale = true;
        Destroy(GetComponent<CollectController>());
        Destroy(GetComponent<CollectController>());
    }


}