using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIandSound : MonoBehaviour
{

    public TMP_Text infoBox;

    public AudioClip[] MarsClip;
    public AudioClip[] EarthClip;

    AudioSource audio;

    string UIState = "void"; //starting point
    int infoID = 1; //pointer to info text


    string marsText1 = "Mars, our closest neighbour and possibly humanities next home";
    string marsText2 = "Mars is also known as the Red Planet \n"
                        + "Mars is named after the Roman god of war\n";

    string marsText3 = "Mars is smaller than Earth with a diameter of 4217 miles";

    public string[] earthText;



    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//left mouse click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag == "Mars")
                {
                    UIState = "Mars";
                    infoID = 1;
                    infoBox.text = marsText1;
                    audio.PlayOneShot(MarsClip[0], 1f);
                }

                if (hit.transform.tag == "Earth")
                {
                    UIState = "Earth";
                    infoID = 1;
                    infoBox.text = earthText[0];
                    audio.PlayOneShot(EarthClip[0], 1f);
                }


                if (hit.transform.tag == "MarsInfo")
                {
                    Destroy(hit.transform.gameObject);
                    infoBox.text = "Select a Planet";
                    UIState = "void";

                }


                if (hit.transform.tag == "EarthInfo")
                {
                    Destroy(hit.transform.gameObject);
                    infoBox.text = "Select a Planet";
                    UIState = "void";

                }

            }
        }
    }

    public void nextButton()
    {
        if (audio.isPlaying)
        {
            audio.Stop();
        }

        if (UIState == "Mars")
        {
            switch (infoID)
            {
                case (1):
                    infoID = 2;
                    infoBox.text = marsText2;
                    audio.PlayOneShot(MarsClip[infoID - 1], 1f);
                    break;
                case (2):
                    infoID = 3;
                    infoBox.text = marsText3;
                    audio.PlayOneShot(MarsClip[infoID - 1], 1f);
                    break;
                default:
                    break;
            }
        }

        if (UIState == "Earth") // add for earth
        {
            switch (infoID)
            {
                case (1):
                    infoID = 2;
                    infoBox.text = earthText[infoID - 1];
                    audio.PlayOneShot(EarthClip[infoID - 1], 1f);
                    break;
                case (2):
                    infoID = 3;
                    infoBox.text = earthText[infoID - 1];
                    audio.PlayOneShot(EarthClip[infoID - 1], 1f);
                    break;
                default:
                    break;
            }
        }
    }
}