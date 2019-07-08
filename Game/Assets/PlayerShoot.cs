using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] float weaponSpeed;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(Bullet);
            bullet. GetComponent<Bullet>().dirVector = (new Vector2)
        }
	}
}
