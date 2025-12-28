using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    [System.Serializable]

    public class Wave
    {
        public GameObject[] enemies; // BU DALGADA HANGİ PREFABLAR VAR
    }

    public Wave[] waves;            // TÜM DALGALAR
    public Transform[] spawnPoints; // NEREDEN ÇIKACAKLAR

    int currentWave = 0;
    int aliveEnemyCount = 0;
    public int hasarMiktari = 15;

    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[currentWave];

        foreach (GameObject enemyPrefab in wave.enemies)
        {
            Transform spawn = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Instantiate(enemyPrefab, spawn.position, Quaternion.identity);
            aliveEnemyCount++;

            yield return new WaitForSeconds(0.5f);
        }
    }

    public void EnemyDied()
    {
        aliveEnemyCount--;

        if (aliveEnemyCount <= 0)
        {
            currentWave++;

            if (currentWave < waves.Length)
                StartCoroutine(SpawnWave());
            else
                Debug.Log("OYUN BİTTİ");
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            SoundManager.instance.MouseClickSesiYap();

            GameManager.instance.DusmaniYokEt(this.gameObject);

            Destroy(other.gameObject);

            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHeallth.instance.HasarAl(hasarMiktari);

            Destroy(gameObject);
        }
    }
}
