# Explicación

## Home

Tendremos una tabla para listar todas las categorias con sus respectivos videos más recientemente publicados que se llama HomeCourseList. La gracia de esta tabla es que podremos tener los datos que se muestran, en la ventana de Home, facilmente accesibles permitiendo cargar más rápido, al contrario que si tuviesemos que hacer las búsquedas respectivas constantemente.
Consideramos que aquí se usa el Computed Pattern ya que el servidor será el que actualice esta base de datos cada vez que se suba un nuevo video.

## Curso

Primero tenemos la información básica de cada curso (Título, descripción, etc.). A continuación, hay que hacer la búsqueda de los video de este curso en la tabla Video para sacar Título y descripción.

## Lección

Aquí sacaríamos toda la información de la tabla Video. Se aplica el Computed Pattern para saber las visualizaciones, el Tree Pattern para conocer a qué categoria pertenece y cual es su ascendiente.

## Autor

La información básica la tenemos en la tabla Author. Después tendremos los cursos en los que ha participado sabiendo en qué videos ha estado, con la tabla Video_Author, y después lanzando otra query a la tabla Course, ya que en Video, tenemos el CourseID.
La gracia de la tabla Video_Author es que nos permite tener varios autores por vídeo.

## Otros detalles

### Unir las tablas Author y User

Las tablas Author y User podrían llegar a haberse unido, pero he decidido mantenerlas separadas para facilitar el trabajo de saber, a la hora de dar permisos y de programar, cuando se está trabajando con un usuario común y con un autor (el cual, generalmente, tendrá más derechos ya que podrá acceder a sus vídeos y cursos, y modificarlos).

### Outlier Pattern en los videos

Se me ha pasado por la cabeza la posibilidad de crear una base de datos por cada categoría, lo que permitiría acceder a los vídeos de cada curso más rápido. Pero esto seguramente solo ocurriría al inicio, al final terminaría habiendo cientos o miles de vídeos por tabla, como ocurre ahora mismo.
Por esto se usa el Outlier Pattern en la tabla Video.

### Otros patrones

No se aplica el patron Schema versioning ya que todo lo necesario será añadido en fase de desarrollo y después no se esperan cambios en las bases de datos. Podría añadirse y no implicaría gran cambio, esto se lo podríamos dejar de la mano del cliente (ya que tener una columna más, implicaría necesitar mayor tamaño de disco duro).