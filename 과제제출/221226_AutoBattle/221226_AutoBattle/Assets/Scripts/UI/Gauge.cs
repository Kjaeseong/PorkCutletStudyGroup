using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    private float _prevValue;
    private float _currValue;
    private Image _gauge;
    private Coroutine _coroutine;
    private int _direction;

    private bool _isGaugeUp;

    private void Start() 
    {
        Init();
    }

    public void GaugeStop()
    {
        StopAllCoroutines();
    }

    public void Refresh(float Value)
    {
        GaugeStop();
        _currValue = Value;

        if(_prevValue != _currValue)
        {
            if(_isGaugeUp)
            {
                _coroutine = StartCoroutine(GaugeUp());
            }
            else
            {
                _coroutine = StartCoroutine(GaugeDown());
            }
        }
    }

    private IEnumerator GaugeUp()
    {
        float Target = (_gauge.fillAmount * 100) + _currValue;
        while(true)
        {
            if(_gauge.fillAmount >= _currValue / 100)
            {
                _prevValue = _currValue;
                yield break;
            }

            _gauge.fillAmount += _direction * 0.1f;
            yield return GameManager.Instance.Cycle;
        }
    }

    private IEnumerator GaugeDown()
    {
        float Target = (_gauge.fillAmount * 100) - _currValue;
        while(true)
        {
            if(_gauge.fillAmount <= _currValue / 100)
            {
                _prevValue = _currValue;
                yield break;
            }

            _gauge.fillAmount += _direction * 0.1f;
            yield return GameManager.Instance.Cycle;
        }
    }
    
    private void Init()
    {
        _gauge = GetComponent<Image>();
    }


}
