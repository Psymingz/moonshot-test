# moonshot-test
Test for parsing input.txt into a binary tree strcuture and finding the path with the largest possible sum, while honoring the odd-even-odd rule.

I initially assumed that nodes in a binary tree were only allowed a single parent node,
but I found that this assumption didn't resonate with task examples.
Hence I have added the "canHaveMultipleParents" bool as a parameter in the Parse method toggle this on and off.

I have implemented the solution as genericcally as possible, so other types can be used. The logic for determing how to traverse the tree and how to decide the optimal path can be changed using functions.