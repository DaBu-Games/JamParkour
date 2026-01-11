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
        
        // in air transitions
        
        // jumping transition
        
        // launched transition
        
        // running transition
        
        // walking transition
        
        

    }
}