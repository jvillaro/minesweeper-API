# minesweeper-API
My implementation of the minesweeper game as an API

In my implementation I originally set out to create a solution composed of a Web API, a UWP or Xamarin Forms client and a shared project that contained the data models and other assets. Time constrains did not allow to start the client project, so I just kept to creating the Web API.

- In order to provide a path to persistence I intended to test first with EF in memory database (later could be changed) but came across a problem serializing when trying to save and didn’t have time to fix.

- I opted to create a board consisting of a matrix of BoardCell objects including some information like position, if it has a mine, adjacent mines count, and state. But when thinking about the algorithms I noticed I could optimize both board complexity and setup calculations. For example, instead of having a field for a cell indicating if it had a mine, I can just have an array of cell positions with mines.

- Because of this I had to adjust the “play” call to the API so that it included the board and not only the game ID.

- I did not have time to implement clearing adjacent cells.

- I did not have the time to finish the detection for when the board is cleared. But it does return if you *tripped” a mine.

- I added some fields to track time but could not implement the logic. Considering you can save and continue games I wanted to accumulate durations of the time dedicated to each game.

- For saving games and allowing multiple users I was going for a simple approach. Every time a new game was started it would be saved to the repository but when the user wanted to save the game, he could add his email address and optionally add a name to the game. When a user would want to load a previous game, he could enter his email and get the list of his saved games and select one to load. Unfortunately, I didn’t have the time to complete this.
