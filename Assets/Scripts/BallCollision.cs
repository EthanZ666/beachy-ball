using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class BallCollision2D : MonoBehaviour
{
    [SerializeField] private ScoreTracker scoreTracker;

    [Header("Tags on floor halves")]
    [SerializeField] private string side1Tag = "FloorSide1"; // hit here -> Player 2 scores
    [SerializeField] private string side2Tag = "FloorSide2"; // hit here -> Player 1 scores

    [Header("Serve / Reset")]
    [SerializeField] private Transform player1Spawn;   // where to place ball when P1 serves/scores
    [SerializeField] private Transform player2Spawn;   // where to place ball when P2 serves/scores
    [SerializeField] private float serveDelaySeconds = 3f; // wait before dropping ball
    [SerializeField] private bool randomizeFirstSpawn = true;
    [SerializeField] private float liftOffFloor = 0.05f;   // tiny Y offset above spawn to avoid overlap

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
        int startSide = randomizeFirstSpawn ? (Random.value < 0.5f ? 1 : 2) : 1;
        StartCoroutine(ServeFrom(startSide));
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
        // Freeze & clear motion
        rb.simulated = false;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        // Teleport (preserve current Z in case your camera expects it)
        Transform spawn = side == 1 ? player1Spawn : player2Spawn;
        if (spawn == null)
        {
            Debug.LogWarning($"Spawn for side {side} not set. Staying put.");
        }
        else
        {
            Vector3 target = new Vector3(spawn.position.x, spawn.position.y + liftOffFloor, transform.position.z);
            transform.SetPositionAndRotation(target, Quaternion.identity);
            rb.position = target;                 // belt & suspenders
            Physics2D.SyncTransforms();           // make physics see the new transform immediately
            Debug.Log($"Teleported to side {side} at {target}");
        }

        // Wait in REAL time so this works even if Time.timeScale == 0
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

#if UNITY_EDITOR
    void OnValidate()
    {
        if (serveDelaySeconds < 0f) serveDelaySeconds = 0f;
        if (liftOffFloor < 0f) liftOffFloor = 0f;
    }
#endif
}