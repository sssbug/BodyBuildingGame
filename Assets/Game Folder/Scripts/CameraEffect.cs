using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraEffect : MonoBehaviour
{
    public Camera mainCamera; 
    public Camera finishEffect;
    private FightAnim _fightAnim;
    public List<Image> healtBar = new List<Image>();
    private SkinnedMeshRenderer newManMeshRenderer;
    private Animator main;
    private BodyManAnim _bodyManAnim = null;
    public float leg;
    public float arm;
    public float upperBody;
    private void Start()
    {
        newManMeshRenderer = GameObject.Find("newMan").GetComponent<SkinnedMeshRenderer>();
        _bodyManAnim = GameObject.Find("bodyManAnim").GetComponent<BodyManAnim>();
    }
    public void CameraEffectt()
    {
        main = GetComponent<Animator>();
        main.SetBool("isOpen", false);
        mainCamera.enabled = false;
        finishEffect.enabled = true;
        main.SetBool("isClose", true);
    }
    public void Close()
    {
        _fightAnim = GameObject.Find("FightController").GetComponent<FightAnim>();
        main.SetBool("isClose", false);
        _bodyManAnim.AttackDuplicate();
        foreach (Image item in healtBar)
        {
            item.GetComponent<Image>().enabled = true;
        }
        _fightAnim.isStart = true;
        StartCoroutine(Waiting());
    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(.7f * Time.deltaTime);
        leg = newManMeshRenderer.GetBlendShapeWeight(2);
        arm = newManMeshRenderer.GetBlendShapeWeight(0);
        upperBody = newManMeshRenderer.GetBlendShapeWeight(1);
        
    }
}