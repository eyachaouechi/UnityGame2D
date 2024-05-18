using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveSystem : MonoBehaviour
{
   public GameObject correctform;
   private bool moving= false ; 
   private float startPosX;
   private float startPosY;
   private Vector3 resetPosition;
   private bool finish;
   public  Canvas myCanvas; 
   void Start()
{
   resetPosition = this.transform.localPosition;
}
void Update() 
{ 
    if (finish==false){
if (moving){
    Vector3 mousePos;
    mousePos = Input.mousePosition;
    mousePos = Camera.main.ScreenToWorldPoint(mousePos);
    this.gameObject.transform.localPosition = new Vector3((mousePos.x - startPosX), mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
}
    }

}
private void OnMouseDown()
{
    if (Input.GetMouseButtonDown(0)){
    Vector3 mousePos;
    mousePos = Input.mousePosition;
    mousePos = Camera.main.ScreenToWorldPoint(mousePos);

 startPosX = (mousePos.x - this.transform.localPosition.x);
    startPosY = (mousePos.y - this.transform.localPosition.y);
    moving=true;
    }
}


private void OnMouseUp()
{
moving=false;

if (Mathf.Abs(this.transform.localPosition.x - correctform.transform.localPosition.x)<= 0.5f && Mathf.Abs(this.transform.localPosition.y - correctform.transform.localPosition.y)<= 0.5f){
   this.transform.position = new Vector3(correctform.transform.position.x,correctform.transform.position.y,correctform.transform.position.z);
    finish = true;
    GameObject.Find("PointHandler").GetComponent<WinScript>().AddPoints();
	 
}

else {
    this.transform.localPosition = new Vector3(resetPosition.x,resetPosition.y,resetPosition.z);
}


}
}



























