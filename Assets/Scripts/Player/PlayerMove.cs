using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    [Header("Elementler")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;


    [Header("Ayarlar")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float minX = -3.3f;
    [SerializeField] float maxX = 3.3f;
    [SerializeField] float minY = 4f;
    [SerializeField] float maxY = 4f;

    private void Update()
    {
        HareketFNC();

        // Sol tık kontrolü - ancak UI ye tıklanmıyorsa ateş et
        if (Input.GetMouseButtonDown(0))
        {
            // UI ye tıklama kontrolü
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                MermiyiFirlatFNC();
            }
        }
    }

    private void HareketFNC()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 hareketVector = new Vector3(h, v, 0);
        hareketVector = hareketVector.normalized; // çapraz gitsen de 1 birim gider kök2 birim gitmez


        transform.Translate(hareketVector * moveSpeed * Time.deltaTime);

        Vector3 clampPos = transform.position;


        clampPos.x = Mathf.Clamp(clampPos.x, minX, maxX);
        clampPos.y = Mathf.Clamp(clampPos.y, minY, maxY);

        transform.position = clampPos;
    }

    void MermiyiFirlatFNC()
    {
        //mermi prefab oluştur
        Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
    }
}