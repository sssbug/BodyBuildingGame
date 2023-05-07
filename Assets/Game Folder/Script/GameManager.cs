using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject[] _levels;
     public int _levelIndex;

    public static GameManager instance;

    public int _levelCount;

    [SerializeField] Material[] _skyBoxMats;

    [SerializeField] int _skyIndex;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //PlayerPrefs.DeleteAll();
        _levelCount = PlayerPrefs.GetInt("levelCount");
        _levelIndex = PlayerPrefs.GetInt("level");
        _skyIndex = PlayerPrefs.GetInt("skyBoxIndex");
    }

    void Start()
    {
        GameStart();
        RenderSettings.skybox = _skyBoxMats[_skyIndex];
    }



    public void LevelChanged()
    {

        _levels[_levelIndex].SetActive(false);

        _levelIndex++;
        _levelCount++;


        SkyBoxChanged();

        if (_levelIndex >= _levels.Length)
        {
            SceneManager.LoadScene(0);
            _levelIndex = 0;
            _levels[_levelIndex].SetActive(true);


        }
        else
        {
            _levels[_levelIndex].SetActive(true);
        }

    }



    public void GameStart()
    {

        foreach (GameObject level in _levels)
        {
            level.SetActive(false);
        }
        _levels[_levelIndex].SetActive(true);
        RenderSettings.skybox = _skyBoxMats[_skyIndex];

    }

    void OnDisable()
    {
        DataLevel();
    }

    public void DataLevel()
    {

        PlayerPrefs.SetInt("level", _levelIndex);
        PlayerPrefs.SetInt("levelCount", _levelCount);
        PlayerPrefs.SetInt("skyBoxIndex", _skyIndex);
    }

    private void OnEnable()
    {
        _levelIndex = PlayerPrefs.GetInt("level");

    }

    void SkyBoxChanged()
    {
        if (_skyBoxMats.Length-1<=_skyIndex)
        {
            _skyIndex = 0;
        }
        else
        {
            _skyIndex++;
        }
        RenderSettings.skybox = _skyBoxMats[_skyIndex];
    }
}
