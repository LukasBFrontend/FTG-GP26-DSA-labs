# **02-stack-queue-representation** — questions
### Task 1 - Trace the abstractions before coding

For a stack, trace:

```text
Push A
Push B
Push C
Pop
Pop
```

For a queue, trace:

```text
Enqueue A
Enqueue B
Enqueue C
Dequeue
Dequeue
```

Write the values removed in order. Explain the difference in one sentence.

### Task 3 - Inspect the working `ListQueue<T>`

`ListQueue<T>` works correctly. It is deliberately straightforward rather than efficient.

Read its `Dequeue` implementation and answer:

#### Which element is removed?
#### What must `List<T>` do with the remaining elements afterwards?
#### If the queue contains 100,000 items, which operation may become expensive?

### Task 5 - Compare representations

Both `ListQueue<T>` and `RingQueue<T>` are queues. They expose the same important behavior but organize the data differently.

Answer:

#### 1. Why can `ListQueue<T>.Dequeue` require work proportional to the number of queued items?
#### 2. Why does `RingQueue<T>.Dequeue` avoid shifting the remaining items?
#### 3. What trade-off does the fixed-capacity ring queue make?
#### 4. Why is the *abstraction* "queue" different from the *representation* used to implement it?