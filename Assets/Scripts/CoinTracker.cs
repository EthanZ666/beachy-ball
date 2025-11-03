using UnityEngine;

public class CoinTracker : MonoBehaviour
{
    [HideInInspector] public CoinSpawner.CoinLayer layer;

    void OnDestroy()
    {
        if (layer != null)
            layer.currentCoin--;
    }
}
// protected virtual void OnTriggerEnter2D(Collider2D other)
// {
//     if (other.CompareTag("Player"))
//     {
//         Debug.Log($"Collected {value}-point coin!");
//         Destroy(gameObject);
//     }
// }