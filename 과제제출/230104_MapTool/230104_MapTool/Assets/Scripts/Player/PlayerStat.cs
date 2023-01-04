using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    private enum MatState
    {
        IDLE, STEALTH
    }

    [SerializeField] private float _speed;
    [SerializeField] private float _speedValue;
    [SerializeField] private BlockManager _blockManager;
    private BlockStat _block;

    public float MoveSpeed 
    { 
        get => _speed * _speedValue;

        set
        {
            if(value > 1)
            {
                value = 1f;
            }
            else if(value < 0)
            {
                value = 0f;
            }

            _speedValue = value;
        }
    }

    public bool IsStealth
    {
        set
        {
            if(value == true)
            {
                _meshRenderer.material = _materials[(int)MatState.STEALTH];
            }
            else
            {
                _meshRenderer.material = _materials[(int)MatState.IDLE];
            }
        }
    }

    [SerializeField] private Material[] _materials = new Material[2];
    private MeshRenderer _meshRenderer;
    [SerializeField] private Vector3 _startPosition = new Vector3(9.5f, 0.6f, 9.5f);

    private void OnEnable() 
    {
        Init();
    }

    private void Update() 
    {
        CheckBlock(new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.z)));
    }

    private void Init()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        transform.position = _startPosition;
        ResetStat();
    }

    private void ResetStat()
    {
        MoveSpeed = 1f;
        IsStealth = false;
    }

    private void CheckBlock(Vector2 Position)
    {
        if(_blockManager.PlacementBlockArr[(int)Position.x, (int)Position.y] == null)
        {
            ResetStat();
        }
        else
        {
            _block = _blockManager.PlacementBlockArr[(int)Position.x, (int)Position.y].GetComponent<BlockStat>();
            IsStealth = _block.PlayerStealth;
            MoveSpeed = _block.SpeedValue;
        }
    }
}
