using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private PlayerValues playerValues;
    
    private StateMachine stateMachine;
    
    private IdleState idleState;
    private InAirState inAirState;
    private JumpingState jumpingState;
    private LaunchedState launchedState;
    private RunningState runningState;
    private WalkingState walkingState;

    private void Start()
    {
        stateMachine = new StateMachine();

        idleState = new IdleState(player);
        inAirState = new InAirState(player, playerValues);
        jumpingState = new JumpingState(player, playerValues);
        launchedState = new LaunchedState(player);
        runningState = new RunningState(player, playerValues);
        walkingState = new WalkingState(player, playerValues);
        
        // idle transitions
        stateMachine.AddTransition(new Transition(
            idleState,
            inAirState,
            () => !player.Controller.isGrounded
        ));
        
        stateMachine.AddTransition(new Transition(
            idleState,
            jumpingState,
            () => player.IsJumpBufferd() && player.CanBufferJump()
        ));
        
        stateMachine.AddTransition(new Transition(
            idleState,
            launchedState,
            () => player.LaunchDirection != Vector3.zero
        ));
        
        stateMachine.AddTransition(new Transition(
            idleState,
            runningState,
            () => player.MoveInput != Vector2.zero && player.IsHoldingRun
        ));
        
        stateMachine.AddTransition(new Transition(
            idleState,
            walkingState,
            () => player.MoveInput != Vector2.zero
        ));
        
        // in air transitions
        stateMachine.AddTransition(new Transition(
            inAirState,
            idleState,
            () => player.Controller.isGrounded && player.MoveInput == Vector2.zero
        ));
        
        stateMachine.AddTransition(new Transition(
            inAirState,
            jumpingState,
            () => player.IsJumpBufferd() && player.CanBufferJump() && !player.IsJumping
        ));
        
        stateMachine.AddTransition(new Transition(
            inAirState,
            walkingState,
            () => player.Controller.isGrounded && player.MoveInput != Vector2.zero
        ));
        
        stateMachine.AddTransition(new Transition(
            inAirState,
            runningState,
            () => player.Controller.isGrounded && player.MoveInput != Vector2.zero && player.IsHoldingRun
        ));
        
        stateMachine.AddTransition(new Transition(
            inAirState,
            launchedState,
            () => player.LaunchDirection != Vector3.zero
        ));
        
        // jumping transition
        stateMachine.AddTransition(new Transition(
            jumpingState,
            inAirState,
            () => !player.Controller.isGrounded
        ));
        
        // launched transition
        stateMachine.AddTransition(new Transition(
            launchedState,
            inAirState,
            () => !player.Controller.isGrounded && player.ImpulseVelocity != Vector3.zero
        ));
        
        // running transition
        stateMachine.AddTransition(new Transition(
            runningState,
            idleState,
            () => player.MoveInput == Vector2.zero
        ));
        
        stateMachine.AddTransition(new Transition(
            runningState,
            walkingState,
            () => player.MoveInput != Vector2.zero && !player.IsHoldingRun
        ));
        
        stateMachine.AddTransition(new Transition(
            runningState,
            inAirState,
            () => !player.Controller.isGrounded
        ));
        
        stateMachine.AddTransition(new Transition(
            runningState,
            launchedState,
            () => player.LaunchDirection != Vector3.zero
        ));
        
        stateMachine.AddTransition(new Transition(
            runningState,
            jumpingState,
            () => player.IsJumpBufferd() && player.CanBufferJump()
        ));
        
        // walking transition
        stateMachine.AddTransition(new Transition(
            walkingState,
            idleState,
            () => player.MoveInput == Vector2.zero
        ));
        
        stateMachine.AddTransition(new Transition(
            walkingState,
            runningState,
            () => player.MoveInput != Vector2.zero && player.IsHoldingRun
        ));
        
        stateMachine.AddTransition(new Transition(
            walkingState,
            inAirState,
            () => !player.Controller.isGrounded
        ));
        
        stateMachine.AddTransition(new Transition(
            walkingState,
            launchedState,
            () => player.LaunchDirection != Vector3.zero
        ));
        
        stateMachine.AddTransition(new Transition(
            walkingState,
            jumpingState,
            () => player.IsJumpBufferd() && player.CanBufferJump()
        ));
        
        
        stateMachine.SwitchState(idleState);
    }

    private void Update()
    {
        stateMachine.OnUpdate();
    }

    private void FixedUpdate()
    {
        stateMachine.OnFixedUpdate();
    }
}