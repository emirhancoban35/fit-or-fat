using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeight : MonoBehaviour
{
    public CharacterWeight character;
    public GameObject puny, fat, obese;
    public float KG;

    private void Update()
    {
        if (KG == 0f)
        {
            puny.SetActive(true);
            fat.SetActive(false);
            obese.SetActive(false);
        }
        if (KG == 100f)
        {
            puny.SetActive(false);
            fat.SetActive(true);
            obese.SetActive(false);
        }
        if (KG == 200f)
        {
            puny.SetActive(false);
            fat.SetActive(false);
            obese.SetActive(true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Burger")
        {
            Destroy(other.gameObject);
            KG += 50f;
        }
        if (other.gameObject.tag == "Brokoli")
        {
            Destroy(other.gameObject);
            KG -= 50f;
        }
    }
}
