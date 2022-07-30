using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Spider : Enemy 
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform[] _points;

    private BoxCollider2D _collider2D;
    private int _currentPoint;

    private void Start()
    {
        _currentPoint = 0;
        _collider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _points[_currentPoint].position, _moveSpeed * Time.deltaTime);

        if(Vector2.Distance(transform.position, _points[_currentPoint].position) < 0.2f)
        {
            _currentPoint++;
        }

        if(_currentPoint == _points.Length)
        {
            _currentPoint = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Penguin penguin))
        {
            penguin.SetIsCatched();
            penguin.SetCanMove();
            penguin.SetCanAttack();
            penguin.SetIsCatchedSpiderTrue();
            _collider2D.enabled = false;
        }
    }
}
