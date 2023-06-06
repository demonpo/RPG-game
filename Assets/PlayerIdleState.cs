using UnityEngine;

public class PlayerIdleState: PlayerGroundedState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.rigidBody.velocity = Vector2.zero;
    }

    public override void Update()
    {
        base.Update();
        if (xInput == player.facingDirection && player.IsWallDetected()) return;
        if(xInput != 0 && !player.isBusy) stateMachine.ChangeState(player.moveState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
