using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] float speed;

    private void Update()
    {
        transform.Translate(Vector2.up*speed*Time.deltaTime);
    }
}
