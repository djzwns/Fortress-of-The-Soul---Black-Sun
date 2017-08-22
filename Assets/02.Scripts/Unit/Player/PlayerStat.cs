using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public UnitStat stat;

    private SpriteRenderer sprite;
    private Material defaultMat;
    public Material hitMat;
    public float flashTime = 0.2f;

    void Start()
    {
        stat.Initialize();

        sprite = GetComponent<SpriteRenderer>();
        defaultMat = sprite.material;
    }

    public void Hit()
    {
        StartCoroutine(Flash());
    }

    private IEnumerator Flash()
    {
        sprite.material = hitMat;
        yield return new WaitForSeconds(flashTime);
        sprite.material = defaultMat;
    }
}
