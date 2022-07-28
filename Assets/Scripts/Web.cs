using UnityEngine;

public class Web : MonoBehaviour
{
    [SerializeField] private Transform _webTransform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PenguinMover mover))
        {
            Debug.Log("Попал");
            mover.SetTransform(_webTransform);
            mover.SetCanMoveFalse();
            mover.SetIsCatched();
        }
    }

    public void WebDestroy()
    {
        gameObject.SetActive(false);
    }
}
