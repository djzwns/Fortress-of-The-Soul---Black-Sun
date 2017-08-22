using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackTriggerable : MonoBehaviour
{
    [HideInInspector]
    public float coef = 1;

    [HideInInspector]
    public float hitForce = 100f;

    public BoxCollider2D weaponCollider;

    private WaitForSeconds swingDuration = new WaitForSeconds(.3f);

    public void Swing()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        weaponCollider.enabled = true;

        yield return swingDuration;

        weaponCollider.enabled = false;
    }
}
