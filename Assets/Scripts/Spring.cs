using UnityEngine;
using UnityEngine.Events;

public class Spring : MonoBehaviour
{
    public event UnityAction<int>ScoreChanged;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IWeb web))
        {
            ScoreChanged?.Invoke(web.ScoreAmount);
            web.WebDestroy();
        }
    }
}
