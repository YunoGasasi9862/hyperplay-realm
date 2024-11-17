import pandas as pd
import numpy as np
import random

DUMMY_DATA = ".\Dataset\game_info.csv"
DUMMY_COLUMNS = ["name", "released", "developers", "publishers", "genres"]
EMPTY_STRING = ""
insert_game_query = """
INSERT INTO Game (Id, Title, Price, Quantity, PublisherId, ReleaseDate)
VALUES (?, ?, ?, ?, ?, ?)
"""
insert_publisher_query = """
INSERT INTO Publisher (Id, Name)
VALUES (?, ?)
"""
insert_developer_query = """
INSERT INTO Developer (Id, Name)
VALUES (?, ?)
"""
insert_genre_query = """
INSERT INTO Genre (Id, Name)
VALUES (?, ?)
"""
insert_game_genre_query = """
INSERT INTO GameGenre (GameId, GenreId)
VALUES (?, ?)
"""
insert_game_developer_query = """
INSERT INTO GameDeveloper (GameId, DeveloperId)
VALUES (?, ?)
"""
def separate_on_delimiter(value: str, delimiter : str = "||") -> list[str]:
    value = value if not pd.isna(value) else EMPTY_STRING
    values = value.split(delimiter)
    return values

def generate_random_number(min_limit: int, max_limit: int) -> float:
    return float(random.randint(min_limit, max_limit))

def generate_query(row: pd.series) -> str:
    return ""
    
dummy_data_df = pd.read_csv(DUMMY_DATA, usecols = DUMMY_COLUMNS)
dummy_data_df["quantity"] = 0
dummy_data_df["price"] = 0
dummy_data_df["genres"] = dummy_data_df["genres"].apply(lambda value: separate_on_delimiter(value))
dummy_data_df["publishers"] = dummy_data_df["publishers"].apply(lambda value: separate_on_delimiter(value))
dummy_data_df["developers"] = dummy_data_df["developers"].apply(lambda value: separate_on_delimiter(value))
dummy_data_df["quantity"] = dummy_data_df["quantity"].apply(lambda value: generate_random_number(1,5))
dummy_data_df["quantity"]  = dummy_data_df["quantity"].astype(int)
dummy_data_df["price"] = dummy_data_df["price"].apply(lambda value: generate_random_number(50,60))
print(dummy_data_df)
