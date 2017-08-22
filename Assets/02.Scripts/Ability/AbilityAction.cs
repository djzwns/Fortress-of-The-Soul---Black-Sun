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
    }

    public void Action()
    {
        if (!CanAction()) return;
        AbilityTriggerd();
        cc.Attack();
    }

    private bool CanAction()
    {
        // "반드시" 수정할 부분
        float currentSp = cc.gameObject.GetComponent<PlayerStat>().stat.currentSp;
        return (currentSp >= reqSp) && (Time.time > nextReadyTime) && (cc.AnimationCompleted() || ability.aSpecial);
    }

    private void AbilityTriggerd()
    {
        nextReadyTime = coolDownDuration + Time.time;

        //abilitySource.clip = ability.aSound;
        //abilitySource.Play();
        ability.TriggerAbility();
    }
}
