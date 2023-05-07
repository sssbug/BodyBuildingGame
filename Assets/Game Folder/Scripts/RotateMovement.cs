using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMovement : MonoBehaviour
{
   
    
    void Update()
    {
        transform.DORotate(new Vector3(0f, 0f, 0f),0.7f);
    }
}
