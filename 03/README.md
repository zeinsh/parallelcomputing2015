1. synchronization using lock
2. Break and Stop in Parallel Loop

notes:
- Parallel break : allows all steps with indices lower than the break index to be completed
- Parallel stop : terminates the loop for all steps
- If you call both Break and Stop in the same parallel loop,an exception will be thrown.
- Parallel programs use Stop more often than Break.
