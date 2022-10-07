using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public int RefeatCount { private get; set; }
    public float CycleTime { private get; set; }
    public int AttackDamage { private get; set; }
    public bool OnRenderer { private get; set; }
    private bool _moveFront;


    private Enemy _enemy;
    private MeshRenderer _renderer;
    private SkillSet _skill;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Enemy")
        {
            _enemy = other.GetComponent<Enemy>();
            _moveFront = false;
            StartCoroutine(Attack());
        }
    }

    private void Start()
    {
        _skill = GetComponentInParent<SkillSet>();
    }

    private void OnEnable() 
    {
        SkillInit();
    }

    private void OnDisable() 
    {
        _enemy = null;
    }

    private void Update() 
    {
        if(_moveFront)
        {
            transform.Translate(0f, 0f, 0.2f);
        }
    }

    private IEnumerator Attack()
    {
        while(true)
        {
            _enemy.TakeDamage(AttackDamage);
            RefeatCount--;
            if(RefeatCount <= 0)
            {
                gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(CycleTime);
        }
    }

    private void SkillInit()
    {
        RefeatCount = _skill.RefeatCount;
        CycleTime = _skill.CycleTime;
        AttackDamage = _skill.AttackDamage;
        OnRenderer = _skill.OnRenderer;
        _moveFront = true;
        _renderer.enabled = OnRenderer;
    }
}
