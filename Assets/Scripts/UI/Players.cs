using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    [SerializeField] Transform players;

    public void OnEnable() {
        players.localPosition = new Vector2(0, +Screen.height);
        players.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.5f;
    }

    public void Close() {
        players.LeanMoveLocalY(+Screen.height, 0.5f).setEaseInExpo().setOnComplete(OnComplete);
    }

    void OnComplete() {
        gameObject.SetActive(false);
    }
}
