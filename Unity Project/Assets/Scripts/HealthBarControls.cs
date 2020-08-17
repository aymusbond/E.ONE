using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarControls : MonoBehaviour
{
    public Sprite[] healthLevels;
    int imageCount;
    public Image healthBar;

    bool hitFromEnemy;

    void Start()
    {
        imageCount = healthLevels.Length;
        healthBar = GetComponent<Image>();
        healthBar.sprite = healthLevels[imageCount - 1];
    }

    // Update is called once per frame
    void Update()
    {
        if (hitFromEnemy)
        {
            imageCount -= 1;
            healthBar.sprite = healthLevels[imageCount - 1];
        }
    }
}
