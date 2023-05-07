using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeToController : MonoBehaviour
{
    //PlayerController _playerController;
    private Movement movement;
    void Start()
    {
        // _playerController = FindObjectOfType<PlayerController>();
        movement = GameObject.Find("Player").GetComponent<Movement>();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // _playerController.GameStart();
            movement.firstStart = true;
            gameObject.SetActive(false);
        }
    }
}
