using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("Game Systems RPG/Player/Movement")]
[RequireComponent(typeof(CharacterController))]

public class Movement : MonoBehaviour
{
    [Header("UI Component")]
    public GameObject mainMenu;
    public bool mainMenuOn;

    [SerializeField]
    private Vector3 _moveDir;
    private CharacterController _charC;

    [Header("Character Speed")]
    public float speed = 5f;
    public float gravity = 20f;
    public float  jumpSpeed = 8;
    
    void Start()
    {
        _charC = GetComponent<CharacterController>();
    }

 
    void Update()
    {
        Move();
        OpenGUI();
    }

     void Move()
    {
        if (GameManager.Instance.gameState == PlayerGameState.Alive)
        {
            if (_charC.isGrounded)
            {
                _moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
                _moveDir = transform.TransformDirection(_moveDir);
                _moveDir *= speed;
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    speed = 20;
                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    speed = 5;
                }

                if (Input.GetButton("Jump"))
                {
                    _moveDir.y = jumpSpeed;
                }
            }
        }

        _moveDir.y -= gravity * Time.deltaTime;

        _charC.Move(_moveDir * Time.deltaTime);
    }

    void OpenGUI()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            
            if (mainMenuOn==false)
            { mainMenu.gameObject.SetActive(true);
                mainMenuOn = true;
                GameManager.Instance.gameState = PlayerGameState.MenuOpen;
                
            }
            else if(mainMenuOn==true)
            {
                mainMenu.gameObject.SetActive(false);
                mainMenuOn = false;
                GameManager.Instance.gameState = PlayerGameState.Alive;
            }

        }
    }


}
