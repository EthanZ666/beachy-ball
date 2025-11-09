using UnityEngine;

public class PlayerTwo : Player
{
    private static string IDLE_ANIMATION = "IdleTwo";

    public override void Initialize(PlayerData data)
    {
        base.Initialize(data);
    }

    public override void PlayIdleAnimation()
    {
        var anim = this.GetAnimator();
        anim.SetBool(IDLE_ANIMATION, true);
    }

    public override void StopIdleAnimation()
    {
        var anim = this.GetAnimator();
        anim.SetBool(IDLE_ANIMATION, false);
    }
}