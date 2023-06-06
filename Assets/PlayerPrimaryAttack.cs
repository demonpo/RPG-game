using Unity.VisualScripting;
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
        comboCounter++;
        lasTimerAttacked = Time.time;
    }
}
