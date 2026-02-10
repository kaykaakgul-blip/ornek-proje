# Mario Jump (C# Beginner Game)

We made a **small C# game** together using **Windows Forms**.

## Game idea
- Mario stands between two walls.
- Press **Space** to jump.
- Random red obstacles come from the right wall.
- If Mario touches an obstacle, game over.
- The longer you survive, the higher your score.

## Project structure
- `MarioJumpGame/MarioJumpGame.csproj` - C# project file.
- `MarioJumpGame/Program.cs` - app entry point.
- `MarioJumpGame/MainForm.cs` - game logic (physics, obstacles, collision, score).
- `MarioJumpGame/MainForm.Designer.cs` - window and labels.

## What you need to run
Because this is WinForms, you need:
1. **Windows OS**
2. **.NET 8 SDK**

Check installation:
```bash
dotnet --version
```

If command is not found, install .NET 8 SDK from Microsoft first.

## How to run (step by step)
Open terminal in the repository root and run:

```bash
cd MarioJumpGame
dotnet run
```

## Controls
- **Space**: Jump
- **Space after game over**: Restart game

## Next learning steps (optional)
After you run this version, we can improve it together:
1. Add real Mario sprite image.
2. Add coins and power-ups.
3. Add start menu and pause button.
4. Save best score to a file.
