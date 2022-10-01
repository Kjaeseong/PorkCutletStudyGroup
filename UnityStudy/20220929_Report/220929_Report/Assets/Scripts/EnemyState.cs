using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class EnemyState : MonoBehaviour
{
    public TextMeshProUGUI _hpText;
    public TextMeshProUGUI _nameText;

    private Debuff _debuff;

    public int EnemyMaxHP = 10;
    public int BossMaxHP = 100;

    private int _maxHp;
    public int Hp;
    
    public bool IsCurse;

    private string[] _name = { "Enemy", "Boss" };

    private int RandNum;

    private void Awake()
    {
        _debuff = GetComponent<Debuff>();
    }

    private void OnEnable() 
    {
        EnemyInit();
    }

    private void FixedUpdate() 
    {
        Death();
    }

    public void ChangeText()
    {
        _hpText.text = Hp.ToString();
        _nameText.text = _name[RandNum];
    }

    private void EnemyInit()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        RandNum = Random.Range(0, 2);

        if(_name[RandNum] == "Enemy")
        {
            _maxHp = EnemyMaxHP;
        }
        else
        {
            _maxHp = BossMaxHP;
        }
        Hp = _maxHp;

        ChangeText();
    }

    private void Death()
    {
        if(IsCurse == true)
        {
            if(Hp < _maxHp / 10)
            {
                transform.localScale -= new Vector3(0.05f, 0.05f, 0f);
            }

            if(transform.localScale.x <= 0)
            {
                gameObject.SetActive(false);
            }
            
        }
        else
        {
            if(Hp <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void Damage(int Debuff)
    {
        switch(Debuff)
        {
            case 1:
                _debuff.AddScald();
                break;
            case 2:
                _debuff.AddPoison();
                break;
            case 3:
                _debuff.AddCurse();
                break;
            case 0:
                _debuff.NormalAttack();
                break;
        }
    }

    






}
