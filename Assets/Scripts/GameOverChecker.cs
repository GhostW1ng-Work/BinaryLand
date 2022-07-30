using UnityEngine;

public class GameOverChecker : MonoBehaviour
{
    [SerializeField] private Penguin _penguin1;
    [SerializeField] private Penguin _penguin2;

    private void OnEnable()
    {
        _penguin1.CatchedSpider += OnSpiderCatched;
        _penguin2.CatchedSpider += OnSpiderCatched;
    }

    private void OnDisable()
    {
        _penguin1.CatchedSpider -= OnSpiderCatched;
        _penguin2.CatchedSpider -= OnSpiderCatched;
    }

    private void OnSpiderCatched()
    {
        if (_penguin1.IsCatchedSpider == true)
        {
            _penguin2.SetIsGameOverTrue();
            _penguin2.SetCanAttack();
            _penguin2.SetCanMove();

        }
        else if (_penguin2.IsCatchedSpider == true)
        {
            _penguin1.SetIsGameOverTrue();
            _penguin1.SetCanAttack();
            _penguin1.SetCanMove();
        }
    }
}
