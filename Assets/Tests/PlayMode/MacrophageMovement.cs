using ICTProject;
using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;

namespace Tests
{
    public class MacroDirectionTests : InputTestFixture
    {
        public GameObject playerPrefab;

        [UnityTest]
        public IEnumerator TurnLeft()
        {
            var input = InputSystem.AddDevice<Keyboard>();

            GameObject player = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Level1Assets/Prefab/Player");
            GameObject go = Object.Instantiate(player);
            float yRot = go.transform.rotation.y;
            Debug.Log(yRot);
            Press(input.aKey);

            yield return 1f;
            Debug.Log(go.transform.rotation.y);
            Assert.IsTrue(go.transform.rotation.y < yRot);
        }
    }
}
