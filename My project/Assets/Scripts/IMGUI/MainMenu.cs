using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Vector2 screenScale;
    public bool toggle;
    public bool titleMenu;
    public bool playMode;
    public bool exitMode;
  
    public GameObject cube;

    
    public bool startSpin;

    public float cubeMoveSpeed;

    private Animator cubeAnimator;
    private Rigidbody cubeRigid;
    private Renderer cubeRender;
    private float _hSliderValue = 1.0f;

    #region StartGetComponent
    private void Start()
    {

        cubeAnimator = GameObject.Find("Cube").GetComponent<Animator>();
        cubeRigid = GameObject.Find("Cube").GetComponent<Rigidbody>();
        cubeRender=GameObject.Find("Cube").GetComponent<Renderer>();
    }
    #endregion 
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

        #region TtileMenu
        if (titleMenu)
        {
            //Main Panel
            GUI.Box(new Rect(4 * screenScale.x, 0.5f * screenScale.y, 8 * screenScale.x, 8 * screenScale.y), "");
            //Title Box
            GUI.Box(new Rect(6 * screenScale.x, 1 * screenScale.y, 4 * screenScale.x, 0.5f * screenScale.y), "The Game");
            //Title Menu Buttons
            if(GUI.Button(new Rect(6 * screenScale.x, 3 * screenScale.y, 4 * screenScale.x, 1 * screenScale.y), "New Game"))
                {
                cubeAnimator.SetTrigger("MoveToCenter");
                titleMenu = false;
                playMode = true;
            }

            GUI.Button(new Rect(6 * screenScale.x, 5 * screenScale.y, 4 * screenScale.x, 1 * screenScale.y), "Load Game");
            GUI.Button(new Rect(6 * screenScale.x, 7 * screenScale.y, 4 * screenScale.x, 1 * screenScale.y), "Exit Game");
        }
        #endregion

        #region PlayMode
        // Into PlayMode;
        //Generate a random spin for cube 
        float spinSpeed = Random.Range(10, 20);

        //Generate an array for different color
        Color[] cubeColor = new Color[4];
        cubeColor[0] = Color.blue;
        cubeColor[1] = Color.green;
        cubeColor[2] = Color.magenta;
        cubeColor[3] = Color.yellow;

        int colorIndex = Random.Range(0,4);

        //create a random number for cube color so it can randomly change color.
        

        if (playMode)
        {
            //when press the Spin button, cube starts to spin. 
            if (GUI.Button(new Rect(2 * screenScale.x, 2 * screenScale.y, 4 * screenScale.x, 1 * screenScale.y), "Spin"))
            {

                startSpin = true;
            }

            if(startSpin)
            {
                cubeRigid.AddTorque(spinSpeed, spinSpeed, spinSpeed);
            }

            //when press the button, cube Color change randomly;
            if (GUI.Button(new Rect(2 * screenScale.x, 4 * screenScale.y, 4 * screenScale.x, 1 * screenScale.y), "Change Color"))
            {
                cubeRender.material.color = cubeColor[colorIndex];    
            }

            //slider to control cube size,from 1 to 10;
            _hSliderValue = GUI.HorizontalSlider(new Rect(2 * screenScale.x, 6 * screenScale.y, 4 * screenScale.x, 1 * screenScale.y), _hSliderValue, 1.0f, 10.0f);

            cube.transform.localScale = new Vector3(_hSliderValue, _hSliderValue, _hSliderValue);
            GUI.Button(new Rect(2 * screenScale.x, 7 * screenScale.y, 4 * screenScale.x, 0.75f * screenScale.y), "Size");

            GUI.Button(new Rect(13 * screenScale.x, 2 * screenScale.y, 2 * screenScale.x, 1 * screenScale.y), "Save Game");

            //when press this button, playmode will return to the titlemenu.
            if (GUI.Button(new Rect(13 * screenScale.x, 4 * screenScale.y, 2 * screenScale.x, 1 * screenScale.y), "Exit Game"))
            {
                playMode = false;
                exitMode = true;
                
            }
        }

        #endregion

#region ExitMode
        if (exitMode)
        {
            GUI.Button(new Rect(6 * screenScale.x, 5 * screenScale.y, 4 * screenScale.x, 2 * screenScale.y), "Are U Sure");
            if (GUI.Button(new Rect(4 * screenScale.x, 2 * screenScale.y, 3 * screenScale.x, 2 * screenScale.y), "Yes"))
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
            if (GUI.Button(new Rect(9 * screenScale.x, 2 * screenScale.y, 3 * screenScale.x, 2 * screenScale.y), "No"))
            {
                exitMode = false;
                playMode = true;
            }
        }

    }

#endregion 



}
