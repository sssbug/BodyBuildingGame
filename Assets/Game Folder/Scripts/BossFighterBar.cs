using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossFighterBar : MonoBehaviour
{
    private Image damage;

    public float health, maxHealth = 100;
    private Animator playerAnim;
    private BodyManAnim bodyManAnim;
    private FightAnim _fightAnim;
    private Animator _boss = null;

    public void OnEnable()
    {
        damage = this.GetComponent<Image>();
        health = maxHealth;
        playerAnim = GameObject.Find("bodyManAnim").GetComponent<Animator>();
        bodyManAnim = GameObject.Find("bodyManAnim").GetComponent<BodyManAnim>();
        _fightAnim = GameObject.Find("FightController").GetComponent<FightAnim>();
        _boss = GameObject.Find("Boss").GetComponent<Animator>();
    }

    private void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        BossBar();
    }

    public void BossBar()
    {
        if (damage.fillAmount <= 0.01f)
        {
            
            playerAnim.SetTrigger("flyingKick");
            
            _fightAnim.isStart = false;
        }
        else
        {
            damage.fillAmount = Mathf.Lerp(damage.fillAmount, health / maxHealth, 3f * Time.deltaTime);
        }
    }

    public void Damege(float damagePoint)
    {
        if (health > 0)
        {
            health -= damagePoint;
        }
    }
}
