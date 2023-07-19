using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GridStructureTests
    {
        GridStructure structure;
        [OneTimeSetUp]
        public void init() {
            structure = new GridStructure(3, 100, 100);
        }

 #region GRID POSITION TESTS

        // A Test behaves as an ordinary method
        [Test]
        public void CalculateGridPositionPasses()
        {
            // Use the Assert class to test conditions
            //Arrange
            Vector3 position = new Vector3(0, 0, 0);
            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);
            //Assert
            Assert.AreEqual(Vector3.zero,returnPosition);
        }

        // A Test behaves as an ordinary method
        [Test]
        public void CalculateGridPositionFloatsPasses()
        {
            //Arrange
            Vector3 position = new Vector3(2.9f, 0, 2.9f);
            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);
            //Assert
            Assert.AreEqual(Vector3.zero,returnPosition);
        }

        // A failing one
        [Test]
        public void CalculateGridPositionFail()
        {
            //Arrange
            Vector3 position = new Vector3(3.1f, 0, 0);
            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);
            //Assert
            // Assert.AreEqual(Vector3.zero,returnPosition); // the failing one
            Assert.AreNotEqual(Vector3.zero,returnPosition); //the passing one
        }
    #endregion
    

      #region GridCellTests

        [Test] //place structure on 3,0,3 & see if taken
        public void PlaceStructure303AndCheckIsTakenPasses()
        {
            Vector3 position = new Vector3(3, 0, 3);
            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);
            GameObject testGameObject = new GameObject("TestGameObject");
            structure.PlaceStructureOnTheGrid(testGameObject, position);
            //Assert
            Assert.IsTrue(structure.IsCellTaken(position));
        }
        [Test] // check min & max pos (values out of bounds)
        public void PlaceStructureMINAndCheckIsTakenPasses()
        {
            Vector3 position = new Vector3(0, 0, 0); // min
            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);
            GameObject testGameObject = new GameObject("TestGameObject");
            structure.PlaceStructureOnTheGrid(testGameObject, position);
            //Assert
            Assert.IsTrue(structure.IsCellTaken(position));
        }
        [Test] //created a grid of 100*100 so check max
        public void PlaceStructureMAXAndCheckIsTakenPasses()
        {
            Vector3 position = new Vector3(297, 0, 297);
            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);
            GameObject testGameObject = new GameObject("TestGameObject");
            structure.PlaceStructureOnTheGrid(testGameObject, position);
            //Assert
            Assert.IsTrue(structure.IsCellTaken(position));
        }

        [Test] // what happens if null object arises
        public void PlaceStructure303AndCheckIsTakenNullObjectShouldFail()
        {
            Vector3 position = new Vector3(3, 0, 3);
            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);
            GameObject testGameObject = null;
            structure.PlaceStructureOnTheGrid(testGameObject, position);
            //Assert
            Assert.IsFalse(structure.IsCellTaken(position));
        }

        [Test] // exception to be thrown where the index is too great
        public void PlaceStructureAndCheckIsTakenIndexOutOfBoundsFail()
        {
            Vector3 position = new Vector3(303, 0, 303);
            //Act
            //Assert
            Assert.Throws<IndexOutOfRangeException>(()=>structure.IsCellTaken(position));
        }
        #endregion
  }
}
