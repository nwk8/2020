a) A deleted space in a hash table cannot be reused for subsequent insertions.

FALSE ✅


b) For any binary tree T, an infix traversal always outputs the values of T in sorted order.

FALSE ✅

Reason: Only Binary Search Trees (BSTs) guarantee that inorder (left-root-right) gives sorted output. A general binary tree doesn’t.

c) The number of null pointers in a binary tree is always one more than the number of nodes.

TRUE ✅

Reason: Each node has 2 pointers (left and right). A binary tree with n nodes has n+1 null pointers.

Quick proof: In a tree, number of edges = n - 1. Total pointers = 2n. Non-null pointers = n - 1 (edges). Null pointers = 2n - (n - 1) = n + 1.

d) The depth of a binary tree is equivalent to its height.

FALSE ❌

e) The minimum depth of a binary search tree is O(n/2).

FALSE ❌

Reason: Minimum depth occurs when the BST is perfectly balanced → minimum depth = O(log n), not O(n/2).

O(n/2) is meaningless asymptotically; minimum depth grows logarithmically.

f) The maximum depth of a binary search tree is only realized if elements are inserted in sorted order.

TRUE ✅

Reason: If you insert sorted elements into a BST, it degenerates into a linked list → maximum depth = n (worst-case).

Any other insertion order may produce smaller depth.

g) For each insertion, at most one rotation (single or double) is required to rebalance an AVL tree.

TRUE ✅

Reason: AVL trees guarantee that after insertion, only the lowest unbalanced ancestor may need rotation. One single or double rotation is sufficient to restore balance.

h) The maximum depth for both the AVL and red-black trees is O(log n).

TRUE ✅

Reason: Both A`VL and Red-Black trees are balanced binary search trees, so their height is always proportional to log(n).

## 4. 4(a) – Recursive Leaf Sum
Leaf node = a node with no left child AND no right child.pg 21

```code
public int LeafSum(Node n)
{
    // Base case 1: empty subtree
    if (n == null)
        return 0;

    // Base case 2: leaf node
    if (n.Left == null && n.Right == null)
        return n.Element;

    // Recursive case: sum of leaves in left + right subtrees
    return LeafSum(n.Left) + LeafSum(n.Right);
}

```