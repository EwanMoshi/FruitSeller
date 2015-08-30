using UnityEngine;

public class InteractiveLight : InteractiveBehaviour {

	public Light[] lights;

	public override void exec () {
		for (int i = 0; i < lights.Length; i++) {
			lights[i].enabled = !lights[i].enabled;
		}
	}

}