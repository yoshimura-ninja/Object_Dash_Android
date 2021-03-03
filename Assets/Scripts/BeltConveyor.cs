using UnityEngine;
using System.Collections;
 
public class BeltConveyor : MonoBehaviour {
 
	//　ベルトコンベアーのスピード
	[SerializeField]
	private float speed = 1f;
 
	//　ベルトコンベアーの速度を返す
	public Vector3 ConveyorVelocity () {
		return transform.forward * speed;
	}
}
