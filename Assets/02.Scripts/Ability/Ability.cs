using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public string aName = "New Ability";
    public UnitStat aUnit;
    public float aCoef;
    public float aCoolDown = 1f;
    public float aReqPoint = 0f;
    public float aGainPoint = 0f;
    public AudioClip aSound;
    public Sprite aSprite;
    public bool aSpecial = false;

    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility();
    public abstract void RenewalAbility();
}
