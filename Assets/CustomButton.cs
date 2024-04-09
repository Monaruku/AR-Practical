using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomButton : MonoBehaviour
{
    public GameObject marsPopup;
    public GameObject earthPopup;
    public TMP_Text infoBox;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed primary button");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log("hit");
                Debug.Log(hit.transform.name + " : " + hit.transform.tag);

                if (hit.transform.tag == "mars")
                {
                    /*
                    Vector3 pos = hit.point;
                    pos.z += 0.25f;
                    pos.y += 0.25f;
                    Instantiate(marsPopup, pos, transform.rotation);
                    */
                    infoBox.text = "Mars \n Let's learn about it!";
                }

                if (hit.transform.tag == "earth")
                {
                    /*
                    Vector3 pos = hit.point;
                    pos.z += 0.25f;
                    pos.y += 0.25f;
                    Instantiate(earthPopup, pos, transform.rotation);
                    */
                    infoBox.text = "Earth \n Nice place!";
                }

                if (hit.transform.tag == "marsinfo")
                {
                    Destroy(hit.transform.gameObject);
                }

                if (hit.transform.tag == "earthinfo")
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}