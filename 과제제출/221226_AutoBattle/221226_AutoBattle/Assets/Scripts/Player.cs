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
    private Player _enemy;
    private float _actionGauge;

    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerUI _ui;
    private Coroutine _apCoroutine;
    private Coroutine _hpCoroutine;
    private Coroutine _moveCoroutine;

    private Vector3 _startPosition;

    private void Start() 
    {
        PlayerInit();
        GameManager.Instance.PlayerApUp();
    }

    public void ApGaugeUp()
    {
        StopAllCoroutines();
        _apCoroutine = StartCoroutine(ApGaugeCoroutine());
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

        _startPosition = transform.position;

        Hp = _maxHp;
        Ap = 0f;

        _ui.RefreshGauge(_ui.HpGauge, Hp);
        _ui.RefreshGauge(_ui.ApGauge, Ap);
    }

    private IEnumerator ApGaugeCoroutine()
    {
        while(true)
        {
            yield return GameManager.Instance.Cycle;
            _actionGauge += GameManager.Instance.UpdateCycle * _speed * Time.deltaTime;
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
            Hp -= 1f;
            _ui.RefreshGauge(_ui.HpGauge, Hp / 100);
            
            if(Hp <= 0)
            {
                GameManager.Instance.PlayerDie(_playerIndex);
                yield break;
            }

            if(result >= Hp)
            {
                GameManager.Instance.PlayerApUp();
                yield break;
            }
        }
    }

    private void Attack()
    {
        StopAllCoroutines();
        _enemy.TakeDamage(AtkValue);
    }

    public void TakeDamage(float Damage)
    {
        StopAllCoroutines();
        _hpCoroutine = StartCoroutine(HpGaugeCoroutine(Damage));
        _ui.DamageTextSet(Damage);
    }

    private float GetDistTo(Vector3 Position)
    {
        float Distance = Vector3.Distance(Position, transform.position);
        return Distance;
    }


    


}
