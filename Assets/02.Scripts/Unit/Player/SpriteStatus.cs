using System.Collections;
using UnityEngine;

public class SpriteStatus : Status
{
    private SpriteRenderer sprite;
    private Material defaultMat;
    public Material hitMat;

    void Start()
    {
        stat.Initialize();

        sprite = GetComponent<SpriteRenderer>();
        defaultMat = sprite.material;
    }

    protected override IEnumerator Flash()
    {
        sprite.material = hitMat;
        yield return new WaitForSeconds(flashTime);
        sprite.material = defaultMat;
    }
}
