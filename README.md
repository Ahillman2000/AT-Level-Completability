# AT-Level-Completability

The aim for this project is to create a system for automatically checking whether a game level can be completed given the some game rules.

The project utilises Unity's navmesh system to allow an agent to attempt to complete a set of objectives. If any of the objectives within the level are unreachable then the designer is alterted to the problem.

![image](https://user-images.githubusercontent.com/55785328/161014718-8972ff2e-bd15-494a-bf5a-f5fe4c6737ac.png)

The project can be altered within the editor to assign a main objective within the GameManager gameobject within the hierarchy. Each objective for the game requires an Objective script attached to it. This script then requires a parent objective and optionally one or more child objectives. These form a network of objectives that the player is required to complete to finish the game.

![image](https://user-images.githubusercontent.com/55785328/161016527-1e74e576-ae1e-4e5d-a0c9-8c7dda373601.png)

When the system is run the agent will attempt to complete the game with the designated objectives that the designer has specified, if the agent will attempt to reach and complete the objective and if this is impossible then the designer is notified from the console and hierarchy.
