-- Set IDENTITY_INSERT to ON to insert explicit IDs for Games
SET IDENTITY_INSERT HyperplayRealmDB.dbo.Games ON;

-- Insert Games with specified Ids starting from 3
INSERT INTO HyperplayRealmDB.dbo.Games (Id, Title, Price, Quantity, PublisherId, ReleaseDate) 
VALUES 
(3, 'The Witcher 3', 39.99, 200, 2989, '2024-03-12'),
(4, 'Red Dead Redemption 2', 59.99, 150, 2990, '2023-11-11'),
(5, 'Cyberpunk 2077', 49.99, 75, 2991, '2024-06-10'),
(6, 'Minecraft', 19.99, 500, 2992, '2023-09-20'),
(7, 'Overwatch 2', 29.99, 300, 2993, '2024-01-25'),
(8, 'Fallout 4', 39.99, 150, 2994, '2023-07-13'),
(9, 'Among Us', 14.99, 1000, 2995, '2024-02-28'),
(10, 'Grand Theft Auto V', 59.99, 450, 2996, '2023-10-11'),
(11, 'Fortnite', 0.00, 10000, 2997, '2024-05-01'),
(12, 'The Elder Scrolls V: Skyrim', 29.99, 300, 2998, '2023-12-15');

-- Set IDENTITY_INSERT to OFF after inserting
SET IDENTITY_INSERT HyperplayRealmDB.dbo.Games OFF;

-- Insert into Game Developers with the correct GameId references
INSERT INTO HyperplayRealmDB.dbo.GameDevelopers (GameId, DeveloperId)
VALUES 
(3, 123), (3, 34), 
(4, 34), (4, 234),
(5, 678), (6, 345),
(7, 345), (8, 546),
(9, 666), (10, 126),
(11, 23), (12, 123);

-- Insert into Game Genres with the correct GameId references
INSERT INTO HyperplayRealmDB.dbo.GameGenres (GameId, GenreId)
VALUES 
(3, 1), (3, 2),
(4, 1), (4, 5),
(5, 3), (5, 6),
(6, 4), (7, 1),
(8, 7), (9, 8),
(10, 11), (11, 3),
(12, 6);
