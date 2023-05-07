using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnim : MonoBehaviour
{
    private BodyManAnim _bodyManAnim = null;
    private string _bossName = null;
    private Animator _boss = null;
    private Animator _bodyAnim = null;
    private FightAnim _fightAnim;
    private FighterBarPlayer fighterBarPlayer;
    public GameObject effect;
    private GameObject effectDel;
    public List<GameObject> effectPosition = new List<GameObject>();
    public bool isLose = false;
    private void Start()
    {
        _fightAnim = GameObject.Find("FightController").GetComponent<FightAnim>();
        _boss = this.GetComponent<Animator>();
        _bodyManAnim = GameObject.Find("bodyManAnim").GetComponent<BodyManAnim>();
        fighterBarPlayer = GameObject.Find("FighterBarPlayer").GetComponent<FighterBarPlayer>();
        _bodyAnim = GameObject.Find("bodyManAnim").GetComponent<Animator>();
    }
    public void Stop()
    {
        
        _boss.SetBool(_bodyManAnim.bossName,false);
        
        _bodyManAnim.isAttack = false;
        _fightAnim.isStart = true;
        fighterBarPlayer.Damege(25);
    }
    
    public void boxing()
    {
        
        if (_bodyManAnim.bossName == "boxing")
        {
            effectDel = Instantiate(effect, effectPosition[5].transform.position, Quaternion.identity);
        }
    }
    public void punching()
    {
        float damage;
        if (_bodyManAnim.bossName == "punching")
        {
            effectDel = Instantiate(effect, effectPosition[2].transform.position, Quaternion.identity);
        }
    }
    public void kickk()
    {
        float damage;
        if (_bodyManAnim.bossName== "kickk")
        {
            effectDel = Instantiate(effect, effectPosition[1].transform.position, Quaternion.identity);
        }
    }
    public void kicking()
    {
        float damage;
        if (_bodyManAnim.bossName == "kicking")
        {
            effectDel = Instantiate(effect, effectPosition[3].transform.position, Quaternion.identity);
        }
    }
    public void headbutt()
    {
        if (_bodyManAnim.bossName == "headbutt")
        {
            effectDel = Instantiate(effect, effectPosition[4].transform.position, Quaternion.identity);
        }
    }
    

    public void EffectDel()
    {
        Destroy(effectDel);
    }

    public void Lose()
    {
        isLose = true;
    }

    public void Finish()
    {
        _bodyAnim.SetTrigger("knockedOut");
    }
    
}
