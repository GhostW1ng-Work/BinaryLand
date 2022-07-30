using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Spring[] _springs;
    private int _score;

    private void OnEnable()
    {
        for (int i = 0; i < _springs.Length; i++)
        {
            _springs[i].ScoreChanged += OnScoreChanged;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _springs.Length; i++)
        {
            _springs[i].ScoreChanged -= OnScoreChanged;
        }
    }

    private void Start()
    {
        _score = 0;
        _text.text = _score.ToString();
    }

    private void OnScoreChanged(int score)
    {
        _score += score;
        _text.text = _score.ToString();
    }
}
