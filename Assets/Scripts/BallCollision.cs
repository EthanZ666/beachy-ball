using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class BallCollision2D : MonoBehaviour
{
    [SerializeField] private ScoreTracker _scoreTracker;

    [Header("Tags on floor halves")]
    [SerializeField] private string _side1Tag = "FloorSide1";
    [SerializeField] private string _side2Tag = "FloorSide2";

    [Header("Serve / Reset")]
    [SerializeField] private Transform _player1Spawn;
    [SerializeField] private Transform _player2Spawn;
    [SerializeField] private float _serveDelaySeconds = 3f;
    [SerializeField] private bool _randomizeFirstSpawn = true;
    [SerializeField] private float _liftOffFloor = 0.05f;

    private Rigidbody2D rb;
    private bool _scoredThisRally;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (_scoreTracker == null)
            _scoreTracker = Object.FindFirstObjectByType<ScoreTracker>();
    }

    void Start()
    {
        Debug.Log($"P1 spawn: {_player1Spawn?.position} | P2 spawn: {_player2Spawn?.position}");
        ServeRandom();
    }

    public void ResetRally()
    {
        _scoredThisRally = false;
    }

        public void ServeRandom()
    {

        int side = Random.value < 0.5f ? 1 : 2;
        StopAllCoroutines();
        StartCoroutine(ServeFrom(side));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (_scoredThisRally || _scoreTracker == null) return;

        var other = collision.collider;

        if (other.CompareTag(_side1Tag))
        {
            _scoreTracker.AddScoreToPlayer2();
            _scoredThisRally = true;
            StartCoroutine(ServeFrom(2));
        }
        else if (other.CompareTag(_side2Tag))
        {
            _scoreTracker.AddScoreToPlayer1();
            _scoredThisRally = true;
            StartCoroutine(ServeFrom(1));
        }
    }

    private IEnumerator ServeFrom(int side)
    {
        rb.simulated = false;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        Transform spawn = side == 1 ? _player1Spawn : _player2Spawn;

        Vector3 target = new Vector3(spawn.position.x, spawn.position.y + _liftOffFloor, transform.position.z);
        transform.SetPositionAndRotation(target, Quaternion.identity);
        rb.position = target;
        Physics2D.SyncTransforms();
        Debug.Log($"Teleported to side {side} at {target}");

        float t = 0f, delay = Mathf.Max(0f, _serveDelaySeconds);
        while (t < delay)
        {
            t += Time.unscaledDeltaTime;
            yield return null;
        }

        rb.simulated = true;
        rb.WakeUp();
        _scoredThisRally = false;
    }
}