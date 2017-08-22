using UnityEngine;
using GUIAnimation;

public class MainScene : MonoBehaviour
{
    public GameObject exitWindow;

    private bool toggleInventory;
    public GUIAnimator inventory;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseWindow();
        }
    }

    public void TogglePauseWindow()
    {
        exitWindow.SetActive(!exitWindow.activeSelf);
    }

    public void ToggleInventoryWindow()
    {
        if (toggleInventory)
            GUIAnimSystem.instance.AnimIn(inventory);
        else
            GUIAnimSystem.instance.AnimOut(inventory);

        toggleInventory = !toggleInventory;
    }
}
