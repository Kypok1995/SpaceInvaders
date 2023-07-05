# SpaceInvaders
Repository for Space Invaders arcade game I made during Tech Academy bootcamp Live Project.

## Invaders Screens
First thing I did for this game was creating a basic set of scenes: menu, gameplay and restart scenes. Transition between scenes is smooth because of prefab of SceneLoader, provided by Tech Academy instructors.

![](https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExeTViNXc1N3RnOGN6ZDI2YzFxMWFzbjdtcHI5c3RoOHpwanFtbHd6NSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/63Y50MxMdYLASjg9nR/giphy.gif)

## Player movement
Player is controlled by arrow keys or WASD. Game allows player to move on X and Y axis. Movement implemented using the Unity physics engine. In order to recreate weightlessness, the player is constantly affected by a lifting force that neutralizes gravity.

## Enemies
There are constantly no more than 3 enemies at the game (limitation is made with Unity Engine tags). Enemies have two behaviors: they constantly move and spawn a projectiles using InvokeRepeating method from UnityEngine.

## Score system
I also implemented score system in the game: killed enemy increase a players score by 1. Score is shown on text object and updated after each killed enemy, using a UnityEngine.UI methods. With current build, one of requirements to win a game is to hit 20 scores.

## Boss
After killing 20 enemies (amount can be changed in the future levels) boss is spawned. Defeating a boss is a second requirement to win a game.
Boss behavior class inherits enemy behavior class. Boss implements the same movement behavior as usual enemy, but have a following differences:
- Boss use a MultipleShoot skill, which spawn 3 projectiles at the same time instead of just one for usual enemies;
- Boss has HP system: 20 HP at the start, each collision with player's missile decrease his HP by 1. Boss dies once his HP goes to 0. Boss HP is shown at the text object and updates with UnityEngine.UI methods;
- Usual enemies spawn projectiles every 2 seconds, boss spawns his projectiles in random time range between 2 and 4 seconds, using Random.Range method.

## Player lifes  
Player have 3 lifes at the start of the game. Each collision with enemy projectiles decrease a life count by one. If player has 0 lifes, game is ended and restart screen is shown. 

## Collisions
In my game I implemented several types of collision with different consenquences:
- Collision between player's missile and enemy: both missile and enemy are destroyed. If it's collision between boss and missile, missile is destroyed, HP of the boss is decreased.
- Collision between player's missile and obstacle:  only missile is destroyed.
- Collision between enemy projectile and player: projectile is desctroyed, player's lifes are decreased by one.
- Collision between enemy projectile and player's missile: both projectile and missile are desctroyed.

