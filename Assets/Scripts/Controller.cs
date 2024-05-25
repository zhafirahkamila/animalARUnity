using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [Header("Animal Description")]
    public TrackableAr[] tr;
    public string[] name;
    [TextArea]
    public string[] description;

    [Header("UI Description")]
    public Text txtName;
    public Text txtDescription;

    public GameObject goName;
    public GameObject goDescription;
    public GameObject markerText;

    public bool[] checkMarker;
    int countMarker;

    // Start is called before the first frame update
    void Start()
    {
        checkMarker = new bool[tr.Length];
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<tr.Length; i++)
        {
            if (tr[i].GetMarker())
            {
                txtName.text = name[i];
                txtDescription.text = description[i];

                if (!checkMarker[i])
                {
                    countMarker++;
                    checkMarker[i] = true;
                }
            }
            else
            {
                if (checkMarker[i])
                {
                    countMarker--;
                    checkMarker[i] = false;
                }
            }
        }
        DescriptionPanel();
    }

    private void DescriptionPanel()
    {
        if(countMarker == 0)
        {
            goName.SetActive(false);
            goDescription.SetActive(false);

            markerText.SetActive(true);
        }
        else
        {
            goName.SetActive(true);
            goDescription.SetActive(true);

            markerText.SetActive(false);
        }
    }
}
