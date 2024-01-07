using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ControllerMovement3D : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Movement")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _turnSpeed = 10f;
    [SerializeField] private GameObject _mainCamera;
    private float _speed = 0f;
    private bool _hasMoveInput;
    private Vector3 _moveInput;
    private Vector3 _lookDirection;

    private CharacterController _characterController;

    private void Start(){
        _characterController = GetComponent<CharacterController>();
    }
    public void SetMoveInput(Vector3 input){
        _hasMoveInput = input.magnitude > 0.1f;
        _moveInput = _hasMoveInput ? input : Vector3.zero;
    }
    public void SetLookDirection(Vector3 direction){
        _lookDirection = new Vector3(direction.x , 0f , direction.z).normalized;
    }

    private void FixedUpdate(){
        _speed = 0;
        float targetRotation = 0f;

        if(_moveInput != Vector3.zero){
            _speed = _moveSpeed;
        }

        targetRotation = Quaternion.LookRotation(_lookDirection).eulerAngles.y +_mainCamera.transform.rotation.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0 , targetRotation , 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _turnSpeed * Time.fixedDeltaTime);

        _moveInput = rotation * Vector3.forward;
        _characterController.Move(_moveInput * _speed * Time.fixedDeltaTime);
    }
}
