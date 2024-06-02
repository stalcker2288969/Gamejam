using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ROOT : MonoBehaviour
{
    [SerializeField] bool start = false;
    [SerializeField] float time;
    [SerializeField] bool end = false;
    public float Patience;
    [SerializeField] TMP_Text TimeText;
    [SerializeField] TMP_Text ParienceText;
    [SerializeField] GameObject Podskazka;
    [SerializeField] GameObject Timer;
    [SerializeField] GameObject PressFToStart;
    [SerializeField] GameObject PressRToResstart;
    [SerializeField] GameObject PatienceTXT;
    [SerializeField] GameObject StartObjects;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(start == false)
        {
            PressFToStart.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F))
            {
                start = true;
            }
        }
        else
        {
            StartObjects.SetActive(true);
            Podskazka.SetActive(false);
            PressFToStart.SetActive(false);
            Timer.SetActive(true);
            PatienceTXT.SetActive(true);
            if (end == false) 
            {
                time += Time.deltaTime;
                TimeText.text = Mathf.Round(time).ToString();
                ParienceText.text = Mathf.Round(Patience).ToString();
                if(Patience > 0)
                Patience -= Time.deltaTime;
                if (Patience > 99.9f)
                {
                    end = true;
                }
            }
            else
            {
                PressRToResstart.SetActive(true);
                if(Input.GetKeyDown(KeyCode.R))
                {
                   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }

}
