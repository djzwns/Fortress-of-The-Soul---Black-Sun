using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Ability/MeleeAbility")]
public class MeleeAbility : Ability
{
    public float hitForce;

    private MeleeAttackTriggerable maTrigger;

    public override void Initialize(GameObject obj)
    {
        maTrigger = obj.GetComponent<MeleeAttackTriggerable>();

        RenewalAbility();
    }

    public override void TriggerAbility()
    {
        RenewalAbility();
        maTrigger.Swing();
    }

    public override void RenewalAbility()
    {
        maTrigger.coef = aCoef;
        maTrigger.hitForce = hitForce;
    }
}
