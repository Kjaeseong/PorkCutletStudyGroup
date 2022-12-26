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



    private PlayerMovement _movement;
    private PlayerUI _ui;
    private Coroutine _apCoroutine;
    private Coroutine _atkCoroutine;



    private void Start() 
    {
        _movement = GetComponentInChildren<PlayerMovement>();
        _ui = GetComponentInChildren<PlayerUI>();

        PlayerInit();
    }


    private void PlayerInit()
    {
        GameManager.Instance.Player.Add(this);
        _playerIndex = GameManager.Instance.Player.Count - 1;

        MeshRenderer _playerMesh = _playerModel.GetComponent<MeshRenderer>();
        _playerMesh.material = _material;

        RefreshApGauge(true);
    }

    /// <summary>
    /// 행동 게이지 갱신을 위한 함수
    /// </summary>
    /// <param name="Switch">true = 실행 / false = 정지</param>
    public void RefreshApGauge(bool Switch)
    {
        if(Switch)
        {
            _apCoroutine = StartCoroutine(ApGaugeCoroutine());
        }
        else
        {
            StopCoroutine(_apCoroutine);
        }
    }

    private IEnumerator ApGaugeCoroutine()
    {
        while(true)
        {
            yield return GameManager.Instance.Cycle;

            _actionGauge += GameManager.Instance.UpdateCycle * _speed;
            // 게이지 UI 갱신 함수

            if(_actionGauge >= 1)
            {
                _actionGauge = 0f;
                // 공격판정
            }

        }
    }

    private void Attack()
    {
        
    }

    /// <summary>
    /// 상대 플레이어에게 데미지 입힘
    /// </summary>
    public void TakeDamage(float Damage)
    {
        _hp -= Damage;
        _ui.Refresh(_ui.HpGauge, -Damage);
    }

    public void UpdateData()
    {
        _movement.UpdateData();
        _ui.UpdateData();
    }


    


}
