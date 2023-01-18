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
```

## ERD 
