# XOX_2D
2D Tic Tac Toe in Unity.

It is my first attempt on making a game. I have choosen easy and already highly processed topic to easily find any required solution for ongoing problem. I don't follow any sort of full-length tutorials as I wanted to came up with my own solutions and ideas - I rely on single topic tutorials that I will attach links for, later. I usually dedicate about 1-2 hours a day, due to my current job and university's duties.
<!---
Markdown:
> [Journal](https://github.com/Hiroten31/XOX_2D/edit/main/README.md#journal)

> [How it works?](https://github.com/Hiroten31/XOX_2D/edit/main/README.md#how-it-works)

> [Screenshots](https://github.com/Hiroten31/XOX_2D/edit/main/README.md#screenshots)

> [What I have learned](https://github.com/Hiroten31/XOX_2D/edit/main/README.md#what-i-have-learned)
--->
# Logbook
It is a simple project to gradually get into world of game development. So far so good. My journey until now:

<details>
  <summary><h2>The Journey :book:</h2></summary>
<details>
  <summary><h2>First week :student:</h2></summary>

```
- Creating a project
- Adding a background
- Making first C# script to change sprite and properties of the background on key click
- Finding out good enough assets to use in the future
- Deciding on the methods to use
```
</links>
</details>

<details>
  <summary><h2>Second week :abacus:</h2></summary>

```
- Fighting with proper placement of the planet
- Trying out different methods and making them move using Update() function and math's sin() and cos()
- Figuring out how to calculate right angle to spawn planet outside of vidible area (Acos()) - very nerve breaking
- Testing if they are working well
- First attempts of grid generation
```
</links>
</details>

<details>
  <summary><h2>Third week :arrow_forward:</h2></summary>

```
- Adding buttons to make menu for players
- Trying out to use global variables for settings
- Implementing GameManager, slider to set-up grid size
- Upgrading grid generator and tile actions as placing X's and O's
```
</links>
</details>

<details>
  <summary><h2>Fourth week :brain:</h2></summary>

```
- A little break due to easter 🐣 holidays!
- Slowly implementing logic to check if placing X or O was a winning move for a player
- Considered refactoring GridManager to static class for better practice (like in GameManager)
```
</details>

<details>
  <summary><h2>Fifth week :medal_sports:</h2></summary>

```
- Did full logic behing checking if player is making a winning move.
  Checking line horizontally, vertically and for both diagonals. (not optimalized)
- Researched about solutions I want to use to properly scale and position the grid
- Realized how much code I have to refactor and had a little break(down)...
```
</details>

<details>
  <summary><h2>Sixth week :video_game:</h2></summary>

```
- Refactor offset with a lot of math checking, apparently for nothing as relative position won't need that
- Added proper grid positioning (to the right side) and scaling with number of tiles
- Added a text box, buttons and diplays for proper and clear game control
```
</details>

<details>
  <summary><h2>Seventh week :sweat_smile:</h2></summary>

```
- Got pretty sick so I did a little break to play some games ❤️‍🔥
- Rethinked developer-side design, how to organize reloading game, quitting, draws etc.
```
</details>

<details>
  <summary><h2>Eigth week :speech_balloon:</h2></summary>

```
- Added textBoxManager
- Reformed and added usage of textBox to properly display needed text
- Working a little around StopGame()
```
</details>

<details>
  <summary><h2>Ninth week :plate_with_cutlery:</h2></summary>

```
- Fixed textBoxManager bug, where first letter would dissapear
- Added MoveDisplay to inform player about which player is on the move
- Set new menu which appears on the middle of screen after game has been settled
- Added GameState and gameWinner to keep the track of state of the game winner
```
</details>

<details>
  <summary><h2>Tenth week :house:</h2></summary>

```
- Done first build - had to fix some hidden errors
- Trying to make FadeIn and FadeOut on textures (multiple SpriteRenderers problem)
- And some student's parties
```
</details>
</details>
<details>
  <summary><h2>The END :stop_sign:</h2></summary>


Overall summary:
- I have created my first, quite simple and easy game. <h6>I have mostly focus on getting to know the Unity's engine and environment - also basic procedures and program functions that exist in GameDev IDEs.</h6>
- I especially haven't follow any particular guide to create it. <h6>I have used different videos and approaches to better implent different components into one game. That helped a lot in planning how to make new stuff versitile enough to be used in many cases - but also slowed the process by a lot. </h6>
- I didn't really completed the game as I wanted. <h6>Due to almost 2 months long break caused by studies, exams, different projects and holidays :)
That's why I am ending this project for now, leaving it in a state of working Tic-Tac-Toe game with few minor flaws and unfinished, creative outburts of improvements I wanted to implement.</h6>
</details>

# How it works?
Links to resources and videos that has helped me:
> https://deep-fold.itch.io/space-background-generator
> 
> https://helianthus-games.itch.io/pixel-art-planets
> 
> https://www.youtube.com/watch?v=kkAjpQAM-jE
> 
> https://www.youtube.com/watch?v=4I0vonyqMi8
> 
> https://www.youtube.com/watch?v=nTLgzvklgU8

# Screenshots 
<details>
  <summary>(in work)</summary>

<details>
  <summary>(old work)</summary>

### Gameplay scene set-up
![image](https://github.com/Hiroten31/XOX_2D/assets/97809912/a2667ce4-c611-4609-b832-96b7e6b8cb65)

### Main menu 
![image](https://github.com/Hiroten31/XOX_2D/assets/97809912/a90e5851-d197-4eb5-ba7a-18556bdcbf2b)

### Settings menu
![image](https://github.com/Hiroten31/XOX_2D/assets/97809912/23bb020a-f41f-42be-bf88-25cebae34b22)

### Grid generation
![image](https://github.com/Hiroten31/XOX_2D/assets/97809912/f006a818-5499-431a-866d-39817281ca76)

### Example of gameplay (sprite placeholders)
![image](https://github.com/Hiroten31/XOX_2D/assets/97809912/44e262b6-bc15-4841-a472-debd7a17d3e4)

</details>

<details>
  <summary>(new work)</summary>

### Gameplay scene set-up
![image](https://github.com/Hiroten31/XOX_2D/assets/97809912/f4ee3562-6718-4b3b-9eda-c327ef0c21f9)

### Settings menu
![image](https://github.com/Hiroten31/XOX_2D/assets/97809912/c6baccaf-1a6f-4302-b0e1-fee1c03370bb)

### Grid generation
![image](https://github.com/Hiroten31/XOX_2D/assets/97809912/d8a9671d-8091-4a5d-81e9-ce736eb62833)

### Example of gameplay (sprite placeholders)
![image](https://github.com/Hiroten31/XOX_2D/assets/97809912/8e0d19f3-0a47-41ec-8e6e-dbc19d7cafd8)

</details>

</details>

# What I have learned?
- To properly connect version control next time...
