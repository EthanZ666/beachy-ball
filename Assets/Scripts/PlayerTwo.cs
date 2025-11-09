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
        this.GetAnimator().SetTrigger(IDLE_ANIMATION);
    }

    public override Animator GetAnimator()
    {
        Transform sprite = transform.Find("AnimSprite2");
        Animator anim = sprite.GetComponent<Animator>();
        return anim;
    }
}