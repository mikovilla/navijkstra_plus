# Navijkstra Plus

## Overview
This application provides real-time navigation using OpenRouteService, geocoding, and Dijkstra's algorithm for shortest path computation. It allows users to enter source and destination addresses, select precise coordinates, and calculate the optimal route.

![image](https://github.com/user-attachments/assets/b53869c3-eed9-4f25-8116-7433a80f3cc2)


## Features
- Fetch real-time location coordinates via geocoding.
- Calculate shortest path using **Dijkstra's Algorithm**.
- Display interactive map with waypoints and routing instructions.
- Show distance and duration metrics from **OpenRouteService**.

## Technologies Used
- **C#** (Backend logic)
- **Blazor** (Frontend UI)
- **XUnit** (Unit Test)
- **OpenRouteService API** (Route and distance calculation)
- **Geocode API** (Address-to-coordinate conversion)
- **Dijkstra’s Algorithm** (Graph-based shortest path computation)

## Usage
- Enter Source and Destination addresses.
- Click Get Addresses to fetch location coordinates.
- Select waypoints from the dropdown menus.
- Click Find Path to compute the shortest route.
- View duration, distance, and step-by-step instructions.

## Key Components
- Frontend (**Blazor UI**)
- Displays input fields, dropdown selections, and a mapped route.
- Uses data binding for real-time updates.
- Graph Construction (Dictionary-based)
- Dijkstra’s Algorithm for Shortest Path

## Future Enhancements
- Kubernetes environment implementation
