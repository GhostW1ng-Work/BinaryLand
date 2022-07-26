using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private int _penguinCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PenguinMover mover))
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
        if (_penguinCount == 2)
        {
            Debug.Log("WIN!");
            Time.timeScale = 0;
        }
            
    }
}
