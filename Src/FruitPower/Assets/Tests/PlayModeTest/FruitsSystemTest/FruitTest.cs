/*
 TPI - 2024
 FruitPower - Fruit Test
 Wihler Ruben
 */

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using FruitSystem;
using System.Linq;

/// <summary>
/// Tests unitaires pour les classes <see cref="FruitPooler"/>, <see cref="Fruit"/> et <see cref="FruitPoolData"/>.
/// </summary>
public class FruitTest
{
    [UnityTest]
    [Category("Fruit")]
    [Description("[id:01] Un fruit avec un type existant doit être instancié correctement par un FruitPooler")]
    public IEnumerator InstantiateFruitOfValidType_Instantiate_FruitInstantiated()
    {
        const string validTypeId = "TEST_FRUIT_TYPE_ID";
      
        (var fruits, var fruitParent, var idCounter, var fruitPooler) = PrepareFruitPooler(new FruitPoolData[]
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
        var fruit = fruitPooler.InstantiateFruit(validTypeId).Spawn();

        //assertions
        //le fruit est instancié
        Assert.IsNotNull(fruit);
        //le fruit est du bon type
        Assert.AreEqual(validTypeId, fruit.TypeId);
        //l'id du fruit est correct
        Assert.AreEqual(0, fruit.Id);
        //l'idCounter est incrémenté
        Assert.AreEqual(1, idCounter);
        //le fruit est ajouté à la liste des fruits
        Assert.IsTrue(fruits.Contains(fruit));
        //le fruit est ajouté à la hiérarchie en tant qu'enfant du parent des fruits
        Assert.IsTrue(fruitParent.childCount > 0);
        //le fruit est bien présent dans la scène
        Assert.IsNotNull(GameObject.FindObjectsOfType<Fruit>().ToList().Where(f => f.Id == 0).First());

        Assert.Pass("Fruit instancié avec succès");
        yield return null;
    }

    [UnityTest]
    [Description("[id:02] Une exception doit être levée si on essaie d'instancier un fruit avec un type inexistant")]
    public IEnumerator InstantiateFruitOfInvalidType_Instantiate_FruitInstantiated()
    {
        const string validTypeId = "TEST_FRUIT_TYPE_ID";
        const string invalidTypeId = "INVALID_FRUIT_TYPE_ID";

        (var fruits, var fruitParent, var idCounter, var fruitPooler) = PrepareFruitPooler(new FruitPoolData[]
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
        Assert.Throws<FruitPooler.FruitTypeIdDoesNotExistException>(() => fruitPooler.InstantiateFruit(invalidTypeId));
        Assert.Pass("Exception: FruitTypeIdDoesNotExistException levée avec succès");

        yield return null;
    }

    [UnityTest]
    [Category("Fruit")]
    [Description("[id:03] Le bon nombre de fruits (poolSize) doit être instanciés, désactivés et disponibles dans le pool lors de l'initialisation du FruitPooler")]
    public IEnumerator FruitPoolerInstantiatePoolSize_InitializeFruitPooler_PoolSizeNumberOfFruitsInstantiated()
    {
        const string validTypeId = "TEST_FRUIT_TYPE_ID";
        const string otherTypeId = "OTHER_FRUIT_TYPE_ID";
        const int poolSize = 5;

        (var fruits, var fruitParent, var idCounter, var fruitPooler) = PrepareFruitPooler(new FruitPoolData[]
        {
            new()
            {
                typeId = validTypeId,
                prefab = CreateFruitPrefab(validTypeId),
                poolSize = poolSize
            },
            new()
            {
                typeId = otherTypeId,
                prefab = CreateFruitPrefab(otherTypeId),
                poolSize = poolSize - 2
            }
        });

        yield return null;

        //assertions
        //La pool des fruits de type validTypeId contient le bon nombre de fruits
        Assert.AreEqual((poolSize * 2) - 2, fruits.Count);
        //Les fruits ne sont pas nuls
        Assert.IsTrue(fruits.All(f => f != null));
        //Les fruits sont du bon type
        Assert.IsTrue(fruits.All(f => f.TypeId == validTypeId || f.TypeId == otherTypeId));
        //Les fruits sont désactivés
        Assert.IsTrue(fruits.All(f => !f.gameObject.activeSelf));
        
        Assert.Pass($"{(poolSize*2)-2} Fruits instanciés avec succès");
        yield return null;
    }

    [UnityTest]
    [Category("Fruit")]
    [Description("[id:04] Un nouveau fruit doit être instancié si le pool est vide")]
    public IEnumerator InstantiateFruitWhenPoolIsEmpty_Instantiate_NewFruitCreated()
    {
        const string validTypeId = "TEST_FRUIT_TYPE_ID";
        const int poolSize = 5;

        (var fruits, var fruitParent, var idCounter, var fruitPooer) = PrepareFruitPooler(new FruitPoolData[]
        {
            new()
            {
                typeId = validTypeId,
                prefab = CreateFruitPrefab(validTypeId),
                poolSize = poolSize
            }
        });

        yield return null;

        while (fruits.Count < poolSize)
        {
            fruitPooer.InstantiateFruit(validTypeId).Spawn();
        }

        //instanciation du fruit
        var fruit = fruitPooer.InstantiateFruit(validTypeId);
        fruit.Spawn();

        //assertions
        //le fruit est instancié
        Assert.IsNotNull(fruit);
        //le fruit est du bon type
        Assert.AreEqual(validTypeId, fruit.TypeId);
        //l'id du fruit est correct
        Assert.AreEqual(0, fruit.Id);
        //le fruit est ajouté à la liste des fruits
        Assert.IsTrue(fruits.Contains(fruit));
        //le fruit est ajouté à la hiérarchie en tant qu'enfant du parent des fruits
        Assert.IsTrue(fruitParent.childCount > 0);
        //le fruit est bien présent dans la scène
        Assert.IsNotNull(GameObject.FindObjectsOfType<Fruit>().ToList().Where(f => f.Id == 0).First());

        Assert.Pass("Fruit instancié avec succès");
        yield return null;
    }

    [UnityTest]
    [Category("Fruit")]
    [Description("[id:05] Un fruit doit être remis dans le pool lorsqu'il est désactivé")]
    public IEnumerator FruitRepooledWhenDeactivated_DeactivateFruit_FruitInPool()
    {
        const string validTypeId = "TEST_FRUIT_TYPE_ID";

        (var fruits, _, _, var fruitPooer) = PrepareFruitPooler(new FruitPoolData[]
        {
            new()
            {
                typeId = validTypeId,
                prefab = CreateFruitPrefab(validTypeId),
                poolSize = 2
            }
        });

        yield return null;

        //instanciation du fruit
        var fruit1 = fruitPooer.InstantiateFruit(validTypeId).Spawn();
        var idFruit1 = fruit1.Id;
        //spawn d'un deuxième fruit
        fruitPooer.InstantiateFruit(validTypeId).Spawn();

        //désactivation du fruit 1
        fruit1.Despawn();

        var fruit3 = fruitPooer.InstantiateFruit(validTypeId).Spawn();
        var idFruit3 = fruit3.Id;

        //assertions
        //le fruit est instancié
        Assert.AreEqual(fruits.Count, 2);

        Assert.Pass("Fruit remis dans le pool avec succès");
        yield return null;
    }

    [UnityTest]
    [Category("Fruit")]
    [Description("[id:06] Les fruits doivent être réutilisés s'ils sont désactivés")]
    public IEnumerator ReuseDeactivatedFruit_Instantiate_FruitReused()
    {
        const string validTypeId = "TEST_FRUIT_TYPE_ID";

        (_, _, _, var fruitPooer) = PrepareFruitPooler(new FruitPoolData[]
        {
            new()
            {
                typeId = validTypeId,
                prefab = CreateFruitPrefab(validTypeId),
                poolSize = 2
            }
        });

        yield return null;

        //instanciation du fruit
        var fruit1 = fruitPooer.InstantiateFruit(validTypeId).Spawn();
        var idFruit1 = fruit1.Id;
        //spawn d'un deuxième fruit
        fruitPooer.InstantiateFruit(validTypeId).Spawn();

        //désactivation du fruit 1
        fruit1.Despawn();

        var fruit3 = fruitPooer.InstantiateFruit(validTypeId).Spawn();
        var idFruit3 = fruit3.Id;

        //assertions
        //le fruit est instancié
        Assert.AreEqual(idFruit1, idFruit3);

        Assert.Pass("Fruit remis dans le pool avec succès");
        yield return null;
    }

    #region Setup
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
    #endregion
}
