using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int gold;
    [SerializeField] private TextMeshProUGUI goldIndicator;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldIndicator.text = gold.ToString("0");
    }

    public void winGold(){
        gold += 1;
    }

}
