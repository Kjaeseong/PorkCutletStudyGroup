using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff : MonoBehaviour
{
    private EnemyState _status;
    private SpriteRenderer _sprite;

    public float ScaldCycleTime = 5f;
    public int ScaldStopCount = 4;
    public int ScaldCount = 0;
    public int ScaldDamage = 5;

    public float PoisonCycleTime = 3f;
    public int PoisonStopCount = 2;
    public int PoisonDamage = 2;

    public bool Curse;

    private void Awake() 
    {
        _status = GetComponent<EnemyState>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() 
    {
        Curse = false;
    }

    public IEnumerator Scald()
    {
        int StopCount = ScaldStopCount;

        while(true)
        {
            Debug.Log("화상뎀");
            _status.Hp -= ScaldDamage;
            StopCount--;
            _status.ChangeText();

            if(StopCount <= 0)
            {
                ScaldCount--;
                break;
            }
            yield return new WaitForSeconds(ScaldCycleTime);
        }
    }

    public IEnumerator Poison()
    {
        int StopCount = PoisonStopCount;

        while(true)
        {
            Debug.Log(" 독뎀");
            _status.Hp -= PoisonDamage;
            StopCount--;
            _status.ChangeText();

            if(StopCount <= 0)
            {
                break;
            }
            yield return new WaitForSeconds(ScaldCycleTime);
        }
    }

    public void AddCurse()
    {
        _status.IsCurse = true;
    }

    public void AddScald()
    {
        StartCoroutine(Scald());
        ScaldCount++;
    }

    public void AddPoison()
    {
        StartCoroutine(Poison());
    }

    public void NormalAttack()
    {
        _status.Hp -= 10;
        _status.ChangeText();
    }
}
