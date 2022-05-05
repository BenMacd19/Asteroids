using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    [SerializeField] Transform livesScore;
    [SerializeField] CanvasGroup background;
    [SerializeField] Transform gameOverScreen;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI achievements;

    private void OnEnable() {
        livesScore.gameObject.SetActive(false);

        background.alpha = 0;
        background.LeanAlpha(1, 3f);

        gameOverScreen.localPosition = new Vector2(0, + Screen.height);
        gameOverScreen.LeanMoveLocalY(0, 1f).setEaseOutExpo().delay = 1f;

        UserData data = SaveSystem.LoadUser(MainMenu.currentUser);

        nameText.text = data.name;
        scoreText.text = "Score - " + GameManager.Instance.score.ToString();

        achievements.text = "Achievements - " + AchievementManager.Instance.numAchievements.ToString();

        if (GameManager.Instance.score > data.highScore) {
            highScoreText.text = "New High Score! - " + GameManager.Instance.score.ToString();
            SaveSystem.SaveUser(data.name, GameManager.Instance.score, 
                                    AchievementManager.Instance.numAchievements);
        } else {
            highScoreText.text = "High Score - " + data.highScore.ToString();
            SaveSystem.SaveUser(data.name, data.highScore, AchievementManager.Instance.numAchievements);
        }
        
    }

    public void PlayAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
