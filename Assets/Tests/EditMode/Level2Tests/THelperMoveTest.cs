using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class THelperMoveTest {
	[Test]
	public void Left() {
		TCellController controller = new TCellController();

		controller.SetDestination(1);
		controller.MoveLeft();

		Assert.AreEqual(-1, controller.GetDestination());
	}

	[Test]
	public void Right() {
		TCellController controller = new TCellController();

		controller.SetDestination(1);
		controller.MoveRight();

		Assert.AreEqual(1, controller.GetDestination());
	}

	[Test]
	public void LeftBoundsCheck() {
		TCellController controller = new TCellController();

		controller.SetDestination(1);

		controller.MoveLeft();
		controller.MoveLeft();
		controller.MoveLeft();

		Assert.AreEqual(-1, controller.GetDestination());
	}

	[Test]
	public void RightBoundsCheck() {
		TCellController controller = new TCellController();

		controller.SetDestination(1);

		controller.MoveRight();
		controller.MoveRight();
		controller.MoveRight();

		Assert.AreEqual(1, controller.GetDestination());
	}

	[Test]
	public void OriginTest() {
		TCellController controller = new TCellController();

		controller.SetDestination(1);

		controller.MoveLeft();
		controller.MoveRight();
		controller.MoveRight();
		controller.MoveLeft();

		Assert.AreEqual(0, controller.GetDestination());
	}
}
