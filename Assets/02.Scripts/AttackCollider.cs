using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public Ability ability;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag(gameObject.tag)) return;
        if (coll.CompareTag("Player") || coll.CompareTag("Enemy"))
        {
            // "반드시" 수정해야 할 부분
            PlayerStat unit = coll.GetComponent<PlayerStat>();
            Debug.Log(string.Format("공격 받은 오브젝트 : {0}", coll.name));
            if (unit.stat.Hit(ability))
            {
                ability.aUnit.SetPoint(ability);
                unit.Hit();
            }
        }
    }
}
