# VGLogger

VGLogger is an application for logging and maintaining a collection of video games, and tracking which titles the user has completed, yet to play, etc.

The user may be able to review each game title, leaving a star rating, and a text description.

## Goals

- To provide users with an easy to use tool for managing their game collection
- Offer functionality for reviewing games
- Offer functionality to view games yet to play

## Project Outline

**MVP**

- Create a User Account
- Create a Game
- Create a Platform
- Create a Review
- Create a Developer

**V1 Goals**

- Retrieve a list of coming soon games (sort by date, display how many days until game is out, etc)

## Domain Model

``` mermaid
erDiagram

        games }|--|{ games_platforms : "contains"
        games }|--|{ users_games : "contains"
        platforms }|--|{ games_platforms : "contains" 
        reviews }|--|{ users_games : "contains"
        users}|--|{ users_games : "contains"
        game_dates }|--|{ users_games : "contains"
        date_types }|--|{ game_dates : "contains"
        games }|--|{ developers : "contains"
        
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

## External Documentation

**Lucidchart Entity Relationship Diagram**

https://lucid.app/lucidchart/a1a9e55d-43e0-45b9-b00c-4dd90883ca9e/edit?page=0_0&invitationId=inv_d93c240d-3219-4929-8448-5eb199125460#

## API Specification

```

**USERS**

GET /users/{id}

GET /users

POST /users

DELETE /users/{id}



**GAMES**

GET /games Returns all games.

Response

[
  {
    "id": 1,
    "name": "Red Dead Redemption 2",
    "description": "Red Dead Redemption 2 is the epic tale of outlaw Arthur Morgan and the infamous Van der Linde gang, on the run across America at the dawn of the modern age.",
    "developer" : "Rockstar Games"
  }
]

GET /games/{id} Returns a game and all platforms it belongs to.

Response 

[
  {
    "id": 1,
    "name": "Red Dead Redemption 2",
    "description": "Red Dead Redemption 2 is the epic tale of outlaw Arthur Morgan and the infamous Van der Linde gang, on the run across America at the dawn of the modern age.",
    "developer" : "Rockstar Games",
    "games_platforms" : [{
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
{
    "id": 1,
    "name": "Red Dead Redemption 2",
    "description": "Red Dead Redemption 2 is the epic tale of outlaw Arthur Morgan and the infamous Van der Linde gang, on the run across America at the dawn of the modern age.",
    "developer" : 1
}

DELETE /games/{id}



**REVIEWS**

GET /reviews/{id}

GET /reviews

POST /reviews

DELETE /reviews/{id}
