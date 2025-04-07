# Dynamic Retreat NavMesh Agent

This Unity script enables a NavMeshAgent to dynamically find paths to retreat from or approach a target when direct paths are obstructed or not feasible. It is particularly useful in games and simulations where agents need to navigate complex environments.

## Features

- **Dynamic Pathfinding**: Adjusts the agent's pathfinding attempts based on the situation, either retreating or advancing towards a target.
- **Flexible Distance Handling**: Can be customized to increase or decrease the retreat or approach distance dynamically.
- **Robust Obstacle Handling**: Tries different pathfinding strategies when faced with obstacles.

## Installation

1. Download `DynamicRetreatAgent.cs`.
2. Attach it to any GameObject in your Unity project that has a NavMeshAgent component.
3. Set the `Target` and `RetreatDistance` properties in the Inspector to configure the behavior.

## Usage

- Toggle the `ShouldRetreat` property to switch between retreat and approach modes.
- Adjust the `RetreatDistance` to set how far the agent should attempt to move away from or towards the target.

## Contributing

Contributions are welcome! Please feel free to fork the repository, make changes, and submit pull requests.

## License

This project is open-sourced under the MIT license. See the LICENSE file for more details.
