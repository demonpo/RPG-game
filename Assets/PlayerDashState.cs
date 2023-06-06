using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = player.dashDuration;
    }

    public override void Update()
    {
        base.Update();
        if (!player.IsGroundDetected() && player.IsWallDetected()) stateMachine.ChangeState(player.wallSlideState);
        player.SetVelocity(player.dashSpeed * player.dashDirection, 0);
        if (stateTimer < 0 ) stateMachine.ChangeState(player.idleState);
    }

    public override void Exit()
    {
        base.Exit();
        player.SetVelocity(0, player.rigidBody.velocity.y);
    }
}
