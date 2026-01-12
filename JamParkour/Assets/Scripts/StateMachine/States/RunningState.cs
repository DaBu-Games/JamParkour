public class RunningState : WalkingState
{
   public RunningState(PlayerController player, PlayerValues values)
      : base(player, values)
   {
      _maxSpeed = values.MaxRunSpeed;
      _acceleration = values.RunAcceleration;
   }
}