using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    [SerializeField] Transform mainMenu;

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI achievementsText;

    [SerializeField] TextMeshProUGUI nameText1;
    [SerializeField] TextMeshProUGUI highScoreText1;
    [SerializeField] TextMeshProUGUI achievementsText1;

    [SerializeField] TextMeshProUGUI nameText2;
    [SerializeField] TextMeshProUGUI highScoreText2;
    [SerializeField] TextMeshProUGUI achievementsText2;


    public static bool player2;
    public Texture2D player2Cursor;

    public static string currentUser;

    private void Awake() {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); 
    }

    public void Start() {
        // SaveSystem.SaveUser("Ben", 7050, 3);
        // SaveSystem.SaveUser("Jack", 3000, 0);
        // SaveSystem.SaveUser("David", 0, 0);
        ShowUser();
    }

    public void PlayGame() {
        player2 = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayGame2player() {
        Cursor.SetCursor(player2Cursor, Vector2.zero, CursorMode.Auto); 
        player2 = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ShowUser() {
        UserData data = SaveSystem.LoadUser("Ben");
        nameText.text = data.name;
        highScoreText.text = "High Score - " + data.highScore.ToString();
        achievementsText.text = "Achievements - " + data.achievements.ToString();

        UserData data1 = SaveSystem.LoadUser("Jack");
        nameText1.text = data1.name;
        highScoreText1.text = "High Score - " + data1.highScore.ToString();
        achievementsText1.text = "Achievements - " + data1.achievements.ToString();

        UserData data2 = SaveSystem.LoadUser("David");
        nameText2.text = data2.name;
        highScoreText2.text = "High Score - " + data2.highScore.ToString();
        achievementsText2.text = "Achievements - " + data2.achievements.ToString();
    }

    public void User1() {
        currentUser = nameText.text;
    }

    public void User2() {
        currentUser = nameText1.text;
    }

    public void User3() {
        currentUser = nameText2.text;
    }

    public void MoveUp() {
        mainMenu.LeanMoveLocalY(+Screen.height, 0.5f).setEaseInExpo();
    }

    public void MoveCenter() {
        mainMenu.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.5f;
    }

    public void MoveDown() {
        mainMenu.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo();
    }

}
