using System.Collections;
using System.Collections.Generic;
// using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    [TestFixture]
    public class PlayerStatusTest
    {
        UIController uiController;
        GameManager gameManagerComponent;

        [SetUp]
        public void Init()
        {
            GameObject gameManagerObject = new GameObject();
            var camerMovementComponent = gameManagerObject.AddComponent<CameraMovement>();
            // gameManagerObject.AddComponent<InputManager>();
            uiController = gameManagerObject.AddComponent<UIController>();
            GameObject buttonBuildObject = new GameObject();
            GameObject cancelButtonObject = new GameObject();
            GameObject cancelPane = new GameObject();

            uiController.cancelActionBtn = cancelButtonObject.AddComponent<Button>();
            var buttonBuildComponent = buttonBuildObject.AddComponent<Button>();
            uiController.buildResidentialAreaBtn = buttonBuildComponent;
            uiController.cancelActionPanel = cancelButtonObject;

            uiController.buildingMenuPanel = cancelPane;
            uiController.openBuildMenuBtn = uiController.cancelActionBtn;
            uiController.demolishBtn = uiController.cancelActionBtn;

            gameManagerComponent = gameManagerObject.AddComponent<GameManager>();
            gameManagerComponent.cameraMovement = camerMovementComponent;
            gameManagerComponent.uiController = uiController;
        }


        [UnityTest]
        public IEnumerator PlayerStatusPlayerBuildingSingleStructureStateTestWithEnumeratorPasses()
        {
            yield return new WaitForEndOfFrame(); //awake
            yield return new WaitForEndOfFrame(); //start
            uiController.buildResidentialAreaBtn.onClick.Invoke();
            yield return new WaitForEndOfFrame();
            Assert.IsTrue(gameManagerComponent.State is PlayerBuildingSingleStructureState);

        }

        [UnityTest]
        public IEnumerator PlayerStatusPlayerSelectionStateTestWithEnumeratorPasses()
        {
            yield return new WaitForEndOfFrame(); //awake
            yield return new WaitForEndOfFrame(); //start
            Assert.IsTrue(gameManagerComponent.State is PlayerSelectionState);

        }
    }
}