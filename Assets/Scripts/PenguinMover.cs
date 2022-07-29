using UnityEngine;
using UnityEngine.Events;

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
    private bool _canAttack;
    private bool _isCatchedSpider;

    public bool IsCatchedSpider => _isCatchedSpider;

    public event UnityAction CatchedSpider;

    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _canMove = true;
        _canAttack = true;
        _isCatchedSpider = false;
        _spring.gameObject.transform.localPosition = new Vector3(0.86f, -0.2f, 0);
    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        if (_isInvert == false)
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

        if (Input.GetKey(KeyCode.Z) && _canAttack == true)
        {
            _canMove = false;
            _rigidBody2D.constraints = RigidbodyConstraints2D.FreezePosition;

            _spring.gameObject.SetActive(true);

            if (_horizontal > 0)
            {
                SetAttackBool(true);

            }
            else if (_horizontal < 0)
            {
                SetAttackBool(false, true, false, false);
            }
            else if (_vertical > 0)
            {
                SetAttackBool(false, false, true, false);

            }
            else if (_vertical < 0)
            {
                SetAttackBool(false, false, false, true);
            }
        }

        if (Input.GetKeyUp(KeyCode.Z) && _canAttack == true)
        {
            _canMove = true;
            _rigidBody2D.constraints = RigidbodyConstraints2D.None;
            _rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

            _spring.gameObject.SetActive(false);
            SetAttackBool();
            
        }
    }

    void FixedUpdate()
    {
        if (_canMove == true)
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

    private void SetAttackBool(bool AttackRight = false, bool AttackLeft = false, bool AttackUp = false, bool AttackDown = false)
    {
        _animator.SetBool("AttackRight", AttackRight);
        _animator.SetBool("AttackLeft", AttackLeft);
        _animator.SetBool("AttackUp", AttackUp);
        _animator.SetBool("AttackDown", AttackDown);
    }

    public void SetCanMove()
    {
        if (_canMove == true)
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
        _isCatched = !_isCatched;
        _animator.SetBool("IsCatch", _isCatched);
    }

    public void SetTransform(Transform transform)
    {
        gameObject.transform.position = transform.position;
    }

    public void SetCanAttack()
    {
        _canAttack = !_canAttack;
    }

    public void SetIsGameOverTrue()
    {
        _animator.SetBool("IsGameOver", true);
        
    }

    public void SetIsCatchedSpiderTrue()
    {
        _isCatchedSpider = true;
        CatchedSpider?.Invoke();
    }
}
