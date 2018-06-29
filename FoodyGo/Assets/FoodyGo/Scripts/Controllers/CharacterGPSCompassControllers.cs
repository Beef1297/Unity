using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGPSCompassControllers : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Input.compass.enabled = true;

	}
	
	// Update is called once per frame
	void Update () {
        //オブジェクトを磁北に向けて、反転しているマップの向きに合わせる
        var heading = 180 + Input.compass.magneticHeading;

        var rotation = Quaternion.AngleAxis(heading, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, t: Time.fixedTime * .001f);
        // t: は無くても大丈夫, 逆にこのtなんですか??
	}
}
