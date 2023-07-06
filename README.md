# SpaceInvaders
Repository for Space Invaders arcade game I made during Tech Academy bootcamp Live Project.

## Invaders Screens
First thing I did for this game was creating a basic set of scenes: menu, gameplay and restart scenes. Transition between scenes is smooth because of prefab of SceneLoader, provided by Tech Academy instructors.

Example of smooth transition between scenes:

![](https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExeTViNXc1N3RnOGN6ZDI2YzFxMWFzbjdtcHI5c3RoOHpwanFtbHd6NSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/63Y50MxMdYLASjg9nR/giphy.gif)

## Player behavior
Player's movement is controlled by arrow keys or WASD. Game allows player to move on X and Y axles. Movement implemented using the Unity physics engine. In order to recreate weightlessness, the player is constantly affected by a lifting force that neutralizes gravity.
Another option of player's behaviour is shooting: by pressing "space" player shoots one missile. Cooldown for shooting is also implemented, so player cannot shoot multiple missiles at same time. 

Example of player movement along different axles:

![](https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExZ2ViaDl6NWJrdXhmbjB5MGVyeTRyNDF4MGc1a2gzM3hhcmF5bm8yNSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/KmfgHfnGu6xlRJ9Lhr/giphy.gif)

## Enemies
There are constantly no more than 3 enemies at the game (limitation is made with Unity Engine tags). Enemies have two behaviors: they constantly move and spawn a projectiles using InvokeRepeating method from UnityEngine.

Example of a new enemy appearing after the player has killed the previous one. The spawn point of a new enemy is randomly selected between 1 of 3 possible spawn points:

![](https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExOTRvcWNzdnk1d255N3ZxZWE4aDBtMHlidGhwOHNwN3ZoYWxta2R6dyZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/L2PoBIMxN1egQ92oXr/giphy.gif)


## Score system
I also implemented a scoring system in the game: a killed enemy increases the player's score by 1. The score is displayed in a text object and is updated after each killed enemy using the UnityEngine.UI methods. In the current build, one of the requirements to win the game is to reach 20 points.

Example of a player getting 2 points for killing two enemies:

![](https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExMm4zdTRmejIwZXcwcHAwbmVvZDAxcnNoZmkyZGJkbGs0bDgzMWZpeCZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/OLMhcHMGyKL07Ra6BD/giphy.gif)

## Boss
After killing 20 enemies (the number can be changed in the next levels), a boss appears. Defeating the boss is the second requirement to win the game.
The boss behavior class inherits the enemy behavior class. The boss implements the same movement behavior as a normal enemy, but has the following differences:
- The boss uses the MultipleShoot skill, which creates 3 projectiles at the same time instead of one for usual enemies;
- The boss has a HP system: 20 HP at the beginning, each collision with the player's rocket reduces his HP by 1. The boss dies when his HP becomes 0. The boss's HP is displayed in a text object and updated by UnityEngine.UI methods;
- Usual enemies spawn projectiles every 2 seconds, the boss spawns his projectiles in a random time range from 2 to 4 seconds using the Random.Range method.

Example of a boss spawning after the player has scored 20 points (in this particular example, the player got 21 points before the boss spawns because there must be no normal enemies in the game to spawn the boss):

![](https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExanE5ZTFvdjZ3OTV0ZTBqdndpZzQ1cGE5dmRjcDN0MHZ5OTI1bDNqZiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/E2ZvILuQHpt8TMfROq/giphy.gif)

## Player lifes  
At the start of the game, the player has 3 lives. Each collision with enemy projectiles reduces the number of lives by one. If the player has 0 life, the game ends and a restart screen is displayed.

Example of a player restart screen after losing their last life:

![](https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExeDdvdDkwdjhkem9jZjBoODM2NmR6cDdkamJ2MTlhOWdtOWEyemJ6ZSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/YAq9BoURuCpDvnzOvH/giphy.gif)

## Collisions
In my game, I implemented several types of collisions with different consequences:
- Collision of the player's missile and the enemy: both the missile and the enemy are destroyed. When the boss collides with a rocket, the rocket is destroyed, the boss's HP decreases.
- Collision of the player's missile with an obstacle: only the missile is destroyed.
- Collision between an enemy projectile and the player: the projectile is destroyed, the player's hit points are reduced by one.
- Collision between enemy projectile and player's missile: both projectile and missile are destroyed.

Example of collisions between missile and projectile, missile and enemy, projectile and player:

![](https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExcmtkOWhoaGNvYWE0emJjczlocjBuN3YyNG0wdDF0MGFzb3F0czY4ciZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/A6mlfuLrhXxACNsoBz/giphy.gif)
