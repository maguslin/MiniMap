using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour {

    public float Speed = 4.0f;
    public float TimeTmp = 0f;
    private float directionX = 0f;
    private float directionZ = 0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TimeTmp += Time.deltaTime;
        if (TimeTmp >= 3.0f)
        {
            directionX = Random.Range(-1f, 1f);
            directionZ = Random.Range(-1f, 1f);
            TimeTmp = 0f;
        }
        transform.Translate(new Vector3(directionX, 0, directionZ) * Speed * Time.deltaTime);

    }
}
