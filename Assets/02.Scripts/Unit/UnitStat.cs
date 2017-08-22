using UnityEngine;

public abstract class UnitStat : ScriptableObject
{
    public int level = 1;
    public string unitname = "dummy";
    public Sprite portrait;

    public int maxHp;  // max health point
    [Range(0, 100)]
    public int maxSp;  // max skill point
    [Range(0, 100)]
    public int maxEp;  // max epic point, used to special action

    [HideInInspector]
    public float currentHp;
    [HideInInspector]
    public float currentSp;
    [HideInInspector]
    public float currentEp;

    public int damage;

    public int defense; // defense
    public int resist;  // resist

    public int acc; // accuracy rate
    [Range(0, 75)]
    public int dod; // dodge rate

    public abstract void Initialize();
    public abstract bool Hit(Ability _ability);
    public abstract void SetPoint(Ability _ability);
    protected abstract bool CanHit(int _acc);
    protected abstract float DamageCalc(int _damage, float _coef/*, AttackType _type*/);
}
