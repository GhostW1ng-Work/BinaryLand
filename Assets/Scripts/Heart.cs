using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private Transform _heartTransform;
    [SerializeField] private int _penguinCount;
    [SerializeField] private Penguin[] _penguins;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Penguin mover))
        {
            _penguinCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _penguinCount--;
    }

    private void Update()
    {
        if (_penguinCount == _penguins.Length)
        {
            _spriteRenderer.enabled = false;
            for (int i = 0; i < _penguins.Length; i++)
            {
                _penguins[i].SetTransform(_heartTransform);
                _penguins[i].EnableWinAnimation();
                _penguins[i].DisableColliders();
                _penguins[i].SetCanMove();
            }
        }       
    }
}
