using System.Collections;
using UnityEngine;

public class DragonBonesUnitStatus : Status
{
    public Material mat;
    private Color defaultColor;
    public Color hitColor;

    void Start()
    {
        stat.Initialize();
        defaultColor = mat.color;
    }

    protected override IEnumerator Flash()
    {
        mat.color = hitColor;
        yield return new WaitForSeconds(flashTime);
        mat.color = defaultColor;
    }
}
