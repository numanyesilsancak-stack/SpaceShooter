using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject finishPanel;


    bool oyunDuraklatildimi = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseDurumDegistir();
        }
    }

    private void PauseDurumDegistir()
    {
        oyunDuraklatildimi = !oyunDuraklatildimi;
        if (oyunDuraklatildimi)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);

        }
    }

    public void PausePaneliAc()
    {
        SoundManager.instance.MouseClickSesiYap(); 
        {
            PauseDurumDegistir();
        }
    }

    public void PausePaneliKapat()
    {
        SoundManager.instance.MouseClickSesiYap(); 
        if (oyunDuraklatildimi)
        {
            PauseDurumDegistir();
        }
    }

    public void GameOverPaneliAc()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void TekrarOyna()
    {
        SoundManager.instance.MouseClickSesiYap();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void FinishPaneliAc()
    {
        finishPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void AnaMenuyeDon()
    {
        StartCoroutine(SesiCalVeMenuyeDon());
    }

    IEnumerator SesiCalVeMenuyeDon()
    {
        SoundManager.instance.MouseClickSesiYap();

        // Sesin çalması için kısa gecikme
        yield return new WaitForSecondsRealtime(0.6f); 

        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}