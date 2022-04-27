using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{

    [SerializeField] Transform howToPlay;

    public void OnEnable() {
        howToPlay.localPosition = new Vector2(0, -Screen.height);
        howToPlay.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.5f;
    }

    public void Close() {
        howToPlay.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo().setOnComplete(OnComplete);
    }

    void OnComplete() {
        gameObject.SetActive(false);
    }

    
}
