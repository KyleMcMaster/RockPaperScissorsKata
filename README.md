# RockPaperScissorsKata

Starter for a kata exercise based on Rock Paper Scissors within the context of c# or typescript azure function http triggers.

## Use cases

Given the player submits rock\
When the opponent submits rock\
Then the result is a tie game

Given the player submits rock
When the opponent submits paper\
Then the result is a loss for the player

Given the player submits rock\
When the opponent submits scissors\
Then the result is a win for the player

Given the player submits paper\
When the opponent submits rock\
Then the result is a win for the player

Given the player submits paper\
When the opponent submits paper\
Then the result is a tie game

Given the player submits paper\
When the opponent submits scissors\
Then the result is a loss for the player

Given the player submits scissors\
When the opponent submits rock\
Then the result is a loss for the player

Given the player submits scissors\
When the opponent submits paper\
Then the result is a win for the player

Given the player submits scissors\
When the opponent submits scissors\
Then the result is a tie game

## System Design

Try building the use cases into an azure function http trigger or api endpoint that takes a player's move as input and produces the game's state as an output. The game's state should be represented with the player's move, the opponent's move, and the result of the round.

What patterns or refactoring can be applied?