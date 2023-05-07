using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    [SerializeField] private float maxSwerveAmount;
    [SerializeField] private float speed;

    [HideInInspector] public bool isStop = true;
    [HideInInspector] public bool isScale = false;


    public List<GameObject> node = new List<GameObject>();
    public Animator effect;
    public bool firstStart = false;
    public bool startWait = false;
    public Collider colliderr;
    public Animator Hand;

    private float forwardSpeed;
    private Rigidbody playerRb;
    private float swerveAmount;
    private float swerveAmountY;
    private float lastFrameMousePosX;
    private Vector2 firstPressPos;
    private Vector2 currentSwipe;
    


    private void Start()
    {
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody>();
        node.Add(gameObject.transform.GetChild(0).GetChild(3).gameObject);
    }
    private void Update()
    {
        if (node.Count <= 1)
        {
            isStop = true;
            Hand.SetBool("isHand", false);
        }
        else
        {
            Hand.SetBool("isHand", true);
        }
        if (firstStart)
        {
            if (isStop)
            {
                Move();
            }
            else if (!isStop)
            {
                Move();
                Stoping();
            }
        }
        if (startWait)
        {
            Wait(colliderr);
        }
        if (isScale)
        {

            StartCoroutine(scaleChanger());


            isScale = false;
        }


    }

    public void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameMousePosX = Input.mousePosition.x;


        }
        else if (Input.GetMouseButton(0))
        {
            float _inputDifference = Input.mousePosition.x - lastFrameMousePosX;


            swerveAmount = Mathf.Clamp((_inputDifference * Time.fixedDeltaTime * sensitivity), -maxSwerveAmount, maxSwerveAmount);


            lastFrameMousePosX = Input.mousePosition.x;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            swerveAmount = 0;


        }


        /*
        if (Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);
            switch (_touch.phase)
            {
                case TouchPhase.Moved:
                    swerveAmount = Mathf.Clamp(_touch.deltaPosition.x, -maxSwerveAmount, maxSwerveAmount);
                    break;
                case TouchPhase.Canceled:
                case TouchPhase.Ended:
                    swerveAmount = 0;
                    break;
            }
        }
        */
        PlayerMovement();
    }

    public void PlayerMovement()
    {

        Vector3 _horizontalVelocity = transform.right * swerveAmount * sensitivity;
        Vector3 _horizontalVelocityY = transform.forward * swerveAmountY * sensitivity;
        Vector3 _forwardVelocity = transform.forward * forwardSpeed * Time.deltaTime;

        if (isStop)
        {
            Vector3 _finalVelocity;
            forwardSpeed = (speed * Time.deltaTime);
            _finalVelocity = _forwardVelocity + _horizontalVelocity;
            playerRb.MovePosition(playerRb.position + _finalVelocity);
        }
        else
        {
            Vector3 _finalVelocity;
            forwardSpeed = 0;

            _finalVelocity = _forwardVelocity + _horizontalVelocity + _horizontalVelocityY;
            playerRb.MovePosition(playerRb.position + _finalVelocity);
        }

        float clamp = Mathf.Clamp(transform.position.x, -5.92f, 5.92f);
        transform.position = new Vector3(clamp, transform.position.y, transform.position.z);
    }

    public void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButton(0))
        {
            //create vector from the two points
            currentSwipe = new Vector2(Input.mousePosition.x - firstPressPos.x, Input.mousePosition.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();

            //swipe upwards
            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                //transform.position += transform.forward;
            }
            //swipe down
            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                //Debug.Log("down swipe");
            }
            //swipe left
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                transform.position += -transform.right;
            }
            //swipe right
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                transform.position += transform.right;
            }
        }


        float clamp = Mathf.Clamp(transform.position.x, -5.92f, 5.92f);
        transform.position = new Vector3(clamp, transform.position.y, transform.position.z);
    }

    private void Stoping()
    {
        if (Input.GetMouseButton(0))
        {
            forwardSpeed = (speed * Time.deltaTime) - (10 * Time.deltaTime);
        }
        if (Input.GetMouseButtonUp(0))
        {
            forwardSpeed = 0;
        }
    }

    IEnumerator scaleChanger()
    {
        for (int i = node.Count - 1; i >= 0;)
        {
            yield return new WaitForSeconds(0.1f);
            node[i].transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 0.2f).SetLoops(2, LoopType.Yoyo);
            i--;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 13)
        {
            gameObject.GetComponent<Movement>().enabled = false;

            effect.SetBool("isOpen", true);

        }
        
        
    }
    public void Wait(Collider other)
    {
        StartCoroutine(Stop(other));
    }

    IEnumerator Stop(Collider other)
    {
        firstStart = false;
        yield return new WaitForSeconds(0.1f);
        firstStart = true;
        startWait = false;

    }
}