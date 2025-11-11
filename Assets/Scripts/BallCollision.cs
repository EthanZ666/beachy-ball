using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class BallCollision2D : MonoBehaviour
{
    [SerializeField] private ScoreTracker scoreTracker;

    [Header("Tags on floor halves")]
    [SerializeField] private string side1Tag = "FloorSide1";
    [SerializeField] private string side2Tag = "FloorSide2";

    [Header("Serve / Reset")]
    [SerializeField] private Transform player1Spawn;
    [SerializeField] private Transform player2Spawn;
    [SerializeField] private float serveDelaySeconds = 3f;
    [SerializeField] private bool randomizeFirstSpawn = true;
    [SerializeField] private float liftOffFloor = 0.05f;

    private Rigidbody2D rb;
    private bool scoredThisRally;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (scoreTracker == null)
            scoreTracker = Object.FindFirstObjectByType<ScoreTracker>();
    }

    void Start()
    {
        Debug.Log($"P1 spawn: {player1Spawn?.position} | P2 spawn: {player2Spawn?.position}");
        ServeRandom();
    }

    public void ResetRally()
    {
        scoredThisRally = false;
    }

        public void ServeRandom()
    {

        int side = Random.value < 0.5f ? 1 : 2;
        StopAllCoroutines();
        StartCoroutine(ServeFrom(side));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (scoredThisRally || scoreTracker == null) return;

        var other = collision.collider;

        if (other.CompareTag(side1Tag))
        {
            scoreTracker.AddScoreToPlayer2();
            scoredThisRally = true;
            StartCoroutine(ServeFrom(2));
        }
        else if (other.CompareTag(side2Tag))
        {
            scoreTracker.AddScoreToPlayer1();
            scoredThisRally = true;
            StartCoroutine(ServeFrom(1));
        }
    }

    private IEnumerator ServeFrom(int side)
    {
        rb.simulated = false;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        Transform spawn = side == 1 ? player1Spawn : player2Spawn;

        Vector3 target = new Vector3(spawn.position.x, spawn.position.y + liftOffFloor, transform.position.z);
        transform.SetPositionAndRotation(target, Quaternion.identity);
        rb.position = target;
        Physics2D.SyncTransforms();
        Debug.Log($"Teleported to side {side} at {target}");

        float t = 0f, delay = Mathf.Max(0f, serveDelaySeconds);
        while (t < delay)
        {
            t += Time.unscaledDeltaTime;
            yield return null;
        }

        rb.simulated = true;
        rb.WakeUp();
        scoredThisRally = false;
    }
}