# Goals

- unit testable
- memory: 2GB file (actually less due to additional indeces and other structures)
- cpu: 2GB file

# Design

## Best case
- 200 symbols / line = 400 bytes / line
- 2000 000 000 / 400 = 5 000 000 lines
- We want to escape LOH because it limits ability to unload file and load new.
- LOH triger is 85 000 bytes
- 85 000 / 4 = 21 250 ~= 20 000 refs in an array of refs. for safety let's use 10 000
- 5 000 000 / 10 000 = 500 arrays of 10 000 strings each t hold 2GB file

## Worst case:
- 10 bytes per line
- 2 000 000 000 / 10 = 200 000 000 lines
- 200 000 000 / 10 000 = 20 000 blocks

## Decision
So let's do this:
- arrays of 16 384 string refs max called "blocks"
- one big array of refs to 16 384 blocks max