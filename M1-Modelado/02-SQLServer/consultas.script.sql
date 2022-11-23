
/*					*/
/* Todas las Querys */
/*					*/

/* Listar las pistas (tabla Track) con precio mayor o igual a 1€ */
/**/
SELECT T.UnitPrice, T.[Name]
FROM [LemonMusic].[dbo].Track T
WHERE T.UnitPrice >= 1

/* Listar las pistas de más de 4 minutos de duración */
/**/
SELECT T.Milliseconds, T.[Name]
FROM [LemonMusic].[dbo].Track T
WHERE T.Milliseconds >= (4*60*1000)

/* Listar las pistas que tengan entre 2 y 3 minutos de duración */
/**/
SELECT T.Milliseconds, T.[Name]
FROM [LemonMusic].[dbo].Track T
WHERE T.Milliseconds BETWEEN (2*60*1000) AND (3*60*1000)

/* Listar las pistas que uno de sus compositores (columna Composer) sea Mercury */
/**/
SELECT T.Composer, T.[Name]
FROM [LemonMusic].[dbo].Track T
WHERE T.Composer LIKE '%Mercury%'

/* Calcular la media de duración de las pistas (Track) de la plataforma */
/**/
SELECT AVG(T.Milliseconds)
FROM [LemonMusic].[dbo].Track T

/* Listar los clientes (tabla Customer) de USA, Canada y Brazil */
/**/
SELECT C.Country, C.FirstName
FROM [LemonMusic].[dbo].Customer C
WHERE C.Country IN ('USA', 'Canada', 'Brazil')

/* Listar todas las pistas del artista 'Queen' (Artist.Name = 'Queen') */
/**/
SELECT A.[Name], T.Name
FROM [LemonMusic].[dbo].Artist A
LEFT JOIN [LemonMusic].[dbo].Track T
	ON A.Name = T.Composer
		WHERE A.Name LIKE 'Queen'

/* Listar las pistas del artista 'Queen' en las que haya participado como compositor David Bowie */
/**/
SELECT A.[Name], T.Name, T.Composer
FROM [LemonMusic].[dbo].Artist A
LEFT JOIN [LemonMusic].[dbo].Track T
	ON A.Name LIKE '%Queen%'
		WHERE T.Composer LIKE '%David Bowie%'

/* Listar las pistas de la playlist 'Heavy Metal Classic' */
/**/
SELECT T.Name, T.Composer, T.UnitPrice, P.Name
FROM [LemonMusic].[dbo].Playlist P
LEFT JOIN [LemonMusic].[dbo].PlaylistTrack PT
	ON P.PlaylistId = PT.PlaylistId
LEFT JOIN [LemonMusic].[dbo].Track T
	ON T.TrackId = PT.TrackId
		WHERE P.Name LIKE 'Heavy Metal Classic'

/* Listar las playlist junto con el número de pistas que contienen */
/**/
SELECT COUNT(*) as Recuento, PT.PlaylistId
FROM [LemonMusic].[dbo].PlaylistTrack PT
LEFT JOIN [LemonMusic].[dbo].Playlist P
	ON PT.PlaylistId = P.PlaylistId
		GROUP BY PT.PlaylistId
 
/* Listar las playlist (sin repetir ninguna) que tienen alguna canción de AC/DC */
/**/
SELECT DISTINCT P.Name
FROM [LemonMusic].[dbo].Playlist P
LEFT JOIN [LemonMusic].[dbo].PlaylistTrack PT
	ON PT.TrackId = P.PlaylistId
	LEFT JOIN [LemonMusic].[dbo].Track T
	ON T.TrackId = PT.TrackId
		WHERE T.Composer LIKE '%AC/DC%'


/* Listar las playlist que tienen alguna canción del artista Queen, junto con la cantidad que tienen */
/**/
SELECT P.Name, COUNT(T.Composer) as 'N.Canciones'
FROM [LemonMusic].[dbo].Playlist P
	INNER JOIN [LemonMusic].[dbo].PlaylistTrack PT
	ON P.PlaylistId = PT.PlaylistId
		INNER JOIN [LemonMusic].[dbo].Track T
		ON PT.TrackId = T.TrackId
			WHERE T.Composer LIKE '%Queen%'
				GROUP BY P.Name
	

/* Listar las pistas que no están en ninguna playlist */
/**/
SELECT T.Name, PT.PlaylistId 
FROM [LemonMusic].[dbo].Track T
 LEFT JOIN [LemonMusic].[dbo].PlaylistTrack PT
	ON PT.TrackId IS NULL



/* Listar los artistas que no tienen album */
/**/
SELECT Ar.Name
FROM [LemonMusic].[dbo].Album Al
	RIGHT JOIN [LemonMusic].[dbo].Artist Ar
		ON Al.ArtistId = Ar.ArtistId
			WHERE Al.AlbumId IS NULL

/* Listar los artistas con el número de albums que tienen */
/**/
/* Para saber si está bien, asegurate que algunos de los artistas de la query anterior (artistas sin album) aparecen en este listado con 0 albums */
SELECT Ar.Name, COUNT (Al.AlbumId)
FROM [LemonMusic].[dbo].Album Al
	RIGHT JOIN [LemonMusic].[dbo].Artist Ar
		ON Al.ArtistId = Ar.ArtistId
		GROUP BY Ar.Name




