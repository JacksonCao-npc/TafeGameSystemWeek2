using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerGameState gameState = PlayerGameState.Alive;
    public EnemyGameState enemyState = EnemyGameState.Petrol;
    private static GameManager _gameManager;
 
    
    public static GameManager Instance
    {
        get
        {
            return _gameManager;
        }
        private set
        {
            _gameManager = value;
        }
    }

    private void Awake()
    {
        //if our instance is full and its full with not this copy
        if (Instance !=null && Instance != this)
        {
            //destroy this copy from the scene asthere is already on there.
            Destroy(this);
        }
        //else our instance is emoty or its us
        else
        {
            // so instance is this copy
            Instance = this;
        }
    }
    public enum GameState1 { exmaple1,exmaple2};
    
}
public enum PlayerGameState
{
    Dead,
    Alive,
    MenuOpen,
    Paused
}

public enum EnemyGameState
{
    Petrol,
    Following,
    Idle
}
