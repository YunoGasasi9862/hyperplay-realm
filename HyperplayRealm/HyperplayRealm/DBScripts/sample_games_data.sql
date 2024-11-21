SET IDENTITY_INSERT HyperplayRealmDB.dbo.Games ON;

INSERT INTO HyperplayRealmDB.dbo.Games (Id, Title, Price, Quantity, PublisherId, ReleaseDate) 
VALUES 
(1, 'Assassins Creed', 29.99, 100, 3745, '2024-11-21'),
(2, 'Tomb Raider', 49.99, 50, 3745, '2023-08-15');

INSERT INTO  HyperplayRealmDB.dbo.GameDevelopers (GameId, DeveloperId)
VALUES 
(1, 997), 
(1, 996), 
(2, 997);

INSERT INTO  HyperplayRealmDB.dbo.GameGenres (GameId, GenreId)
VALUES 
(1, 4), 
(1, 3), 
(2, 4);