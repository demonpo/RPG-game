using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.rigidBody.velocity = new Vector2(player.rigidBody.velocity.x, player.jumpForce);
    }

    public override void Update()
    {
        base.Update();
        if (player.rigidBody.velocity.y < 0) stateMachine.ChangeState(player.airState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
