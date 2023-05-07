using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyModelAnim : MonoBehaviour
{
    private Animator bodyPlayerAnim;

    private void Start()
    {
        
        bodyPlayerAnim = this.GetComponent<Animator>();
    }
    public void Stop()
    {
        bodyPlayerAnim.SetBool("isLook", false);
    }
}
