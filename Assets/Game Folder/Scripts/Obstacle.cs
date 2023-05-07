using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Movement player;
    private NewMan effect;

    private void Start()
    {
        effect = GameObject.Find("GateController").GetComponent<NewMan>();
        player = GameObject.Find("Player").GetComponent<Movement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            GameObject effectt = Instantiate(effect.BarbellEffect, other.gameObject.transform.position, Quaternion.identity);
            Destroy(effectt, 3);
            Collect(other);
        }
    }
    private void Collect(Collider other)
    {

        other.gameObject.AddComponent<CollectController>();
        CollectController collectController = other.GetComponent<CollectController>();
        collectController.gateList.Add(gameObject);
        other.gameObject.GetComponent<Node>().ObjectDestroy();

        if (player.node.Count - 2 != -1)
        {
            if (player.node[player.node.Count - 2].GetComponent<CollectController>() == null)
            {

                player.node[player.node.Count - 2].AddComponent<CollectController>();

            }
        }

        player.node.Remove(other.gameObject);

        if (player.node.Count == 1 && player.node[0].GetComponent<CollectController>() == null)
        {
            player.node[0].AddComponent<CollectController>();
        }
    }
}