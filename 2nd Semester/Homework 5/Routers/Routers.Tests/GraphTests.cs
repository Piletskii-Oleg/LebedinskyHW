namespace Routers.Tests;

using System;
using Routers;
using NUnit.Framework;
using Routers.Exceptions;

public class GraphTests
{
    [Test]
    public void ExceptionShouldBeThrownWhenGraphIsNotConnected()
    {
        var path = "../../../TestFiles/disconnected.txt";
        Assert.Throws<GraphNotConnectedException>(() => RoutersUtility.MakeConfiguration(path, path + ".txt"));
    }

    [Test]
    public void ExceptionShouldBeThrownWhenInputIsIncorrect()
    {
        var path = "../../../TestFiles/incorrectInput.txt";
        Assert.Throws<ArgumentException>(() => RoutersUtility.MakeConfiguration(path, path + ".txt"));
    }

    [Test]
    public void TreeShouldBeMinimal()
    {
        string path = "../../../TestFiles/graph.txt";
        var tree = Graph.MakeMinimalTree(path);
        Assert.Multiple(() =>
        {
            Assert.AreEqual(3, tree.Edges.Count);
            Assert.AreEqual(20, tree.Edges[0].Capacity);
            Assert.AreEqual(15, tree.Edges[1].Capacity);
            Assert.AreEqual(10, tree.Edges[2].Capacity);
        });
    }
}