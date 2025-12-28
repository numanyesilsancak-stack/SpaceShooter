using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float hiz = 10f;

    [SerializeField] GameObject effect;

    private void Update()
    {
        transform.Translate(Vector3.up*hiz*Time.deltaTime);
    }

    // collider temasları ile nesne etkileşimi! her nesne yok edilmeyecek etikete özel yok ediş
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Meteor"))
        {
            Instantiate(effect, transform.position,Quaternion.identity);    
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
