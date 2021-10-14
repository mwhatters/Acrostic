# Acrostic
A monogame top-down WIP puzzler

This is a small project I'm currently working on, started on October 12, 2021.
The intention is to establish a reasonable system for managing a top-down puzzle game.

https://user-images.githubusercontent.com/9030453/137402849-80717d9e-ef95-4fb4-8125-7377c17d6371.mp4

## Methodology

+ Levels are created in [OGMO3 editor](https://github.com/Ogmo-Editor-3/OgmoEditor3-CE) and pulled into monogame as JSON.

+ JSON is serialized into a LevelData object, which currently contains two layers -- an entity layer and tilemap layer.

+ When a level is instantiated, a LevelMap object is created from the tilemap layer (within the tilemap generator) and tracked as a 2d array

+ For each entity added, their position is transformed into a relative cell position and added to the LevelMap object through the level map's API

+ The LevelMap is responsible for moving objects and managing their relationships. Currently movement for all objects is handled via the `Move` function. This should make more complex map-wide functionality easier to implement (e.g. an undo function). There is no collision system in this game.

+ Limitations include more complex behaviors, including objects that span multiple tiles. This system is very eary in development and refactors are likely.
