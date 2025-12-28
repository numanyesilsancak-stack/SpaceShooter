using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    public static SoundManager instance;

    [SerializeField] AudioSource mouseclick;
    [SerializeField] AudioSource enemyexplosion;
    [SerializeField] AudioSource meteorexplosion;
    [SerializeField] AudioSource playerexplosion;

    private void Awake()
    {
        instance = this;
    }

    public void MouseClickSesiYap()
    {
        
        {
            mouseclick.Play();

        }
    }

    public void EnemyexplosionSesiYap()
    {
        enemyexplosion.Play();
    }

    public void MeteorexplosionSesiYap()
    {
        meteorexplosion.Play();
    }

    public void PlayerexplosionSesiYap()
    {
        playerexplosion.Play(); 
    }
}
