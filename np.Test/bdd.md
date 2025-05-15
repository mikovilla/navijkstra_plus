# Feature: Shortest Path Calculation
### Scenario: Path does not exist
Given a graph with nodes "A", "B", "C", and "D" And connections exist between "A" ↔ "B" and "C" ↔ "D" When I calculate the shortest path from "A" to "D" Then the result should be empty.

### Scenario: Graph is empty
Given an empty graph When I calculate the shortest path from "A" to "D" Then the result should be empty.

### Scenario: Start and destination are the same
Given a graph with nodes "A", "B", and "C" And connections exist between "A" ↔ "B" (1), "A" ↔ "C" (4), and "B" ↔ "C" (2) When I calculate the shortest path from "A" to "A" Then the result should be ["A"].

### Scenario: Graph has a single node
Given a graph with only node "A" When I calculate the shortest path from "A" to "A" Then the result should be ["A"].

### Scenario: Graph has no connections
Given a graph with nodes "A", "B", and "C" And no connections exist between them When I calculate the shortest path from "A" to "C" Then the result should be empty.

### Scenario: Graph contains cycles
_Given a graph with nodes "A", "B", "C", and "D" And connections exist as follows:_

"A" → "B" (1)

"A" → "C" (3)

"B" → "C" (1)

"B" → "D" (2)

"C" → "D" (1)

"D" → "-" (0)

**When I calculate the shortest path from "A" to "D" Then the result should be ["A", "B", "C", "D"].**

### Scenario: Start and destination are directly connected
Given a graph with nodes "A" and "B" And a direct connection exists between "A" → "B" (5) When I calculate the shortest path from "A" to "B" Then the result should be ["A", "B"].

# Feature: GeoCode Property Retrieval
### Scenario: Retrieving GeoCode Properties for Multiple Locations
Given a list of expected locations, including variations of "Manila" from different regions And a GeoCode service that returns location properties When I request the GeoCode properties Then the result should contain all expected locations.

# Feature: Shortest Path Calculation Using Dijkstra's Algorithm
### Scenario: Generating a Graph from Route Service Data
Given OpenRouteService data with named street segments And expected graph output based on computed distances When the graph is generated Then the resulting graph should match the predefined output.

### Scenario: Graph is not empty
Given OpenRouteService navigation data When I generate the graph representation Then the graph should not be empty.
