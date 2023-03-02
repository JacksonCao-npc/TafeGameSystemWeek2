using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiMenu : MonoBehaviour
{

    public Vector2 screenScale;
    public bool toggle;
    private MouseLook _mouseLook;
    private Movement _movement;

    private void Start()
    {
        _mouseLook = GameObject.Find("Player").GetComponent<MouseLook>();
        _movement= GameObject.Find("Player").GetComponent<Movement>();
    }
    void OnGUI()
    {
        screenScale.x = Screen.width / 16;
        screenScale.y = Screen.height / 9;

        toggle = GUI.Toggle(new Rect(15.75f * screenScale.x, 0 * screenScale.y, 0.25f * screenScale.x, 0.25f * screenScale.y), toggle, "Grid");

        if (toggle)
        {//loop Grid
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    GUI.Box(new Rect(x * screenScale.x, y * screenScale.y, screenScale.x, screenScale.y), "");
                    GUI.Label(new Rect(x * screenScale.x, y * screenScale.y, screenScale.x, screenScale.y), x + "" + y);
                }
            }
        }

        if(GUI.Button(new Rect(15 * screenScale.x, 1 * screenScale.y, 0.5f * screenScale.x, 0.5f * screenScale.y), "Exit Menu"))
        {
            _movement.mainMenuOn = false;
            _movement.mainMenu.gameObject.SetActive(false);
            GameManager.Instance.gameState = PlayerGameState.Alive;

        }

        GUI.Box(new Rect(1 * screenScale.x, 1 * screenScale.y, 4 * screenScale.x, 0.5f * screenScale.y), "Mouse Sensitivity");
        _mouseLook.sensitivity = GUI.HorizontalSlider(new Rect(7 * screenScale.x, 1 * screenScale.y, 4 * screenScale.x, 1 * screenScale.y), _mouseLook.sensitivity, 1.0f, 10.0f);
    }
}
