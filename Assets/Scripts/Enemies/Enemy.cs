using UnityEngine;

public abstract class Enemy : MonoBehaviour 
{
    [SerializeField] private int _scoreAmount;

    public int ScoreAmount => _scoreAmount;
    public void WebDestroy()
    {
        gameObject.SetActive(false);
    }
}
