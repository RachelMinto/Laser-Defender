using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Add for UI.
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    
    Text healthText;
    Player player;

    void Start()
    {
        healthText = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        healthText.text = player.GetHealth().ToString();
    }
}
