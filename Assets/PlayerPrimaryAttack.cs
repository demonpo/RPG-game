using UnityEngine;

public class PlayerPrimaryAttack : PlayerState
{
    private int comboCounter;
    private float lasTimerAttacked;
    private float comboWindow = 2;
    public PlayerPrimaryAttack(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if (comboCounter > 2 || Time.time >=  lasTimerAttacked + comboWindow) comboCounter = 0;
        player.animator.SetInteger("ComboCounter", comboCounter);
        player.SetVelocity(player.attackMovement[comboCounter].x * player.facingDirection, player.attackMovement[comboCounter].y);
        stateTimer = .1f;
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0) player.rigidBody.velocity = Vector2.zero;
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
