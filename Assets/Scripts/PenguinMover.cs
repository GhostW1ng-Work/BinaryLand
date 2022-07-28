using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinMover : MonoBehaviour
{
    [SerializeField] private float _speedRun = 20.0f;
    [SerializeField] private bool _isInvert = false;
    [SerializeField] private bool _canMove;
    [SerializeField] private Spring _spring;
    [SerializeField] private float Z1;
    [SerializeField] private float Z2;


    private Rigidbody2D _rigidBody2D;
    private Animator _animator;

    private float _horizontal;
    private float _vertical;
    private float _moveLimiter = 0.7f;
    private bool _isCatched = false;

    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _canMove = true;
    }

    void Update()
    {

        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        if(_isInvert == false)
        {
            if (_horizontal > 0)
            {
                _spring.gameObject.transform.localPosition = new Vector3(0.86f, -0.2f, 0);
                _spring.gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
            }

            if (_horizontal < 0)
            {
                _spring.gameObject.transform.localPosition = new Vector3(-0.86f, -0.2f, 0);
                _spring.gameObject.transform.localRotation = new Quaternion(0, 0, 180, 0);
            }
         
        }
        else
        {
            if (_horizontal > 0)
            {
                _spring.gameObject.transform.localPosition = new Vector3(-0.86f, -0.2f, 0);
                _spring.gameObject.transform.localRotation = new Quaternion(0, 0, Z1, 360);
            }

            if (_horizontal < 0)
            {
                _spring.gameObject.transform.localPosition = new Vector3(0.86f, -0.2f, 0);
                _spring.gameObject.transform.localRotation = new Quaternion(0, 0, Z2, 360);
            }
        }

        if (_vertical > 0)
        {
            _spring.gameObject.transform.localPosition = new Vector3(0.167f, 0.961f, 0);
            _spring.gameObject.transform.localRotation = new Quaternion(0, 0, 90, 90);
        }
        if (_vertical < 0)
        {
            _spring.gameObject.transform.localPosition = new Vector3(-0.167f, -0.979f, 0);
            _spring.gameObject.transform.localRotation = new Quaternion(0, 0, -90, 90);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            _spring.gameObject.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            _spring.gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        if(_canMove == true)
        {
            if (_horizontal != 0 && _vertical != 0)
            {
                _horizontal *= _moveLimiter;
                _vertical *= _moveLimiter;
                
            }

            _animator.SetFloat("HorizontalSpeed", _horizontal);
            _animator.SetFloat("VerticalSpeed", _vertical);

            if (_isInvert == false)
                _rigidBody2D.velocity = new Vector2(_horizontal * _speedRun, _vertical * _speedRun);

            else
                _rigidBody2D.velocity = new Vector2(-_horizontal * _speedRun, _vertical * _speedRun);
        }  
    }

    public void SetCanMove()
    {
        if(_canMove == true)
        {
            _rigidBody2D.constraints = RigidbodyConstraints2D.FreezePosition;
            _canMove = false;
        }
        else
        {
            _canMove = true;
            _rigidBody2D.constraints = RigidbodyConstraints2D.None;
            _rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        
    }

    public void SetIsCatched()
    {
        if(_isCatched == true)
        {
            _isCatched = false;
            _animator.SetBool("IsCatch", _isCatched);
        }
        else
        {
            _isCatched = true;
            _animator.SetBool("IsCatch", _isCatched);
        }
    }

    public void SetTransform(Transform transform)
    {
        gameObject.transform.position = transform.position;
    }
}
