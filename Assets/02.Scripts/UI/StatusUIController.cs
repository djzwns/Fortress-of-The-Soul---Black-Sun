using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUIController : MonoBehaviour
{
    public Text level;
    public Text unitname;
    public Image portrait;
    public Slider hpBar;
    public Text hpText;
    public Slider spBar;
    public Slider epBar;

    public UnitStat stat;

    void FixedUpdate()
    {
        SliderUpdate();
    }

    public void SliderUpdate()
    {
        if (stat == null) return;
        level.text = "LV " + stat.level.ToString();
        unitname.text = stat.unitname;
        portrait.sprite = stat.portrait;
        hpBar.value = stat.currentHp / stat.maxHp;
        hpText.text = stat.currentHp.ToString() + " / " + stat.maxHp.ToString();
        spBar.value = stat.currentSp / stat.maxSp;

        if (epBar == null) return;
        epBar.value = stat.currentEp / stat.maxEp;
    }
}
