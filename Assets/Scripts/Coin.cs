using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Coin Settings")]
    public virtual int value { get; protected set; } = 10;

    protected SpriteRenderer sr;
    [HideInInspector] public Vector3 originalScale;

    protected virtual void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;
    }

   
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         // Example: add value to player score
    //         // other.GetComponent<Player>().AddScore(value);
    //         Destroy(gameObject); // removes the coin
    //     }
    // }
}

