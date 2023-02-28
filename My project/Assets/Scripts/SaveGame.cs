using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    private MainMenu _mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        _mainMenu = GameObject.Find("GameObject").GetComponent<MainMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavePrefs()
    {
        PlayerPrefs.SetInt("Color", _mainMenu.colorIndex);
        
    }
}
