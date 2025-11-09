using UnityEngine;

public class PlayerOne : Player
{
    private static string IDLE_ANIMATION = "IdleOne";

    public override void Initialize(PlayerKeyData data)
    {
        base.Initialize(data);
    }

    public override void PlayIdleAnimation()
    {
        this.GetAnimator().SetTrigger(IDLE_ANIMATION);
    }

    public override Animator GetAnimator()
    {
        Transform sprite = transform.Find("AnimSprite");
        Animator anim = sprite.GetComponent<Animator>();
        return anim;
    }

}