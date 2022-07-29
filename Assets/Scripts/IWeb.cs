using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IWeb : MonoBehaviour 
{
    [SerializeField] private int _scoreAmount;

    public int ScoreAmount => _scoreAmount;
    public void WebDestroy()
    {
        gameObject.SetActive(false);
    }
}
