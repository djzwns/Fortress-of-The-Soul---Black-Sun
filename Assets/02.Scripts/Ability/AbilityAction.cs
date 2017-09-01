using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityAction : MonoBehaviour
{
    [SerializeField]
    private Ability ability;
    [SerializeField]
    private GameObject weaponHolder;

    private Image buttonImage;
    private AudioSource abilitySource;
    private float reqSp;
    private float coolDownDuration;
    private float nextReadyTime;
    
    private CharacterController cc;
    private Status status;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        abilitySource = GetComponent<AudioSource>();

        Initialize(ability, weaponHolder);
    }

    public void Initialize(Ability _ability, GameObject _weaponHolder)
    {
        ability = _ability;
        buttonImage = GetComponent<Image>();
        abilitySource = GetComponent<AudioSource>();
        buttonImage.sprite = ability.aSprite;
        reqSp = ability.aReqPoint;
        coolDownDuration = ability.aCoolDown;
        ability.Initialize(_weaponHolder);
        cc = _weaponHolder.GetComponent<CharacterController>();
        status = _weaponHolder.GetComponent<Status>();
    }

    public void Action()
    {
        if (!CanAction()) return;
        AbilityTriggerd();
        cc.Attack();
    }

    private bool CanAction()
    {
        // 스킬을 사용 가능한 sp가 없을 때 false 반환.
        if (!status.CanDoSkill(reqSp)) return false;

        // 쿨타임이 아직 안돌았을 때 false 반환.
        if (Time.time <= nextReadyTime) return false;

        return (cc.AnimationCompleted() || ability.aSpecial) ;
    }

    private void AbilityTriggerd()
    {
        nextReadyTime = coolDownDuration + Time.time;

        //abilitySource.clip = ability.aSound;
        //abilitySource.Play();
        ability.TriggerAbility();
    }
}
