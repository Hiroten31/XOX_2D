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
# Journal
It is a simple project to gradually get into world of game development. So far so good. My journey until now:
<details>
  <summary><h2>First week</h2></summary>

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
  <summary><h2>Second week</h2></summary>

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
  <summary><h2>Third week</h2></summary>

```
- Adding buttons to make menu for players
- Trying out to use global variables for settings
- Implementing GameManager, slider to set-up grid size
- Upgrading grid generator and tile actions as placing X's and O's
```
</links>
</details>

<details>
  <summary><h2>Fourth week</h2></summary>

```
- A little break due to easter 🐣 holidays!
- Slowly implementing logic to check if placing X or O was a winning move for a player
- Considered refactoring GridManager to static class for better practice (like in GameManager)
```
</details>

<details>
  <summary><h2>Fifth week</h2></summary>

```
- Did full logic behing checking if player is making a winning move.
  Checking line horizontally, vertically and for both diagonals. (not optimalized)
- Researched about solutions I want to use to properly scale and position the grid
- Realized how much code I have to refactor and had a little break(down)...
```
</details>

<details>
  <summary><h2>Sixth week</h2></summary>

```
- Refactor offset with a lot of math checking, apparently for nothing as relative position won't need that
```
</details>


# How it works?


# Screenshots 
<details>
  <summary>(in work)</summary>

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

# What I have learned?
- To properly connect version control...
