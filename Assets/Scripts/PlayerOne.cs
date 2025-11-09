using UnityEngine;

public class PlayerOne : Player
{
    private static string IDLE_ANIMATION = "IdleOne";

    public override void Initialize(PlayerData data)
    {
        base.Initialize(data);
    }

    public override void PlayIdleAnimation()
    {
        Transform sprite = transform.Find("AnimSprite");
        Animator anim = sprite.GetComponent<Animator>();
        anim.SetTrigger("IdleOne");
    }

    public override void StopIdleAnimation()
    {
        Transform sprite = transform.Find("AnimSprite");
        Animator anim = sprite.GetComponent<Animator>();
        anim.ResetTrigger("IdleOne");
    }

}