using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUser : MonoBehaviour
{
    [SerializeField] Transform selectUser;

    public void OnEnable() {
        selectUser.localPosition = new Vector2(0, +Screen.height);
        selectUser.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.5f;
    }

    public void Close() {
        selectUser.LeanMoveLocalY(+Screen.height, 0.5f).setEaseInExpo().setOnComplete(OnComplete);
    }

    void OnComplete() {
        gameObject.SetActive(false);
    }

}
