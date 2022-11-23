/* Listar las pistas ordenadas por el número de veces que aparecen en playlists de forma descendente */
/**/
SELECT PT.TrackId, COUNT(*) as Reps
FROM [LemonMusic].[dbo].PlaylistTrack PT
	GROUP BY PT.TrackId
	ORDER BY COUNT(*) ASC

/* Listar las pistas más compradas (la tabla InvoiceLine tiene los registros de compras) */
/**/
SELECT IL.TrackId, COUNT (*) as Compras
FROM [LemonMusic].[dbo].InvoiceLine IL
	GROUP BY IL.TrackId
	ORDER BY COUNT(*) DESC

/* Listar los artistas más comprados */
/**/


/* Listar las pistas que aún no han sido compradas por nadie */
/**/


/* Listar los artistas que aún no han vendido ninguna pista */
/**/

