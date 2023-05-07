using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    private List<Image> progressImage = new List<Image>();
    private float resultS;
    private float resultE;

    private float before;
    private float beforee;
    private float currentBlenderShape;
    private Movement player;
    private SkinnedMeshRenderer newManMeshRenderer;
    private SkinnedMeshRenderer bodyMeshRenderer;
    private UpperBody upperBody;
    private Arm arm;
    private Leg leg;
    private NewMan newMan;
    private Animator bodyPlayerAnim;


    

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Movement>();
        bodyPlayerAnim = GameObject.Find("bodyModel").GetComponent<Animator>();
        newManMeshRenderer = GameObject.Find("newMan").GetComponent<SkinnedMeshRenderer>();
        bodyMeshRenderer = GameObject.Find("body.006").GetComponent<SkinnedMeshRenderer>();
        newMan = GameObject.Find("GateController").GetComponent<NewMan>();
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            progressImage.Add(gameObject.transform.GetChild(i).GetComponent<Image>());
        }

        before = progressImage[0].fillAmount;
        beforee = progressImage[1].fillAmount;

    }

    private void Update()
    {
        upperBody = GameObject.Find("GateController").GetComponent<UpperBody>();
        arm = GameObject.Find("GateController").GetComponent<Arm>();
        leg = GameObject.Find("GateController").GetComponent<Leg>();



        if (gameObject.transform.parent.name == "UpperBody")
        {
            progressImage[0].fillAmount = upperBody.downValue;
            progressImage[1].fillAmount = beforee - upperBody.upValue;
        }
        else if (gameObject.transform.parent.name == "Arm")
        {
            progressImage[0].fillAmount = arm.downValue;
            progressImage[1].fillAmount = beforee - arm.upValue;

        }
        else if (gameObject.transform.parent.name == "Leg")
        {

            progressImage[0].fillAmount = leg.downValue;
            progressImage[1].fillAmount = beforee - leg.upValue;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Collect(other);

        }
    }

    private void Collect(Collider other)
    {
        
        other.gameObject.AddComponent<CollectController>();
        CollectController collectController = other.GetComponent<CollectController>();

        bodyPlayerAnim.SetBool("isLook", true);


        collectController.gateList.Add(gameObject);

        if (collectController.gateList[0].name == gameObject.name)
        {
            resultS += ((float)1 / 12);
            resultE += ((float)1 / 12);
            if (gameObject.transform.parent.name == "UpperBody")
            {

                upperBody.downValue += ((float)1 / 12);
                upperBody.upValue += ((float)1 / 12);

                currentBlenderShape = newManMeshRenderer.GetBlendShapeWeight(1);

                newManMeshRenderer.SetBlendShapeWeight(1, currentBlenderShape + (100 / 6) / newMan.muscleValue);
                bodyMeshRenderer.SetBlendShapeWeight(1, currentBlenderShape + (100 / 6) / newMan.muscleValue);
                GameObject effect = Instantiate(newMan.muscleEffect, newMan.bodyModelEffect[4].position, Quaternion.identity);

                Destroy(effect, 2);
            }
            else if (gameObject.transform.parent.name == "Arm")
            {
                arm.downValue += ((float)1 / 12);
                arm.upValue += ((float)1 / 12);

                currentBlenderShape = newManMeshRenderer.GetBlendShapeWeight(0);

                if (currentBlenderShape != 100)
                {
                    newManMeshRenderer.SetBlendShapeWeight(0, currentBlenderShape + (100 / 2) / newMan.muscleValue);
                    bodyMeshRenderer.SetBlendShapeWeight(0, currentBlenderShape + (100 / 2) / newMan.muscleValue);
                }
                else
                {
                    newMan.bodyTransorm[1].localScale += new Vector3((0.4f / 6), (0.4f / 6), (0.4f / 6));
                    newMan.bodyTransorm[5].localScale += new Vector3((0.4f / 6), (0.4f / 6), (0.4f / 6));
                    newMan.bodyTransorm[4].localScale += new Vector3((0.4f / 6), (0.4f / 6), (0.4f / 6));
                    newMan.bodyTransorm[0].localScale += new Vector3((0.4f / 6), (0.4f / 6), (0.4f / 6));
                }
                GameObject effect = Instantiate(newMan.muscleEffect, newMan.bodyModelEffect[2].position, Quaternion.identity);
                GameObject effectt = Instantiate(newMan.muscleEffect, newMan.bodyModelEffect[3].position, Quaternion.identity);
                Destroy(effectt, 2);
                Destroy(effect, 2);
            }
            else if (gameObject.transform.parent.name == "Leg")
            {
                leg.downValue += ((float)1 / 12);
                leg.upValue += ((float)1 / 12);

                currentBlenderShape = newManMeshRenderer.GetBlendShapeWeight(2);

                if (currentBlenderShape != 100)
                {
                    newManMeshRenderer.SetBlendShapeWeight(2, currentBlenderShape + (100 / 2) / newMan.muscleValue);
                    bodyMeshRenderer.SetBlendShapeWeight(2, currentBlenderShape + (100 / 2) / newMan.muscleValue);
                }
                else
                {
                    newMan.bodyTransorm[2].localScale += new Vector3((0.4f / 6), 0, (0.4f / 6));
                    newMan.bodyTransorm[3].localScale += new Vector3((0.4f / 6), 0, (0.4f / 6));
                    newMan.bodyTransorm[6].localScale += new Vector3((0.4f / 6), 0, (0.4f / 6));
                    newMan.bodyTransorm[7].localScale += new Vector3((0.4f / 6), 0, (0.4f / 6));
                }
                GameObject effect = Instantiate(newMan.muscleEffect, newMan.bodyModelEffect[0].position, Quaternion.identity);
                GameObject effectt = Instantiate(newMan.muscleEffect, newMan.bodyModelEffect[1].position, Quaternion.identity);
                Destroy(effectt, 2);
                Destroy(effect, 2);
            }

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

   
}