using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IWeb : MonoBehaviour 
{
    public void WebDestroy()
    {
        gameObject.SetActive(false);
    }
}
