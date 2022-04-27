using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement
{
    public Achievement(string title, string description, Predicate<object> requirement)
    {
        this.title = title;
        this.description = description;
        this.requirement = requirement;
    }

    public string title;
    public string description;
    public Predicate<object> requirement;

    public bool achieved;

    public void UpdateCompletion()
    {
        if (achieved) return;
        
        if (RequirementsMet())
        {
            ShowAchievement.Instance.StartCoroutine(ShowAchievement.Instance.SetUp(title, description));
            achieved = true;
            AchievementManager.Instance.numAchievements += 1;
        }
        
    }

    public bool RequirementsMet()
    {
        return requirement.Invoke(null);
    }
}
