# VoxelLand
Simple multiplayer voxel game base made in Unity.
For now it implements most features of the classic version of well-known voxel sandbox. And little more.

This is an educational project, the main goal of the project is to study the development principles of multiplayer games.

## Main Features:
- Infinite (at least, not limited) terrain size
- Simple procedural landscape generator based on perlin noise
- Full multiplayer support. Even singleplayer mode is multiplayer session with local server. Headless server mode is supported.
- Partial multithreading support. Disk I/O, landscape generator, voxel mesher are running in separate threads
- Does not use Unity colliders for physics
- Every block can be painted in any color in 16-bit palette
- Data saved on local database (LiteDB)
- Basic entity support