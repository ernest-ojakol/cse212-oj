using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and dequeue them
    // Expected Result: Items are dequeued in order of highest priority (B, C, A)
    // Defect(s) Found: Dequeue loop skipped the last item, missing potential highest priority.
    public void TestPriorityQueue_EnqueueDequeueDifferentPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual("B", priorityQueue.Dequeue(), "Expected highest priority (5) item B");
        Assert.AreEqual("C", priorityQueue.Dequeue(), "Expected next highest priority (3) item C");
        Assert.AreEqual("A", priorityQueue.Dequeue(), "Expected last item A (2)");
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority and dequeue them
    // Expected Result: Items with same priority are dequeued in FIFO order (A, B, C)
    // Defect(s) Found: Dequeue used '>=', selecting the last item with highest priority instead of the first (violating FIFO).
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 5);

        Assert.AreEqual("A", priorityQueue.Dequeue(), "Expected first item A (FIFO)");
        Assert.AreEqual("B", priorityQueue.Dequeue(), "Expected second item B (FIFO)");
        Assert.AreEqual("C", priorityQueue.Dequeue(), "Expected third item C (FIFO)");
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: Throws InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None, correctly throws exception
    public void TestPriorityQueue_EmptyQueueThrowsException()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected InvalidOperationException for empty queue");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message, "Unexpected exception message");
        }
    }

    [TestMethod]
    // Scenario: Enqueue and dequeue a single item
    // Expected Result: The item is dequeued correctly (X)
    // Defect(s) Found: Item was not removed from queue after dequeue
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("X", 10);

        Assert.AreEqual("X", priorityQueue.Dequeue(), "Expected single item X");
    }

    [TestMethod]
    // Scenario: Enqueue items with mixed priorities, including negative, and dequeue
    // Expected Result: Items are dequeued by highest priority, FIFO for ties (B, C, D, A)
    // Defect(s) Found: Dequeue used '>=', selecting C over B for priority 5 (violating FIFO).
    public void TestPriorityQueue_NegativeAndMixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", -1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 5);
        priorityQueue.Enqueue("D", 0);

        Assert.AreEqual("B", priorityQueue.Dequeue(), "Expected B (5)");
        Assert.AreEqual("C", priorityQueue.Dequeue(), "Expected C (5, FIFO)");
        Assert.AreEqual("D", priorityQueue.Dequeue(), "Expected D (0)");
        Assert.AreEqual("A", priorityQueue.Dequeue(), "Expected A (-1)");
    }
}