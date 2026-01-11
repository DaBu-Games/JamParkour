public class RunningState : WalkingState
{
   public RunningState(PlayerController player, PlayerValues values)
      : base(player, values)
   {
      _speed = values.RunSpeed;
   }
}