using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 유닛의 상태를 처리하는 스크립트.
/// 피격
/// </summary>
public abstract class Status : MonoBehaviour
{
    public UnitStat stat;
    public float flashTime = 0.2f;

    /// <summary>
    /// 피격 효과 함수.
    /// </summary>
    public void Hit()
    {
        StartCoroutine(Flash());
    }

    public bool CanDoSkill(float _reqSp)
    {
        return _reqSp <= stat.currentSp;
    }

    protected abstract IEnumerator Flash();
}
