using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
    public static GameManager instance;

    public List<GameObject> dusmanlar;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameObject[] dusmanDizisi = GameObject.FindGameObjectsWithTag("Enemy");

        dusmanlar = new List<GameObject>(dusmanDizisi);
    }

   public void DusmaniYokEt(GameObject yokEdilicekDusman)
    {
        if (dusmanlar.Count>0)
        {
            dusmanlar.Remove(yokEdilicekDusman);

            if (dusmanlar.Count==0)
            {
                print("oyun bitti");
            }
        }
    }

}
