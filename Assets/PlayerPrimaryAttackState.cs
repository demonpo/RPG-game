using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{
    private int comboCounter;
    private float lasTimerAttacked;
    private float comboWindow = 2;
    public PlayerPrimaryAttackState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if (comboCounter > 2 || Time.time >=  lasTimerAttacked + comboWindow) comboCounter = 0;
        player.animator.SetInteger("ComboCounter", comboCounter);

        float attackDirection = player.facingDirection;
        if (xInput != 0) attackDirection = xInput;
        
        player.SetVelocity(player.attackMovement[comboCounter].x * attackDirection, player.attackMovement[comboCounter].y);
        stateTimer = .1f;
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0) player.ZeroVelocity();
        if (triggerCalled) stateMachine.ChangeState(player.idleState);
    }

    public override void Exit()
    {
        base.Exit();
        player.StartCoroutine("BusyFor", .2f);
        comboCounter++;
        lasTimerAttacked = Time.time;
    }
}
