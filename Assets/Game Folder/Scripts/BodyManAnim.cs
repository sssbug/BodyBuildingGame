using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyManAnim : MonoBehaviour
{   
    
    public string bossName = null;
    public int reaction = 0;
    public int randommm = 0;
    public bool isAttack = false;
    private Animator _boss = null;
    private BossFighterBar bossFighterBar;
    public GameObject effect;
    private GameObject effectDel;
    public List<GameObject> effectPosition = new List<GameObject>();
    private FightAnim fightAnim;
    private SkinnedMeshRenderer bodyMeshRenderer;
    public bool isWin =  false;
    public int power;
    

    void Start()
    {
        bossFighterBar = GameObject.Find("FighterBarBoss").GetComponent<BossFighterBar>();
        _boss = GameObject.Find("Boss").GetComponent<Animator>();
        fightAnim = GameObject.Find("FightController").GetComponent<FightAnim>();
        bodyMeshRenderer = GameObject.Find("body.006").GetComponent<SkinnedMeshRenderer>();
    }

    private void Update()
    {
        if (!isAttack)
        {
            _boss.SetBool(bossName, false);
        }
        
    }

    

    public void Dafense()
    {
        bool _arrow = true;
        if (_arrow)
        {
            reaction = 1;
        }
        else
        {
            reaction = 0;
        }
    }
    public void Attack()
    {
        
        int random = Random.Range(1,4);
        if (random == 1)
        {
            reaction = 2;
            Result(reaction);
            random = 0;
        }
        else if(random == 2)
        {
            reaction = 3;
            Result(reaction);
            random = 0;
        }
        else if (random == 3)
        {
            reaction = 4;
            Result(reaction);
            random = 0;
        }
        fightAnim.isStart = true;
        isAttack = true;

    }
    public void AttackDuplicate()
    {
        //int _armVolume = 1;
        //int _legVolume = 0;
        int random = Random.Range(1, 3);
        if (random == 1)
        {
            reaction = 2;
            Result(reaction);
            random = 0;
        }
        else if (random == 2)
        {
            reaction = 3;
            Result(reaction);
            random = 0;
        }
        
        isAttack = true;
    }
    private void Result(int rreaction)
    {
        switch (rreaction)
        {
            case 1:
                bossName = "bodyBlock";
                break;
            case 2:

                randommm = Random.Range(1, 3);
                switch (randommm)
                {
                    case 1:
                        bossName = "boxing";
                        break;
                    case 2:
                        bossName = "punching";
                        break;
                    default:
                        break;
                }
                break;
            case 3:
                randommm = Random.Range(1, 3);
                switch (randommm)
                {
                    case 1:
                        bossName = "kickk";

                        break;
                    case 2:
                        bossName = "kicking";

                        break;
                    default:
                        break;
                }
                break;
            case 4:
                randommm = Random.Range(1, 2);
                switch (randommm)
                {
                    case 1:
                        bossName = "headbutt";
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
        _boss.SetBool(bossName, true);
    }
    public void Effect()
    {
        
        float damage;
        switch (fightAnim.playerName)
        { 

            case "bodyJabCross":
                effectDel =  Instantiate(effect, effectPosition[6].transform.position, Quaternion.identity);
                damage = bodyMeshRenderer.GetBlendShapeWeight(0);
                bossFighterBar.Damege(damage / power);
                
                break;
            case "boxing":
                effectDel = Instantiate(effect, effectPosition[4].transform.position, Quaternion.identity);
                damage = bodyMeshRenderer.GetBlendShapeWeight(0);
                bossFighterBar.Damege(damage / power);
                
                break;
            case "jabCross":
                effectDel = Instantiate(effect, effectPosition[6].transform.position, Quaternion.identity);
                damage = bodyMeshRenderer.GetBlendShapeWeight(0);
                bossFighterBar.Damege(damage / power);
                
                break;
            case "boxingKnee":
                effectDel = Instantiate(effect, effectPosition[3].transform.position, Quaternion.identity);
                damage = bodyMeshRenderer.GetBlendShapeWeight(2);
                bossFighterBar.Damege(damage / power);
                break;
            case "mma(2)Kick":
                effectDel = Instantiate(effect, effectPosition[0].transform.position, Quaternion.identity);
                damage = bodyMeshRenderer.GetBlendShapeWeight(2);
                bossFighterBar.Damege(damage / power);
                break;
            case "mmaKick":
                effectDel = Instantiate(effect, effectPosition[2].transform.position, Quaternion.identity);
                damage = bodyMeshRenderer.GetBlendShapeWeight(2);
                bossFighterBar.Damege(damage / power);
               
                break;
            case "mma(1)Kick":
                effectDel = Instantiate(effect, effectPosition[2].transform.position, Quaternion.identity);
                damage = bodyMeshRenderer.GetBlendShapeWeight(2);
                bossFighterBar.Damege(damage / power);
                break;
            case "headButt":
                effectDel = Instantiate(effect, effectPosition[5].transform.position, Quaternion.identity);
                damage = bodyMeshRenderer.GetBlendShapeWeight(1);
                bossFighterBar.Damege(damage / power);
                break;
            default:
                break;
        }
    }
    public void EffectDel()
    {
        Destroy(effectDel);
    }
    public void Win()
    {
        isWin = true;
    }
    public void finish()
    {
        _boss.SetBool("knockOut", true);
    }
}