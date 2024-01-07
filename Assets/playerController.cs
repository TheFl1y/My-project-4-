using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    private ControllerMovement3D _controllerMoveMent;
    private Vector3 _moveInput;
    
    private void Awake(){
        _controllerMoveMent = GetComponent<ControllerMovement3D>();
    }
    public void OnMove(InputValue value){
        Vector2 Input = value.Get<Vector2>();
        _moveInput = new Vector3(Input.x , 0f , Input.y);
    }
    private void Update(){
        if (_controllerMoveMent == null){
            return;
        }
        _controllerMoveMent.SetMoveInput(_moveInput);
        _controllerMoveMent.SetLookDirection(_moveInput);
    }
}
