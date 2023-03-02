using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
   private enum RotationalAxis
    {
        MouseX,
        MouseY
    }
    private RotationalAxis _axis = RotationalAxis.MouseX;
    [Range(0,100),Header("Sensitivity")]
    public float sensitivity = 15f;
    public bool invertMouse;

    private Vector2 _clamp = new Vector2(-60f, 60);

    private float _rotationY;
    
    void Start()
    {
       if(this.gameObject.tag=="Player")
        {
            _axis = RotationalAxis.MouseX;
        }
       else
        {
            _axis = RotationalAxis.MouseY;
        }
       //if there is Rigidbody attached
       if(GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    void Update()
    {
        if (GameManager.Instance.gameState == PlayerGameState.Alive)
        {
            if (_axis == RotationalAxis.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
            }
            else
            {
                _rotationY += Input.GetAxis("Mouse Y") * sensitivity;
                _rotationY = Mathf.Clamp(_rotationY, _clamp.x, _clamp.y);
                if (invertMouse)
                {
                    transform.localEulerAngles = new Vector3(-_rotationY, 0, 0);
                }
                else if (!invertMouse)
                {
                    transform.localEulerAngles = new Vector3(_rotationY, 0, 0);
                }
            }
        }
    }
    
}
