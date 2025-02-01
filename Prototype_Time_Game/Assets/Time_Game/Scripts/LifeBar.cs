using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    Image lifeBar;
    float life;

    private void Start()
    {
        lifeBar = GetComponent<Image>();
        life = GameManager.Instance.fullLife;
    }

    private void Update()
    {
        lifeBar.fillAmount = GameManager.Instance.currentLife / life;
    }
}
