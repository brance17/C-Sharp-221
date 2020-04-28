Step 1: Create input prompt for player. 
What tower do they want to move from, which tower do they want to move to.
Towers will be represented by "A", "B", and "C".

Step 2: Use Stack<int> stack = new Stack<int>() to assemble game board and pieces.
3 pegs w/ 4 items to move, stacked in descending order. 
With a win being all of the pieces on line C.

Step 3: 

Step 4: Create a bool to determine if player has won.
If the count on "C" = 4, player wins.

Step 5: Create a bool to determine if a move is legal or not.
If number is > than piece in front, move will be invalid.