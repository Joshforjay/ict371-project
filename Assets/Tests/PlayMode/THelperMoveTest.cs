using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class THelperMoveTest {
	[UnityTest]
	public IEnumerator Left() {
		var gameObject = new GameObject();
		var controller = gameObject.AddComponent<TCellController>();

		controller.SetDestination(1);
		controller.MoveLeft();

		yield return new WaitForSeconds(1f);

		Assert.AreEqual(-1, controller.transform.position.x);
	}

	[UnityTest]
	public IEnumerator Right() {
		var gameObject = new GameObject();
		var controller = gameObject.AddComponent<TCellController>();

		controller.SetDestination(1);
		controller.MoveRight();

		yield return new WaitForSeconds(1f);

		Assert.AreEqual(1, controller.transform.position.x);
	}
}
