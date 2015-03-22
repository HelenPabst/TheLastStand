//notes to self: 
//Maybe do fade ins and outs.
//after some time add text saying 'click to skip'

using UnityEngine;
using System.Collections;

public class CutsceneCode : MonoBehaviour {
	//An array of plain images
	public Texture[] CutsceneImage;
	//Which image the sequence starts on.
	private int currentImage = 0;
	//The length of time each image stays up.
	public double imageTime = 6.0;
	//What time the next image displays.  Should start as the value in frameTime to allow the first image to display.
	private double nextImageTime;
	//Next scene to load
	public Object nextScene;

	void Start(){
		nextImageTime = imageTime;
	}
	void Update(){

		if(Input.GetMouseButtonDown(0)){
		//if (Time.time >= nextImageTime  ) { 
			if(currentImage==CutsceneImage.Length-1){
				Application.LoadLevel(nextScene.name);
			}
			else{
				currentImage++;
			}
			//nextImageTime += imageTime;     
		}

	}
	void OnGUI() {
		//If the use clicks during the cutscene, go to the next menu select.
		//if (Input.GetMouseButtonDown(0)) {

			//Application.LoadLevel(nextScene.name);
		//}
		//While currentImage points to a valid location, check the time.  If it is time for the next image, change
		//to the next image.  In either case, display the currnt image.
		//if (currentImage < CutsceneImage.Length) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), CutsceneImage [currentImage]); 
			//if(Input.GetMouseButtonDown(0)){
			//if (Time.time >= nextImageTime  ) {             
			//	currentImage++;             
				//nextImageTime += imageTime;     
			//}
		//} 
		//When all images are done, go to level select.
		//else {
			//Application.LoadLevel(nextScene.name);
		//}
	}
}
