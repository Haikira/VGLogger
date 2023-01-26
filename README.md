# VGLogger

VGLogger is an application for logging and maintaining a collection of video games, and tracking which titles the user has completed, yet to play, etc.

The user may be able to review each game title, leaving a star rating, and a text description.

## Goals

- To provide users with an easy to use tool for managing their game collection
- Capture archival records of when games have been purchased, completed, etc
- Offer functionality for reviewing games
- Offer functionality to view games in a collection yet to be played

## Project Outline

**MVP**

- Create a User Account
- Create a Game
- Create a Platform
- Create a Review
- Create a Developer
- Create new Game Dates against a user's Game

**V1 Goals**

- Retrieve a list of coming soon games (sort by date, display how many days until game is out, etc)

## Domain Model

``` mermaid
erDiagram

        games }|--|{ games_platforms : ""
        games }|--|{ developers : ""
        platforms }|--|{ games_platforms : "" 
        reviews }|--|{ games_platforms : ""
        games_platforms }|--|{ users_games : ""
        users}|--|{ users_games : ""
        game_dates }|--|{ users_games : ""
        date_types }|--|{ game_dates : ""
        reviews }|--|{ users : ""
        
```

## ERD 
``` mermaid
%%{init: {'theme': 'dark' } }%%

erDiagram

        games {
                int id
                string name                
                string description
                string developer_id
        }
        platforms {
                int id
                string name                
        }
        games_platforms {
                int id
                int game_id
                int platform_id
                datetime release_date
        }
        users_games {
                int id
                int user_id
                int game_platform_id
        }
        users {
                int id
                string first_name
                string last_name
                string email
                string password
        }
        developers {
                int id
                string name
        }
        reviews {
                int id
                int star_rating
                string description
                datetime date_reviewed
                int game_id
                int user_id
        }
        game_dates {
                int id
                datetime date
                int date_type_id
                int user_game_id
        }
        date_types{
             int id
             string date_type
        }
        
        
        games }|--|| developers: "uses"
        games_platforms }|--|| platforms: "uses"
        games_platforms }|--|| games: "uses"
        reviews }|--|| games_platforms: "uses"       
        reviews }|--|| users: "uses"       
        game_dates }|--|| users_games: "uses"        
        game_dates }|--|| date_types: "uses"        
        users_games }|--|| games_platforms: "uses"
        users_games }|--|| users: "uses"



```

## API Specification

```

**USERS**

GET /users/{id}

Response

[
    {
      “id”:"86",
      “first_name”:"Jack",
      "last_name":"Burton",
      "email":"jackburton@gmail.com"
    }
]

GET /users

Response 

[
    {
      “id”:"86",
      “first_name”:"Jack",
      "last_name":"Burton",
      "email":"jackburton@gmail.com"
    },
    {
      “id”:"82",
      “first_name”:"John",
      "last_name":"MacReady",
      "email":"johmacreadyn@gmail.com"
    }
]

GET /users/{id}/games
POST /users

Request

POST /users/{id}/games
POST /users/{id}/games/{id}
PUT /users/{id}

Request

PUT /users/{id}/games/{id}
DELETE /users/{id}
DELETE /users/{id}/games/{id}

**GAMES**

GET /games Returns all games.

Response

[
  {
    "id": 1,
    "name": "Red Dead Redemption 2",
    "description": "Red Dead Redemption 2 is the epic tale of outlaw Arthur Morgan and the infamous Van der Linde gang, on the run across America at the dawn of the modern age.",
    "developer" : {
        "id": 1,
        "name":"Rockstar Games"
    }
  },
  {
    "id": 2,
    "name": "NieR:Automata",
    "description": "NieR Automata tells the story of androids 2B, 9S and A2 and their battle to reclaim the machine-driven dystopia overrun by powerful machines.",
    "developer" : {
        "id": 2,
        "name":"PlatinumGames Inc."
    }
  }
]

GET /games/{id} Returns a game and all platforms it belongs to.

Response 

[
  {
    "id": 1,
    "name": "Red Dead Redemption 2",
    "description": "Red Dead Redemption 2 is the epic tale of outlaw Arthur Morgan and the infamous Van der Linde gang, on the run across America at the dawn of the modern age.",
    "developer" : {
        "id": 1,
        "name":"Rockstar Games"
    },
    "platforms" : [{
        "id": 8,
        "platform_": "Playstation 4",
        "release_date": "2018-10-26"
    }, {
        "id": 9,
        "platform": "Windows",
        "release_date": "2019-11-19"
    }]
  }
]

POST /games Creates game.

Request 

{
    "name": "Red Dead Redemption 2",
    "description": "Red Dead Redemption 2 is the epic tale of outlaw Arthur Morgan and the infamous Van der Linde gang, on the run across America at the dawn of the modern age.",
    "developer" : 1
}


PUT /games/{id}

Request 

{
    "id": 1,
    "name": "Red Dead Redemption 2",
    "description": "Red Dead Redemption 2 is the epic tale of outlaw Arthur Morgan and the infamous Van der Linde gang, on the run across America at the dawn of the modern age.",
    "developer" : 1
}

DELETE /games/{id}



**REVIEWS**

GET /reviews/{id}

Response

[
  {
    "id": 1,
    "rating": 4,
    "description":"This game is great, but it needs more dinosaurs.",
    "date": "2023-01-25",
    "game" : {
        "id": 2,
        "name": "PGA TOUR 2K23",
        "description": "Hit the links with more swagger in PGA TOUR 2K23."
    },
    "user" : {
        "id": 117,
        "forename": "John",
        "surname": "Pliskin",
        "email":"snakepliskin@gmail.com"
    }
  }
]

GET /reviews

TODO - Should this be games/{id}/reviews ?
       or should this be a get all that returns same structure as get/{id} ?

Response

POST /reviews

Request

DELETE /reviews/{id}



**PLATFORMS**

GET /platforms/{id}

Response

[
  {
    "id": 1,
    "name": "Playstation 4"
  }
]

GET /platforms

Response

[
  {
    "id": 1,
    "name": "Playstation 4"
  },
  {
    "id": 2,
    "name": "Playstation 5"
  }
]

POST /platforms

Request

{
    "name": "Dreamcast"
}

PUT /platforms/{id}

Request

{
    "id": 3,
    "name": "Sega Dreamcast"
}

DELETE /platforms/{id} (Soft Delete)



**DEVELOPERS**

GET /developers/{id}

Response

GET /developers

Response

POST /developers

Request

PUT /developers/{id}

Request

DELETE /developers/{id} (Soft Delete)

