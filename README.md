# VoxelLand
Simple multiplayer voxel game base made in Unity.
For now it implements most features of the classic version of well-known voxel sandbox. And little more.

This is an educational project, the main goal of the project is to study the development principles of multiplayer games.

## Main Features:
- Infinite (at least, not limited) terrain size
- Simple procedural landscape generator based on perlin noise
- Full multiplayer support. Even singleplayer mode is multiplayer session with local server. Headless server mode is supported.
- Multithreading support. Server, Disk I/O, landscape generator, voxel mesher, database are running in separate threads. 
- Server not dependent on any of Unity code, except of some basic types (Vector3, Quaternion for example) and math functions. I was able to run standalone version of the server on Raspberry Pi Zero W. 
- Does not use Unity colliders for physics
- Every block can be painted in any color in 16-bit palette
- Data saved on local database (LiteDB)
- Basic entity support

## Controls:
- WASD, Spacebar - Movement
- Shift (hold) - Sprint
- Left mouse click - remove block
- Right mouse click - place block
- F1 - lock/unlock mouse cursor. (useful in Unity Editor)
- B - Block list window. Click to add block from list to your hotbar
- P - Palette window. Use it to choose in which color you will be painting blocks
- N - Launch block from hotbar to the air
- Shift + Left mouse button - paint block (you have to choose color from palette prior to painting)
- Shift + Right mouse button - interact with block (switch on and off lamps for example)
- / (Right slash) - open chat window. Type in /help to list of available commands (some commands are OP only and not shown for regular players)