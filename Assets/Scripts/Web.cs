using UnityEngine;

public class Web : IWeb
{
    [SerializeField] private Transform _webTransform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PenguinMover mover))
        {
            Debug.Log("Попал");
            mover.SetCanAttack();
            mover.SetIsCatched();
            mover.SetTransform(_webTransform);
            mover.SetCanMove();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PenguinMover mover))
        {
            mover.SetIsCatched();
            mover.SetCanAttack();
            mover.SetCanMove();
        }
    }
}
