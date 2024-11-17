use Steam API call for getting all the games
http://api.steampowered.com/ISteamApps/GetAppList/v0002/?format=json
once filtered from python list, create an insert query with image + game data and add into the database
1) First grab the data from the main URL
http://store.steampowered.com/api/appdetails?appids=10
2) Use the above endpoint to feed the App ID - from there get the data + image


--- due to it being a college project, it's fine to do the insertion once
--- the best approach is to use the above API call and directly project for the users on the screen, or cache it once and keep updating if needed
--- so for this project/scrap get the data, generate SQL query for game insertion and that's it.