using UnityEngine;

[CreateAssetMenu(menuName = "UnitStat/PlayerStat")]
public class PlayerStatAssets : UnitStat
{
    public override void Initialize()
    {
        currentHp = maxHp;
        currentSp = 0;
        currentEp = 0;
    }

    public override bool Hit(Ability _ability)
    {
        if (CanHit(_ability.aUnit.acc))
        {
            currentHp = Mathf.Clamp(currentHp - DamageCalc(_ability.aUnit.damage, _ability.aCoef), 0, maxHp);
            return true;
        }

        return false;
    }

    public override void SetPoint(Ability _ability)
    {
        if (_ability.aSpecial)
        {
            currentEp = Mathf.Clamp(currentEp + _ability.aGainPoint, 0, maxEp);
            currentSp = Mathf.Clamp(currentSp - _ability.aReqPoint, 0, currentSp - _ability.aReqPoint);
        }
        else
        {
            currentSp = Mathf.Clamp(currentSp + _ability.aGainPoint, 0, maxSp);
        }
    }

    protected override bool CanHit(int _acc)
    {
        float dodge = this.dod - _acc;

        dodge = dodge >= 0 ? dodge : 0;

        return dodge < Random.Range(0, 100);        
    }

    protected override float DamageCalc(int _damage, float _coef)
    {
        float damage = _damage * _coef;

        return damage;
    }
}
