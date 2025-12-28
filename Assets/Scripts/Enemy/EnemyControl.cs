using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    // düşman hattının izlediği pozisyon algoritması (diziler kullanıyoruz)
    public Transform[] hedefler;
    public float hareketHizi = 3f;

    int mevcutHedeflerIndexi = 0;

    public int hasarMiktari = 15;

    private void Awake()
    {

    }

    private void Update()
    {
        if (hedefler == null || hedefler.Length == 0)
            return;



        transform.position = Vector3.MoveTowards(transform.position, hedefler[mevcutHedeflerIndexi].position, hareketHizi * Time.deltaTime);

        if (Vector3.Distance(transform.position, hedefler[mevcutHedeflerIndexi].position) < 0.01f)
        {
            mevcutHedeflerIndexi++; //son index sonrası hata verecek hala index arayacak şart koşmamız gerekir artık

            if (mevcutHedeflerIndexi >= hedefler.Length)
            {
                mevcutHedeflerIndexi = 0;
                transform.position = hedefler[mevcutHedeflerIndexi].position; //başa devirdaim
            }
        }

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            // düşman patlama sesi çal
            SoundManager.instance.EnemyexplosionSesiYap();

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