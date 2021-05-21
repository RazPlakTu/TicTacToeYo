# TicTacToeYo
Tic Tac Toe Game For Tech Challenge With API and Front End

## WebAPI
The web API consist of two microservices one exposses an an endpoint where the game could be played based on the game baord which is a 9x9 grid as a string collection.

### API

#### Undetemrined Winner
This is example simulate a game where the winner of the game was undetermined where player X play unless player O has more moves. It should attempt to block Player O's threat.

Current Game Baord:

```
X ? ?
? O ?
O ? X
```

Request: 

POST : https://localhost:44392/TicTacToe
BODY : 
```json
[
    "X",
    "?",
    "?",
    "?",
    "O",
    "?",
    "O",
    "?",
    "X"
]
```

RESPONSE:

```json
{
    "gameId": "a4bcacfc-090f-4bae-b108-f4f230cbecd0",
    "winner": "undertermined",
    "winPositions": null,
    "gameBoard": [
        "X",
        "?",
        "X",
        "?",
        "O",
        "?",
        "O",
        "?",
        "X"
    ]
}
```

#### Winner
An example by the API if it determined a winner.

Current Board 

```
X X X
O O ?
? ? ?
```

Request: 

POST : https://localhost:44392/TicTacToe
BODY : 
```json
[
    "X",
    "X",
    "X",
    "O",
    "O",
    "?",
    "?",
    "?",
    "?"
]
```

RESPONSE:

```json
{
    "gameId": "68ae28f9-8261-404a-8fc2-ea8d030d7932",
    "winner": "X",
    "winPositions": [
        0,
        1,
        2
    ],
    "gameBoard": [
        "X",
        "X",
        "X",
        "O",
        "O",
        "?",
        "?",
        "?",
        "?"
    ]
}
```

#### Invalid Baord Response

An Invalid game baord would occur in the case where a player would have more moves played.

Current Board 

```
O O ?
? ? ?
? ? ?
```
Request: 

POST : https://localhost:44392/TicTacToe
BODY : 
```json
[
    "O",
    "O",
    "?",
    "?",
    "?",
    "?",
    "?",
    "?",
    "?"
]
```

RESPONSE:

```json
{
    "Message": "Play cannot be made. O has 2 more plays than X.",
    "Code": 1
}
```