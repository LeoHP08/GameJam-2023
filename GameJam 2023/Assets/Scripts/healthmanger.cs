using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class healthmanger : MonoBehaviour
{
    public int health;
    public TMP_Text healthText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "health: "+health;

    }
}