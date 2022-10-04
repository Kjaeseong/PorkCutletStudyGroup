using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arms : MonoBehaviour
{
    public Enemy Enemy;
    public Body Body;
    public Head Head;

    public void Attack(bool UseSkill, int damage)
    {
        if(Enemy != null)
        {
            if(Head)
            StartCoroutine(NormalAttack(damage));
        }
    }

    private void Rotate(int Step)
    {
        transform.rotation = Quaternion.Euler(Step * -90f, 0f, 0f);
    }

    public IEnumerator NormalAttack(int damage)
    {
        Body.CanAttack = false;
        Rotate(1);
        Enemy.TakeDamage(damage);

        yield return new WaitForSeconds(1f);
        Rotate(0);
        Body.CanAttack = true;
    }

}
