import pandas as pd
import numpy as np
import random
from typing import Tuple, Optional, List
from dataclasses import dataclass

DUMMY_DATA = ".\Dataset\game_info.csv"
DUMMY_COLUMNS = ["name", "released", "developers", "publishers", "genres"]
EMPTY_STRING = ""
insert_game_query = """
INSERT INTO Game (Id, Title, Price, Quantity, PublisherId, ReleaseDate)
VALUES (?, ?, ?, ?, ?, ?)
"""
insert_publisher_query = """
INSERT INTO HyperplayRealmDB.dbo.Publisher (Name)
VALUES
"""
insert_developer_query = """
INSERT INTO HyperplayRealmDB.dbo.Developer (Name)
VALUES
"""
insert_genre_query = """
INSERT INTO HyperplayRealmDB.dbo.Genre (Name)
VALUES
"""
insert_game_genre_query = """
INSERT INTO GameGenre (GameId, GenreId)
VALUES (?, ?)
"""
insert_game_developer_query = """
INSERT INTO GameDeveloper (GameId, DeveloperId)
VALUES (?, ?)
"""
@dataclass
class Data():
    developerQuery: List[Optional[str]] = None
    publisherQuery: List[Optional[str]] = None
    genreQuery: List[Optional[str]] = None

def separate_on_delimiter(value: str, delimiter : str = "||") -> list[str]:
    value = value if not pd.isna(value) else EMPTY_STRING
    values = value.split(delimiter)
    return values

def generate_random_number(min_limit: int, max_limit: int) -> float:
    return float(random.randint(min_limit, max_limit))

def generate_data(row: pd.Series) -> Data:
    publisher_query = []
    genre_query = []
    developer_query = []
    for publisher in row["publishers"]:
        if publisher is not EMPTY_STRING:
            publisher_query.append(publisher)
            
    for developer in row["developers"]:
        if developer is not EMPTY_STRING:
            developer_query.append(developer)
            
    for genre in row["genres"]:
        if genre is not EMPTY_STRING:
            genre_query.append(genre)
          
    return Data(developerQuery = developer_query, publisherQuery = publisher_query, genreQuery = genre_query) 
    
dummy_data_df = pd.read_csv(DUMMY_DATA, usecols = DUMMY_COLUMNS)
dummy_data_df["quantity"] = 0
dummy_data_df["price"] = 0
dummy_data_df["genres"] = dummy_data_df["genres"].apply(lambda value: separate_on_delimiter(value))
dummy_data_df["publishers"] = dummy_data_df["publishers"].apply(lambda value: separate_on_delimiter(value))
dummy_data_df["developers"] = dummy_data_df["developers"].apply(lambda value: separate_on_delimiter(value))
dummy_data_df["quantity"] = dummy_data_df["quantity"].apply(lambda value: generate_random_number(1,5))
dummy_data_df["quantity"]  = dummy_data_df["quantity"].astype(int)
dummy_data_df["price"] = dummy_data_df["price"].apply(lambda value: generate_random_number(50,60))
dummy_data_df["released"] = pd.to_datetime(dummy_data_df["released"])
dummy_data_df = dummy_data_df.sort_values(by="released", ascending = False)
dummy_data_df = dummy_data_df[(dummy_data_df["released"] < pd.Timestamp('2024-12-31')) & (dummy_data_df["released"] > pd.Timestamp('2020-08-30'))]
dummy_data_df.reset_index(inplace = True)
publishers = []
developers = []
genres = []

for index, row in dummy_data_df.iterrows():
    data = generate_data(row)
    publishers.extend(data.publisherQuery)
    developers.extend(data.developerQuery)
    genres.extend(data.genreQuery)
    
genres = list(set(genres))
publishers = list(set(publishers))
developers = list(set(developers))

publisher_queries = ",\n".join(f"({publisher})" for publisher in publishers)
developer_queries = ",\n".join(f"({developer})" for developer in developers)
genre_queries = ",\n".join(f"({genre})" for genre in genres)

#now insert Ids - explicit, and do the mapping between entities for initial insert

if publisher_queries.endswith(",\n"):
    publisher_queries = publisher_queries.rstrip(',\n')
final_publisher_query = insert_publisher_query + publisher_queries + ";"

if developer_queries.endswith(",\n"):
    developer_queries = developer_queries.rstrip(',\n')
final_developer_query = insert_publisher_query + developer_queries + ";"

if genre_queries.endswith(",\n"):
    genre_queries = genre_queries.rstrip(',\n')
final_genre_query = insert_genre_query + genre_queries + ";"

print(final_genre_query)