using System;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.Mouse0)) stateMachine.ChangeState(player.primaryAttackState);
        if (!player.IsGroundDetected()) stateMachine.ChangeState(player.airState);
        if(Input.GetKeyDown(KeyCode.Space) && player.IsGroundDetected()) stateMachine.ChangeState(player.jumpState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
