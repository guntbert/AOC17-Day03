# Challenge

--- Day 3: Spiral Memory ---

You come across an experimental new kind of memory stored on an infinite two-dimensional grid.

Each square on the grid is allocated in a spiral pattern starting at a location marked 1 and then counting up while spiraling outward. For example, the first few squares are allocated like this:

17  16  15  14  13
18   5   4   3  12
19   6   1   2  11
20   7   8   9  10
21  22  23---> ...

While this is very space-efficient (no squares are skipped), requested data must be carried back to square 1 (the location of the only access port for this memory system) by programs that can only move up, down, left, or right. They always take the shortest path: the Manhattan Distance between the location of the data and square 1.

For example:

    Data from square 1 is carried 0 steps, since it's at the access port.
    Data from square 12 is carried 3 steps, such as: down, left, left.
    Data from square 23 is carried only 2 steps: up twice.
    Data from square 1024 must be carried 31 steps.

How many steps are required to carry the data from the square identified in your puzzle input all the way to the access port?

Your puzzle input is 361527.

# Problemanalyse

- Stufennummer: n (beginnt mit 0)
- jede Stufe ab n=1 hat +8 Positionen verglichen mit der vorherigen: PAnzahl(n)=8*n (n>1), PAnzahl(0)=1
- die zuerst erreichte Pos einer Stufe hat eine Distanz maxdist(stufe)-1
- Seitenlänge einer Stufe: (Positionsanzahl + 4)/4 = (8n+4)/4 = 2n+1) -- immer ungerade
- Seitenlänge/distanz
  - n=1: 3/2-1-2
  - n=2: 5/4-3-2-3-4
  - n=3: 7/6-5-4-3-4-5-6
  - n=4: 9/8-7-6-5-4-5-6-7-8
- jede Stufe hat index 1..PAnzahl(n)
- PosNr(n,i)=1+sum(8*m,m=1..n-1)+i
- mögl. Algo für Umkehrung (n,i aus PosNr)
  - ziehe 1 ab
  - alternativen
    - (ziehe so lange PAnzahl(n) ab, bis Rest < nächster Abzugswert -> n speichern)
    - ziehe so lange PAnzahl(n) bis Rest < 0, dazu immer den vorherigen Wert auch speichern
  - Rest ist i
- distance
  - setze voraus: tier>1
  - verwende n=tier
  - n <= distance  <= 2n-1
  - Seitenmitte: distance=n
  - Ecken: distance=2n-1
  - index 0: distance=2n-2
  - Abstand zwischen Mitten: PAnzahl(n)/4=8n/4=2n
  - Index der 1. Seitenmitte: n-1
  - Reduktion: index mod (2n) - bleiben nur Positionen/indices auf der 1.Seite -> Fallumterscheidung erleichtert
  - Abstand von der nä Mitte: reduzIndex-(n-1)= |index mod (2n)-(n-1)|
  - distance=n+Abstand von MItte