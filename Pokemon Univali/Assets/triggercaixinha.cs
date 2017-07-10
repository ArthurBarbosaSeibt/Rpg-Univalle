using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggercaixinha : MonoBehaviour {

    public GameObject skillNapa;

    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);

            skillNapa.SetActive(true);
        }
    }

}
