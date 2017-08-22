using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/RangeAbility")]
public class RangeAbility : Ability
{
    public float projectileForce;
    public Rigidbody2D projectile;

    private RangeAttackTriggerable raTrigger;

    public override void Initialize(GameObject obj)
    {
        raTrigger = obj.GetComponent<RangeAttackTriggerable>();

        RenewalAbility();
    }

    public override void TriggerAbility()
    {
        RenewalAbility();
        raTrigger.Launch();
    }

    public override void RenewalAbility()
    {
        raTrigger.coef = aCoef;
        raTrigger.projectileForce = projectileForce;
        raTrigger.projectile = projectile;
    }
}
