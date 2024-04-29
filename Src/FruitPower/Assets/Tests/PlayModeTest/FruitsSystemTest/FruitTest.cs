using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using FruitSystem;
using System.Linq;

public class FruitTest
{
    [UnityTest]
    [Description("Test fruit and fruit pooler system instantiation")]
    public IEnumerator InstantiateFruitOfValidType_Instantiate_FruitInstantiated()
    {
        const string validTypeId = "TEST_FRUIT_TYPE_ID";
      
        (var fruits, var fruitParent, var idCounter, var fruitPooer) = PrepareFruitPooler(new FruitPoolData[]
        {
            new()
            {
                typeId = validTypeId,
                prefab = CreateFruitPrefab(validTypeId),
                poolSize = 1
            }
        });

        yield return null;

        //instanciation du fruit
        var fruit = fruitPooer.InstantiateFruit(validTypeId);
        fruit.Spawn();

        //assertions
        Assert.IsNotNull(fruit);
        Assert.AreEqual(validTypeId, fruit.TypeId);
        Assert.AreEqual(0, fruit.Id);
        Assert.AreEqual(1, idCounter);
        Assert.IsTrue(fruits.Contains(fruit));
        Assert.IsTrue(fruitParent.childCount > 0);
        Assert.IsNotNull(GameObject.FindObjectsOfType<Fruit>().ToList().Where(f => f.Id == 0).First());

        Assert.Pass("Fruit instantiated successfully");

        yield return null;
    }

    [UnityTest]
    [Description("Test that an exception is thrown when trying to instantiate a fruit of an invalid type")]
    public IEnumerator InstantiateFruitOfInvalidType_Instantiate_FruitInstantiated()
    {
        const string validTypeId = "TEST_FRUIT_TYPE_ID";
        const string invalidTypeId = "INVALID_FRUIT_TYPE_ID";

        (var fruits, var fruitParent, var idCounter, var fruitFactory) = PrepareFruitPooler(new FruitPoolData[]
        {
            new()
            {
                typeId = validTypeId,
                prefab = CreateFruitPrefab(invalidTypeId),
                poolSize = 1
            }
        });

        yield return null;

        //assertions
        Assert.Throws<FruitPooler.FruitTypeIdDoesNotExistException>(() => fruitFactory.InstantiateFruit(invalidTypeId));
        Assert.Pass("Fruit not instantiated successfully");

        yield return null;
    }

    private (List<Fruit> fruits, Transform parent, ulong idCounter, FruitPooler pooler) PrepareFruitPooler(FruitPoolData[] poolData)
    {
        var fruits = new List<Fruit>();
        var idCounter = 0ul;
        var parent = new GameObject("Fruits").transform;

        var factory = new FruitPooler(poolData, parent, (instantiate) =>
        {
            var fruit = instantiate(idCounter++);
            fruits.Add(fruit);
            return fruit;
        });

        return (fruits, parent, idCounter, factory);
    }
    private GameObject CreateFruitPrefab(string typeId)
    {
        var testPrefab = new GameObject("test", typeof(Fruit));
        var testFruit = testPrefab.GetComponent<Fruit>();
        testFruit.TypeId = typeId;

        return testPrefab;
    }
}
