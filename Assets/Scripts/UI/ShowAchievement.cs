using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowAchievement : MonoBehaviour
{

    public static ShowAchievement Instance { get; private set; }

    [SerializeField] Transform achievement;
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TextMeshProUGUI descriptionText;

    void Awake() {
        Instance = this;
    }

    public IEnumerator SetUp(string title, string description) {
        titleText.text = title;
        descriptionText.text = description;

        achievement.localPosition = new Vector2(0, +Screen.height);
        achievement.LeanMoveLocalY(180f, 0.5f).setEaseOutExpo().delay = 0.5f;

        yield return new WaitForSeconds(5f);

        Close();
    }

    public void Close() {
        achievement.LeanMoveLocalY(+Screen.height, 0.5f).setEaseInExpo();
    }
}
