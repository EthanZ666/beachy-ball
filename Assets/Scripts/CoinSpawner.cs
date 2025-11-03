using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [System.Serializable]
    public class CoinLayer
    {
        public Coin[] coinPrefabs;
        public float minY;
        public float maxY;
        public int maxCoin = 5;

        [HideInInspector] public int currentCoin;
    }

    public CoinLayer[] layers;
    public float spawnInterval = 20f;
    public float minX = -8f, maxX = 8f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnCoin();
            timer = 0f;
        }
    }

    void SpawnCoin()
    {
        foreach (CoinLayer layer in layers)
        {
            if (layer.currentCoin >= layer.maxCoin) continue;

            // Pick a random coin type (can be BigCoin, SmallCoin, etc.)
            Coin prefab = layer.coinPrefabs[Random.Range(0, layer.coinPrefabs.Length)];

            float X = Random.Range(minX, maxX);
            float Y = Random.Range(layer.minY, layer.maxY);
            Vector3 spawnPos = new Vector3(X, Y, 0);

            // Spawn as Coin type
            Coin coinInstance = Instantiate(prefab, spawnPos, Quaternion.identity);

            layer.currentCoin++;

            // Attach tracker so when the coin is destroyed, it decrements the count
            CoinTracker tracker = coinInstance.gameObject.AddComponent<CoinTracker>();
            tracker.layer = layer;
        }
    }
}

