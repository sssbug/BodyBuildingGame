using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightAnim : MonoBehaviour
{
    private Animator player = null;
    public string playerName = null;
    private int i = 0;
    private CameraEffect cameraEffect;

    public bool isStart = false;
    void Start()
    {
        player = GameObject.Find("bodyManAnim").GetComponent<Animator>();
        cameraEffect = GameObject.Find("CameraImage").GetComponent<CameraEffect>();

    }


    void Update()
    {
        InputControl();
    }

    private void InputControl()
    {
        if (isStart)
        {
            if (Input.GetMouseButtonDown(0))
            {

                int number;

                int[] muscle = new int[] { (int)cameraEffect.arm, (int)cameraEffect.leg, (int)cameraEffect.upperBody };


                if (muscle[i] > muscle[i + 1])
                {
                    if (muscle[i] > muscle[i + 2])
                    {
                        number = i;
                        cameraEffect.arm -= 3;
                    }
                    else
                    {
                        number = i + 2;
                        cameraEffect.upperBody -= 3;
                    }
                }
                else
                {
                    if (muscle[i + 1] > muscle[i + 2])
                    {
                        number = i + 1;
                        cameraEffect.leg -= 3;
                    }
                    else
                    {
                        number = i + 2;
                        cameraEffect.upperBody -= 3;
                    }
                }




                switch (number + 1)
                {
                    case 1:
                        Punch();
                        break;
                    case 2:
                        Kick();
                        break;
                    case 3:
                        Head();
                        break;
                    default:
                        break;
                }
                isStart = false;
            }
            else
            {
                player.ResetTrigger(playerName);
            }
            
        }
    }

    private void Punch()
    {

        int random = Random.Range(1, 4);
        switch (random)
        {
            case 1:
                playerName = "bodyJabCross";

                break;
            case 2:
                playerName = "boxing";
                break;
            case 3:
                playerName = "jabCross";
                break;
            default:
                break;
        }

        player.SetTrigger(playerName);


    }
    private void Kick()
    {
        int random = Random.Range(1, 4);
        switch (random)
        {
            case 1:
                playerName = "boxingKnee";
                break;
            case 2:
                playerName = "mma(2)Kick";
                break;
            case 3:
                playerName = "mmaKick";
                break;
            case 4:
                playerName = "mma(1)Kick";
                break;
            default:
                break;
        }


        player.SetTrigger(playerName);
    }
    private void Head()
    {
        int random = Random.Range(1, 2);

        playerName = "headButt";



        player.SetTrigger(playerName);
    }

}
