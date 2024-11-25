using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField] private List<Image> hearths = new List<Image>();

    public static UIController instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void UpdateHealthDisplay()
    //{

    //    int index = hearths.Count - 1;
    //    hearths.ForEach(h =>
    //    {
    //        if (!h.gameObject.active)
    //        {
    //            index--;
    //        }

    //    });
    //    hearths[index].gameObject.SetActive(false);

    //}

    public void UpdateHealthDisplay(int health,int maxHealth)
    {
        for(int i = 0; i < hearths.Count; i++)
        {
            hearths[i].enabled = true;

            if (health <= i) hearths[i].enabled = false;
        }
    }
}
