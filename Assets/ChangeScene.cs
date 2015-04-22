using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {
	
	public void Change_Scene (int SceneToGoTo) {
		Application.LoadLevel(Application.loadedLevel+1);
	}

}