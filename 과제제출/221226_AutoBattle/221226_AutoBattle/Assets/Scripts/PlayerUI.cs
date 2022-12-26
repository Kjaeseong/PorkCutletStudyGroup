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

    public void RefreshGauge(Image Target, float Value)
    {
        Target.fillAmount = Value;
    }

    public void DamageTextSet(float Value)
    {
        StopAllCoroutines();
        _coroutine = StartCoroutine(TextCoroutine(Value));
    }

    private IEnumerator TextCoroutine(float Value)
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
