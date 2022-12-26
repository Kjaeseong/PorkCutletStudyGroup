using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private GameObject _playerModel;
    [SerializeField] private float _maxHp;
    [SerializeField] private float _maxAp;
    [SerializeField] public float AtkValue;
    [SerializeField][Range(0, 100)] private float _speed;
    
    public float Hp { get; private set; }
    public float Ap { get; private set; }

    private int _playerIndex;
    [SerializeField] private Player _enemy;
    private float _actionGauge;



    private PlayerMovement _movement;
    private PlayerUI _ui;
    private Coroutine _apCoroutine;
    private Coroutine _hpCoroutine;


    private void OnEnable() 
    {
        
    }

    private void Start() 
    {
        _movement = GetComponentInChildren<PlayerMovement>();
        _ui = GetComponentInChildren<PlayerUI>();
        PlayerInit();
    }

    private void PlayerInit()
    {
        for(int i = 0; i < GameManager.Instance.Player.Count; i++)
        {
            if(GameManager.Instance.Player[i] == this)
            {
                _playerIndex = i;
            }
            else
            {
                _enemy = GameManager.Instance.Player[i];
            }
        }

        MeshRenderer _playerMesh = _playerModel.GetComponent<MeshRenderer>();
        _playerMesh.material = _material;

        Hp = _maxHp;
        Ap = 0f;
    }

    private IEnumerator ApGaugeCoroutine()
    {
        while(true)
        {
            yield return GameManager.Instance.Cycle;
            _actionGauge += GameManager.Instance.UpdateCycle * _speed;
            _ui.RefreshGauge(_ui.ApGauge, _actionGauge);

            if(_actionGauge >= 1)
            {
                _actionGauge = 0f;
                Attack();
                yield break;
            }
        }
    }

    private IEnumerator HpGaugeCoroutine(float Damage)
    {
        float result = Hp - Damage;

        while(true)
        {
            yield return GameManager.Instance.Cycle;
            Hp -= 0.1f;
            _ui.RefreshGauge(_ui.HpGauge, Hp / 100);

            if(Hp <= 0)
            {
                GameManager.Instance.PlayerDie(_playerIndex);
                yield break;
            }

            if(result >= Hp)
            {
                yield break;
            }
        }
    }

    private void Attack()
    {
        _enemy.TakeDamage(AtkValue);
    }

    public void TakeDamage(float Damage)
    {
        _hpCoroutine = StartCoroutine(HpGaugeCoroutine(Damage));
        _ui.DamageTextSet(Damage);
    }




    


}
