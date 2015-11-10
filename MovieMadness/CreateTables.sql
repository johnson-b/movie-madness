CREATE TABLE genre
(
	id INT PRIMARY KEY IDENTITY(1,1),
	genre VARCHAR(50) NOT NULL
);

CREATE TABLE movie
(
	id INT PRIMARY KEY IDENTITY(1,1),
	title VARCHAR(100) UNIQUE,
	release_year INT,
	duration INT,
	rating VARCHAR(5)
);

CREATE TABLE movieGenre
(
	genreId INT FOREIGN KEY REFERENCES genre(id),
	movieId INT FOREIGN KEY REFERENCES movie(id)	
);

CREATE TABLE director
(
	id INT PRIMARY KEY IDENTITY(1,1),
	first_name VARCHAR(100),
	last_name VARCHAR(100),
	UNIQUE(first_name, last_name)
);

CREATE TABLE directMovie
(
	directorId INT FOREIGN KEY REFERENCES director(id),
	movieId INT FOREIGN KEY REFERENCES movie(id)
);

CREATE TABLE actor
(
	id INT PRIMARY KEY IDENTITY(1,1),
	first_name VARCHAR(100),
	last_name VARCHAR(100),
	gender VARCHAR(1),
	UNIQUE(first_name, last_name)
);

CREATE TABLE actorRole
(
	actorId INT FOREIGN KEY REFERENCES actor(id),
	movieId INT FOREIGN KEY REFERENCES movie(id),
	actor_role VARCHAR(200)
);