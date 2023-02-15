using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Vector2 screenScale;
    public bool toggle;
    public bool isPlaying;
    void OnGUI()
    {
        screenScale.x = Screen.width / 16;
        screenScale.y = Screen.height / 9;

        toggle = GUI.Toggle(new Rect(15.75f * screenScale.x, 0 * screenScale.y, 0.25f * screenScale.x, 0.25f * screenScale.y),toggle, "Grid");
        
        if(toggle)
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


        GUI.Box(new Rect(5 * screenScale.x, 0.5f * screenScale.y, 6* screenScale.x, 8 * screenScale.y), "");
        GUI.Box(new Rect(5.5f * screenScale.x, 0.75f * screenScale.y, 5 * screenScale.x, 0.75f * screenScale.y), "Title");
       

       if(isPlaying)
        {
            GUI.Box(new Rect(6 * screenScale.x, 2 * screenScale.y, 4 * screenScale.x, 5 * screenScale.y), "isPlaying");
          //  GUI.Button(new Rect(6 * screenScale.x, 7 * screenScale.y, 4 * screenScale.x, 1 * screenScale.y), "Exit");
            if(GUI.Button(new Rect(6 * screenScale.x, 7 * screenScale.y, 4 * screenScale.x, 1 * screenScale.y), "Exit"))
            {
                isPlaying =false;
            }
        }

        if (!isPlaying)
        {
            if (GUI.Button(new Rect(6 * screenScale.x, 3 * screenScale.y, 4 * screenScale.x, 1 * screenScale.y), "Play "))
            {
                isPlaying = true;
            }
            GUI.Box(new Rect(6 * screenScale.x, 5 * screenScale.y, 4 * screenScale.x, 1 * screenScale.y), "Option");
            GUI.Box(new Rect(6 * screenScale.x, 7 * screenScale.y, 4 * screenScale.x, 1 * screenScale.y), "Exit");
        }
        
    }
     


}