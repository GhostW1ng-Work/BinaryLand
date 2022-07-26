using UnityEngine;

public class Web : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PenguinMover mover))
        {
            Debug.Log("Попал");
            mover.SetCanMoveFalse();
        }
    }

    public void WebDestroy()
    {
        gameObject.SetActive(false);
    }
}
