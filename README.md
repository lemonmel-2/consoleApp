# Game Backend Console App

## Description
This is a C# console application that acts as a temporary backend for a frontend game. It provides basic functionality for authentication, item management, score recording, and leaderboard viewing. 

## Features
- **Authentication**: Login and Register users.
- **Item Management**: Generate items and add items to user inventory.
- **Score Recording**: Record user scores.
- **Leaderboard**: View the leaderboard based on user scores.

## Extra Notes
- **Database**: Database is currently using json file as temporary solution
- **Password Handling**: Password is hashed with random generate salt to store in database, to avoid exploiting user sensitive info

## How To Start
1. Clone project
2. Run project by `dotnet run`
3. Login or register
    - To Login (This is a test account created):
    `1 user1 000000`
    - To register:
    `2 username password`
4. Play around!
<img width="682" height="92" alt="image" src="https://github.com/user-attachments/assets/7ad3b2e1-373c-4aba-b682-90712fc285bd" />
