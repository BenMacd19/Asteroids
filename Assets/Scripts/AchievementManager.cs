using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance { get; private set; }

    public List<Achievement> achievements;
    public int numAchievements = 0;

    public bool tripleShoot = false;
    public bool boost = false;
    public bool shield = false;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        InitializeAchievements();
    }

    private void InitializeAchievements()
    {
        if (achievements != null) return;

        achievements = new List<Achievement>();

        // Score Achievements
        achievements.Add(new Achievement("Begginer", "Gain over 500 points in a single game", 
            (object o) => GameManager.Instance.score >= 500));
        achievements.Add(new Achievement("Rookie", "Gain over 5000 points in a single game", 
            (object o) => GameManager.Instance.score >= 5000));
        achievements.Add(new Achievement("Intermediate", "Gain over 10,000 points in a single game", 
            (object o) => GameManager.Instance.score >= 10000));
        achievements.Add(new Achievement("Proffesional", "Gain over 15,0000 points in a single game", 
            (object o) => GameManager.Instance.score >= 15000));
        achievements.Add(new Achievement("Master", "Gain over 20,0000 points in a single game", 
            (object o) => GameManager.Instance.score >= 20000));
        achievements.Add(new Achievement("Grand Master", "Gain over 25,0000 points in a single game", 
            (object o) => GameManager.Instance.score >= 25000));

        // Power Ups
        achievements.Add(new Achievement("Shooter", "Pickup the Triple-shoot power-up", 
            (object o) => tripleShoot == true));
        achievements.Add(new Achievement("Speedster", "Pickup the boost power-up", 
            (object o) => boost == true));
        achievements.Add(new Achievement("Protected", "Pickup the shield power-up", 
            (object o) => shield == true));
        achievements.Add(new Achievement("Scavenger", "Pickup all power-ups", 
            (object o) => tripleShoot&& boost && shield == true));
        
    }

    private void Update() {
        CheckAchievementCompletion();
    }

    private void CheckAchievementCompletion()
    {
        if (achievements == null) return;

        foreach (var achievement in achievements)
        {
            achievement.UpdateCompletion();
        }
    }
}
