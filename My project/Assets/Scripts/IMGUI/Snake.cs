using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public int maxLong;
    public Vector2 screenScale;
    public float snakeBlockX = 1;
    public float snakeBlockY = 1;

   

         void OnGUI()
    {
        screenScale.x = Screen.width / 16;
        screenScale.y = Screen.height / 9;

        GUI.Box(new Rect(snakeBlockX * screenScale.x, snakeBlockY * screenScale.y, snakeBlockX * screenScale.x, snakeBlockY * screenScale.y) ,"");
        
    }
}
