using System;
using UnityEngine;
using Zenject;

public class EnemyTargeter : Targeter<Castle>
{
    private MovementAlongPath pathMovement;
    private Castle castle;

    [Inject]
    public void Construct(MovementAlongPath pathMovement, Castle castle)
    {
        this.pathMovement = pathMovement;
        this.castle = castle;
        pathMovement.OnPathTraversed += OnCastleReached;
        CurrentTarget = null;
    }

    private void OnCastleReached()
    {
        CurrentTarget = castle;
        InvokeOnTargetAcquired(CurrentTarget);
    }
}
