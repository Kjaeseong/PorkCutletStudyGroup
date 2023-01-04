using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStat : MonoBehaviour
{
    [SerializeField][Range(0,1)] private float _speedValue;
    [SerializeField] private bool _playerStealth;
    [SerializeField] private bool _dontMove;

    public float SpeedValue { get => _speedValue; }
    public bool PlayerStealth { get => _playerStealth; }
    public bool DontMove { get => _dontMove; }
}