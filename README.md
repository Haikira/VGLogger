# VGLogger

VGLogger is an application for logging and maintaining a collection of video games, and tracking which titles the user has completed, yet to play, etc.

The user may be able to review each game title, leaving a star rating, and a text description.

## Goals

TBC

## Solution

## Project Outline

**MVP**

- Create a User Account
- Create a Game
- Create a Platform
- Create a Review

**V1 Goals**

- Retrieve a list of coming soon games (sort by date, display how many days until game is out, etc)

## Domain Model

``` mermaid
erDiagram

        games }|--|{ games_platforms : "contains"
        platforms }|--|{ games_platforms : "contains"
        games }|--|{ users_games : "contains"
        users}|--|{ users_games : "contains"
        games }|--|{ reviews : "contains"
```

## ERD 
``` mermaid
%%{init: {'theme': 'dark' } }%%

erDiagram

        games {
                int id
                string name
                datetime release_date
        }
        platforms {
                int id
                string name                
        }
        games_platforms {
                int id
                int games_id
                int platforms_id
        }
        
        games }|--|| games_platforms: "uses"
        platforms }|--|| games_platforms: "uses"

```
