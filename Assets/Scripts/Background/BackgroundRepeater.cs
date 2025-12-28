using System;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
{

    [SerializeField] float yukseklik;

    private void Update()
    {
        if (transform.position.y<-yukseklik)
        {
            PozisyonuGuncelle();
        }
    }

    private void PozisyonuGuncelle()
    {
        Vector2 pos = new Vector2(0, yukseklik * 2);
        transform.position =(Vector2) transform.position + pos;
    }
}
