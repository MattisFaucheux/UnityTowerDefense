using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private TMPro.TMP_Text healthText;
    [Min(0)] [SerializeField] private float timeRestartGame = 4.0f;
    public static GameManager _instance { get; private set;}

    void Start()
    {
        if(!_instance)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        UpdateHealthText();
    }

    public void DecreaseLife()
    {
        playerHealth.DecreaseHealth();


        if (playerHealth.isDead())
        {
            healthText.text = "GAMEOVER";
            Time.timeScale = 0;
            StartCoroutine(RestartGame());
        }
        else
        {
            UpdateHealthText();
        }
    }

    private void UpdateHealthText()
    {
        healthText.text = "LIFE: " + playerHealth.GetHealth();
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(timeRestartGame);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
