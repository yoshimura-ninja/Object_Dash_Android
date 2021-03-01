using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.0f;
    //[serializeField] private float  jumpPower=3;

    private CharacterController _characterController;

    private Transform _transform;
    private Vector3 _moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
