using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FighterBarPlayer : MonoBehaviour
{
    private Image damage;
    private float health, maxHealth = 100;
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
        PlayerBar();
    }

    public void PlayerBar()
    {
        if (damage.fillAmount <= 0.01f)
        {
            
            _boss.SetBool("flyingKick", true);
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
