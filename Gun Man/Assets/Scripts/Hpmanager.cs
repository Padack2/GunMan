using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hpmanager : MonoBehaviour
{

    public Image fillingImage;
    public float maxHealth;
    private float health;
    public Text percent;

    // Start is called before the first frame update
    void Start()
    {
        //fillingImage = GetComponentInChildren<Image>();
        health = 70f;

        updateHealthBar();
    }
    public bool ApplyDamage(float value)
    {
        health -= value;
        if(health>0)
        {
            updateHealthBar();
            return false;
        }

        health = 0;
        updateHealthBar();
        return true;
    }

    void updateHealthBar()
    {
        float percentage = health / maxHealth;
        
        percent.text = (100f*percentage).ToString()+"%";
        fillingImage.fillAmount = percentage;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
