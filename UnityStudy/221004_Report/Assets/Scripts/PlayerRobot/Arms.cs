using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arms : MonoBehaviour
{
    private Body _body;
    private Head _head;
    private SkillSet _skill;
    public GameObject AttackColliderPrefab;
    private GameObject _attackCollider;
    private AttackCollider _collider;

    public GameObject LeftArm;
    public GameObject RightArm;

    private void Start() 
    {
        _head = GetComponentInParent<Head>();
        _body = GetComponentInParent<Body>();
        _skill = GetComponentInParent<SkillSet>();
        _attackCollider = Instantiate(AttackColliderPrefab);
        _attackCollider.SetActive(false);
        _collider = _attackCollider.GetComponent<AttackCollider>();
    }

    public void Attack(bool UseSkill, int pattern)
    {
        if(!_attackCollider.activeSelf)
        {
            _skill.SelectPattern(pattern);
            _attackCollider.SetActive(true);
        }
    }

    private void Rotate(int Step)
    {
        transform.rotation = Quaternion.Euler(Step * -90f, 0f, 0f);
    }

    

}
