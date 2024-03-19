CREATE TABLE dataset (
    dataset_id INTEGER PRIMARY KEY,
    region TEXT,
    parent_dataset_id INTEGER,
    updated_date DATE
);
