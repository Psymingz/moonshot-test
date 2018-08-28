# moonshot-test
Test for parsing input.txt into a binary tree structure and finding the path with the largest possible sum, while honoring the odd-even-odd rule.

I initially assumed that nodes in a binary tree were only allowed a single parent node,
but I found that this assumption didn't resonate with task examples.
Hence I have added the "canHaveMultipleParents" bool as a parameter in the Parse method to support both cases.

I have strived for making the solution as generically as possible, so other types can be used in the tree. 
The logic for determing how to traverse the tree and how to decide on the optimal path can also be changed using functions.

Please check the Output of the unit test for the result