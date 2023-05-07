using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystm : MonoBehaviour
{
    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (GameManager.instance._levels[i]==null)
            {
                GameManager.instance._levels[i] = transform.GetChild(i).gameObject;

            }
        }
    }
}
