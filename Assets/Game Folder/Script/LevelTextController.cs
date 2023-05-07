using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTextController : MonoBehaviour
{

    TextMeshProUGUI _levelText;
    private void Awake()
    {
       
    }

    private void Start()
    {
        _levelText = GetComponent<TextMeshProUGUI>();
        _levelText.text = "Level " + (GameManager.instance._levelCount+1).ToString();

    }
}
