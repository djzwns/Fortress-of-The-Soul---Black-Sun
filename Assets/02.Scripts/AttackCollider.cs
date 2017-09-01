using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 투사체, 검 등 공격 판정이 필요한 오브젝트에 추가할 스크립트.
/// </summary>
public class AttackCollider : MonoBehaviour
{
    public Ability ability;

    void OnTriggerEnter2D(Collider2D coll)
    {
        // 같은 태그를 가진 유닛은 공격 안함.
        if (coll.CompareTag(gameObject.tag)) return;

        // 플레이어나 적의 콜라이더와 충돌.
        if (coll.CompareTag("Player") || coll.CompareTag("Enemy"))
        {
            // "반드시" 수정해야 할 부분
            Status unit = coll.GetComponent<Status>();
            if (unit.stat.Hit(ability))
            {
                ability.aUnit.SetPoint(ability);
                unit.Hit();
            }
        }
    }
}
