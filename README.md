# CISC374-BirdTutorial
This is a tutorial project used to overview Unity3D in CISC374.

## ChatGPT assisted README FILE.

# Flappy Bird Clone - Unity Project

## Overview
This is a **Flappy Bird Clone** created for a university assignment using **Unity**. The player controls a bird that must avoid obstacles by flapping through gaps in moving pipes.

## Features
- **Flapping Mechanic**: Press Spacebar to make the bird jump.
- **Pipes Spawning**: Randomly generated pipes move from right to left.
- **Collision Detection**: The game ends when the bird hits a pipe or falls off-screen.
- **Score System**: Score increases when passing through pipes.
- **High Score Tracking**: Uses `PlayerPrefs` to save and display the highest score.
- **Title Screen**: Game starts after clicking "Start".
- **Game Over Screen**: Displays the score and allows restarting.
- **Sound Effects & Music**: Includes flap, collision, score sounds, and background music.

## Controls
- **Spacebar**: Flap the bird.
- **Mouse Click**: Start the game.
- **R**: Restart the game.

## How to Play
1. Click the **Start Button** to begin.
2. Press **Spacebar** to flap the bird.
3. Avoid hitting the pipes or falling off-screen.
4. Pass through pipe gaps to **increase your score**.
5. If the game ends, click **Restart** to play again.

## Setup Instructions
1. Open the project in **Unity 2021.3 or later**.
2. Attach scripts (`BirdScript.cs`, `LogicScript.cs`, `pipeMoveScript.cs`, `pipeSpawnerScript.cs`, `MusicManager.cs`) to their respective GameObjects.
3. Assign UI elements (Title Screen, Game Over Screen, High Score Text) in the Inspector.
4. Press **Play** in Unity to start testing.

## Customization
- **Adjust Pipe Speed**: Modify `moveSpeed` in `pipeMoveScript.cs`.
- **Change Flap Strength**: Modify `flapStrength` in `BirdScript.cs`.
- **Reset High Score**: Use `PlayerPrefs.SetInt("HighScore", 0);` in `LogicScript.cs`.

## Credits
- Developed by: [Your Name]
- Audio & Art: Open-source / Custom

## License
For educational use only.

---
🎮 Happy Flapping!

