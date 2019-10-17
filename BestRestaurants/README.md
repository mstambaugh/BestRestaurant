# BestRestaurant

Web app that lets a user add and review restaurants by cuisine.

## AUTHORS

Kira Roberts, Molly Stambaugh, Loewy Malkovich, Oct. 2019. Built for Portland Epicodus C# track. 


## USE

App built for Epicodus C# program with the Entity Framework. Lets the user post restaurants with a description to a given cuisine type. Can also add reviews to specific restaurants.

## SET-UP

- from terminal, navigate to desktop and run 'git clone https://github.com/loewymalkov/BestRestaurant.Solution.git' 
- navigate to 'BestRestaurant' project directory and run 'dotnet restore'
- set up a database with MySQL Workbench called 'best_restaurants' with the following tables/columns:
    - 'cuisines': CuisineId (PK, NN, AI), Type
    - 'restaurants': RestaurantId (PK, NN, AI), Name, Description, Price, CuisineId (PK, NN)
    - 'reviews': ReviewId (PK, NN, AI), RestaurantId (PK, NN), Description, Date
- launch app from 'BestRestaurant' with 'dotnet watch run' command and open link

## TECH USED

C#, MySQL Workbench, EntityFramework, Razor, VS Code

## LICENSE

Open source, 2019 (MIT)

