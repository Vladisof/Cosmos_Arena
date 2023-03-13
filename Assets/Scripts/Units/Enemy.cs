using DG.Tweening;
using Units;
using UnityEngine;

public class Enemy : Unit
{
    protected Unit Player;
    protected Sequence SequenceSpawn;

    [SerializeField] private Collider _collider;
    
    private Vector3 _normalScale;
    private bool _finishSpawn = false;

    public virtual void Init(Unit player)
    {
        Init();

        Player = player;
        _normalScale = transform.localScale;
        AnimationSpawn();
    }

    protected virtual void Update()
    {
        if(!_finishSpawn)   return;
    }

    protected void LookAtPlayer()
    {
        if (Player != null)
        {
            transform.LookAt(Player.transform);
        }
    }

    protected virtual void AnimationSpawn()
    {
        transform.localScale = Vector3.zero;
        _collider.enabled = false;

        SequenceSpawn = DOTween.Sequence();
        SequenceSpawn
            .AppendCallback(() => transform.localScale = Vector3.zero)
            .AppendCallback(() => transform.DOScale(_normalScale, 1))
            .AppendInterval(1)
            .AppendCallback(FinishSpawn);
    }

    private void FinishSpawn()
    {
        _finishSpawn = true;
        _collider.enabled = true;
    }
}
