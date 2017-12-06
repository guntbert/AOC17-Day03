# Problemanalyse

- Stufennummer: n (beginnt mit 0)
- jede Stufe ab n=1 hat +8 Positionen verglichen mit der vorherigen: PAnzahl(n)=8*n (n>1), PAnzahl(0)=1
- die zuerst erreichte Pos einer Stufe hat eine Distanz maxdist(stufe)-1
- Seitenlänge einer Stufe: (Positionsanzahl + 4)/4 = (8*n+4)/4 = (2*n+1) -- immer ungerade
- Seitenlänge/distanz
  - n=1: 3/2-1-2
  - n=2: 5/4-3-2-3-4
  - n=3: 7/6-5-4-3-4-5-6
  - n=4: 9/8-7-6-5-4-5-6-7-8
- jede Stufe hat index 1..PAnzahl(n)

