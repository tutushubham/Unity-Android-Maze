using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipeTest : MonoBehaviour {

	public player swipeControls;
    public Transform Player;
    private Vector3 desiredPosition ;

	private void Start() {
        desiredPosition = Player.position;
    }

    private void Update() {


        if (swipeControls.SwipeLeft)
            {desiredPosition += 2.0f * Vector3.left;}
        if (swipeControls.SwipeRight)
            {desiredPosition += 2.0f * Vector3.right;}
		if (swipeControls.SwipeUp)
            {desiredPosition += 2.0f * Vector3.forward;}
		if (swipeControls.SwipeDown)
            {desiredPosition += 2.0f * Vector3.back;}

        Player.transform.position = Vector3.MoveTowards
            (Player.transform.position, desiredPosition,  5.0f*Time.deltaTime);

    }
}
