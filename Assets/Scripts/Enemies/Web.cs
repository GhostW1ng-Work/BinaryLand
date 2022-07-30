using UnityEngine;

public class Web : Enemy
{
    [SerializeField] private Transform _webTransform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Penguin penguin))
        {
            penguin.SetCanAttack();
            penguin.SetIsCatched();
            penguin.SetTransform(_webTransform);
            penguin.SetCanMove();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Penguin penguin))
        {
            penguin.SetIsCatched();
            penguin.SetCanAttack();
            penguin.SetCanMove();
        }
    }
}
