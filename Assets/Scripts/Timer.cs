using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _maxTime;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private PenguinMover[] _penguins;

    private int _time;
 
    private void Start()
    {
        _time = (int)_maxTime;
        _text.text = _time.ToString();
    }

    private void Update()
    {
        _maxTime -= Time.deltaTime;
        _time = (int)_maxTime;
        _text.text = _time.ToString();

        if(_maxTime <= 0)
        {
            _time = 0;
            _text.text = _time.ToString();

            StopPlayer();
        }
    }

    private void StopPlayer()
    {
        for (int i = 0; i < _penguins.Length; i++)
        {
            _penguins[i].SetCanMove();
            _penguins[i].SetCanAttack();
            _penguins[i].SetIsGameOverTrue();
            Time.timeScale = 0;
        }
    }
}
