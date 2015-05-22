using UnityEngine;
using System.Collections;

abstract public class Observer : MonoBehaviour {

	abstract public void refresh();
	abstract public void setSubect(Subject sub);
}
