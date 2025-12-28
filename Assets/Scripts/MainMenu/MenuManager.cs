using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    [SerializeField] AudioSource butonClickSesi;

    public void OynaButonunaTiklandi()
    {
        // Debug log ekle
        Debug.Log("Butona tıklandı!");

        // Önce sesi çal
        if (butonClickSesi != null)
        {
            Debug.Log("Ses çalıyor...");
            butonClickSesi.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource atanmamış!");
        }

        // Sonra coroutine başlat
        StartCoroutine(BekleVeOyunaGec());
    }

    IEnumerator BekleVeOyunaGec()
    {
        // Sesin duyulması için bekle
        yield return new WaitForSeconds(0.3f);

        // Oyunu başlat
        OyunaBasla();
    }

    public void OyunaBasla()
    {
        SceneManager.LoadScene("LEVEL_1");
    }

    public void OyundanCik()
    {
        // Ses çalıyorsa ve aktifse çal
        if (butonClickSesi != null && butonClickSesi.enabled)
        {
            butonClickSesi.Play();
            // Uygulamadan çıkmadan önce kısa gecikme
            Invoke("CikisYap", 0.3f);
        }
        else
        {
            // Ses yoksa direkt çık
            CikisYap();
        }
    }

    void CikisYap()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}