using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LevelSelector : MonoBehaviour{

    Button[] levelButtons;
    GameObject content;

    int levelReached;

    void Start()
    {
        content = GameObject.Find("Content");
        levelButtons = new Button[content.transform.childCount];

        if (PlayerPrefs.HasKey("levelReached"))
        {
            levelReached = PlayerPrefs.GetInt("levelReached");
        }
        else
        {
            levelReached = 1;
            PlayerPrefs.SetInt("levelReached", 1);
        }

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i] = content.transform.GetChild(i).GetComponentInChildren<Button>();
        }

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void Select(Text levelNumber)
    {
        SceneManager.LoadScene(int.Parse(levelNumber.text.ToString()));
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
