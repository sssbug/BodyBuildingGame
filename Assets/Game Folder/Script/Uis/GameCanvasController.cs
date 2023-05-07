using System.Collections;
using System.Collections.Generic;
using ElephantSDK;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCanvasController : MonoBehaviour
{
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject LosePanel;

    [SerializeField] ParticleSystem _particle;
    private BossAnim _bossAnim;
    private BodyManAnim _bodyManAnim;


    //    PlayerController _playerController;
    bool _first = true;

   // ToiletsController _toiletsController; 


    private void Awake()
    {
       // _toiletsController = FindObjectOfType<ToiletsController>();


    }

    private void Start()
    {
        Time.timeScale = 1f;
        LosePanel.SetActive(false);
        WinPanel.SetActive(false);
        _bodyManAnim = GameObject.Find("bodyManAnim").GetComponent<BodyManAnim>();
        _bossAnim = GameObject.Find("Boss").GetComponent<BossAnim>();
        Elephant.LevelStarted(GameManager.instance._levelCount);
    }


    private void Update()
    {
        if (WinPanel.activeSelf || LosePanel.activeSelf) return;
        if (_first && _bodyManAnim.isWin)
        {
            StartCoroutine(WinEnumerator());
            _first = false;
            Elephant.LevelCompleted(GameManager.instance._levelCount);


        }

        if (_first && _bossAnim.isLose)
        {
            LosePanelActive();
            _first = false;
            Elephant.LevelFailed(GameManager.instance._levelCount);


        }

    }


    public void WinPanelActive()
    {

        WinPanel.SetActive(true);
    }


    public void LosePanelActive()
    {
        StartCoroutine(LoseEnumerator());
        //LosePanel.SetActive(true);
        //Time.timeScale = 0f;

    }


    public void NextLevelBtnClick()
    {
        //Time.timeScale = 1f;
        //SceneManager.LoadScene(0);
        GameManager.instance.LevelChanged();
    }

    public void RestartLevelBtnClick()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        //PlayerPrefs.SetInt("level", GameManager.instance._levelIndex);
        GameManager.instance.GameStart();
        
        
    }

    IEnumerator WinEnumerator()
    {
   
        yield return new WaitForSeconds(2f);
        WinPanelActive();
    }

    IEnumerator LoseEnumerator()
    {
        //_particle.Play();
        yield return new WaitForSeconds(2f);
        LosePanel.SetActive(true);
    }

}
