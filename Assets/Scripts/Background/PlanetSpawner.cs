using System.Collections;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    [Header("Ayarlar")]
    [SerializeField] float minX = -3f;
    [SerializeField] float maxX = 3f;
    [SerializeField] float sabitY = 12f;
    [SerializeField] float firlatmaSuresi = 5f;

    [Header("Elements")]
    [SerializeField] GameObject[] gezegenPrefab;


    private void Start()
    {
        StartCoroutine(GezegenFirlatRoutine());
    }

    IEnumerator GezegenFirlatRoutine()
    {
        while (true)
        {
            float rastgeleX = Random.Range(minX, maxX);
            Vector3 firlatmaPozisyonu = new Vector3(rastgeleX, sabitY, 0);

            int rastgeleIndex = Random.Range(0,gezegenPrefab.Length);
            GameObject gezegenPrefabs = Instantiate(gezegenPrefab[rastgeleIndex], firlatmaPozisyonu,Quaternion.identity);

            Destroy(gezegenPrefabs,40f );
            yield return new WaitForSeconds(firlatmaSuresi);
        }
    }
}
