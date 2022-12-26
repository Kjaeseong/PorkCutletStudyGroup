using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    private enum StateIndex
    {
        PREV, CURR
    }

    [field: SerializeField] public Image HpGauge { get; set; }
    [field: SerializeField] public Image ApGauge { get; set; }
    [SerializeField] private TextMeshProUGUI _damage;

    [SerializeField] private float _textTime;
    private RectTransform _damageTransform;
    private Player _player;

    private float[] _hp = new float[2];
    private float[] _ap = new float[2];
    private StateIndex _stateIndex;

    private Coroutine _coroutine;

    
    private void UiInit()
    {

    }

    public void UpdateData()
    {
        _hp[(int)StateIndex.PREV] = _hp[(int)StateIndex.CURR];
        _ap[(int)StateIndex.PREV] = _ap[(int)StateIndex.CURR];

        _hp[(int)StateIndex.CURR] = _player.Hp;
        _ap[(int)StateIndex.CURR] = _player.Ap;

        if(_hp[(int)StateIndex.CURR] != _hp[(int)StateIndex.PREV])
        {
            RefreshUI(HpGauge, _hp[(int)StateIndex.PREV], _hp[(int)StateIndex.CURR]);
        }
        if(_ap[(int)StateIndex.CURR] != _ap[(int)StateIndex.PREV])
        {
            RefreshUI(ApGauge, _ap[(int)StateIndex.PREV], _ap[(int)StateIndex.CURR]);
        }
    }

    private void RefreshUI(Image Target, float Prev, float Curr)
    {
        StopAllCoroutines();
        _coroutine = StartCoroutine(GaugeCoroutine(Target, Prev, Curr));
    }

    public void RefreshUI(TextMeshProUGUI Target, float Value)
    {
        StopAllCoroutines();
        _coroutine = StartCoroutine(TextCoroutine(Target, Value));
    }

    private IEnumerator GaugeCoroutine(Image Target, float Prev, float Curr)
    {
        float GaugeValue = Target.fillAmount;

       while(true)
       {
            if()
            yield return GameManager.Instance.Cycle;
       }
    }

    private IEnumerator TextCoroutine(TextMeshProUGUI Target, float Value)
    {
        float Time = 0f;
        _damage.gameObject.SetActive(true);
        _damage.text = "- " + Value.ToString();
        _damageTransform.position = new Vector3(0f, 0f, 0f);

        while(true)
        {
            if(Time >= _textTime)
            {
                StopAllCoroutines();
                _damage.gameObject.SetActive(false);
                yield break;
            }

            // 위치 조정
            // 페이드아웃
            yield return GameManager.Instance.Cycle;
            Time += GameManager.Instance.UpdateCycle;
        }
    }
}
