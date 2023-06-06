using UnityEngine;
using UnityEngine.UIElements;

public class PlayerWallSlideState : PlayerState
{
    // Start is called before the first frame update
    public PlayerWallSlideState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.wallJumpState);
            return;
        }
        if (xInput != 0 && player.facingDirection != xInput) stateMachine.ChangeState(player.idleState);
        if (yInput < 0) 
            player.rigidBody.velocity = new Vector2(0, player.rigidBody.velocity.y);
        else
            player.rigidBody.velocity = new Vector2(0, player.rigidBody.velocity.y * .7f);
        if (player.IsGroundDetected()) stateMachine.ChangeState(player.idleState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
