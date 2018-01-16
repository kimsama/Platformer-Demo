using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public NumberRenderer numberRenderer;

    public int numStar;

    public void Start()
    {
        numStar = 0;
        numberRenderer.RenderNumber(numStar);
    }

    // 충돌을 검사
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "star")
        {
            other.gameObject.SetActive(false); 
            numStar += 1;
            numberRenderer.RenderNumber(numStar);
        }
    }

}
