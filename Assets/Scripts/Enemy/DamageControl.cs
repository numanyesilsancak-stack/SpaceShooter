using UnityEngine;

public class DamageControl : MonoBehaviour
{
    public int hasarMiktari = 20;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHeallth.instance.HasarAl(hasarMiktari);
            Destroy(gameObject);
        }
    }
}
