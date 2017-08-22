using UnityEngine;
using GUIAnimation;

public class TTSScene : MonoBehaviour
{
    public GUIAnimator text;

    void Start()
    {
        GUIAnimSystem.instance.AnimIn(text);
    }
}
