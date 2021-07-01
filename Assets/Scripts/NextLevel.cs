using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NextLevel : MonoBehaviour {

    public GameObject endUI;
    public Text score;
    public Text highscore;
    public Text time;
    public Text levelComplete;
    public GameObject gameComplete;
    public GameObject nextLevel;

    int completedLevel;

    void Start()
    {
        completedLevel = SceneManager.GetActiveScene().buildIndex;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            float finalTime = GameObject.Find("GameMaster").GetComponent<Timer>().time;

            if (PlayerPrefs.HasKey(completedLevel + "Highscore"))
            {
                if (PlayerPrefs.GetFloat(completedLevel + "Highscore") > finalTime)
                {
                    PlayerPrefs.SetFloat(completedLevel + "Highscore", finalTime);
                }
            }
            else
            {
                PlayerPrefs.SetFloat(completedLevel + "Highscore", finalTime);
            }

            time.enabled = false;

            Time.timeScale = 0f;
            endUI.SetActive(true);
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 2)
            {
                nextLevel.SetActive(false);
                gameComplete.SetActive(true);
            }
            levelComplete.text = "LEVEL " + completedLevel + " COMPLETE";
            score.text = "Time: " + finalTime.ToString("f2");
            highscore.text = "Best Time: " + PlayerPrefs.GetFloat(completedLevel + "Highscore").ToString("f2");
            Cursor.lockState = CursorLockMode.None;

            if (PlayerPrefs.GetInt("levelReached") == completedLevel)
            {
                PlayerPrefs.SetInt("levelReached", completedLevel + 1);
            }
        }
	}

    public void RetryFromEnd()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToNextLevel()
    {
        SceneManager.LoadScene(completedLevel + 1);
    }
}
