using UnityEngine;
using UnityEngine.UI;
public class PlayerHeallth : MonoBehaviour
{
    public static PlayerHeallth instance;
    [SerializeField] int maxSaglik = 100;
    int gecerlisaglik;

    [SerializeField] Image healthFill;

    public void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        gecerlisaglik = maxSaglik;
        HealthBarGuncelle();

    }
    
    public void HasarAl(int hasarMiktari)
    {
        gecerlisaglik -= hasarMiktari;

        gecerlisaglik = Mathf.Clamp(gecerlisaglik, 0, maxSaglik);

        HealthBarGuncelle();

        if (gecerlisaglik <= 0 )
        {
            UIManager.Instance.GameOverPaneliAc();
            gameObject.SetActive(false);
        }
        
    }


    void HealthBarGuncelle()
    {
        if (healthFill != null)
        {
            float canMiktari = (float)gecerlisaglik / maxSaglik;
            healthFill.fillAmount = canMiktari;
        }
    }
}
