Solución de NewsApp
La solución de NewsApp consiste en una aplicación de cliente React JS y una API de servidor Net Core 3.1 C# que utiliza una biblioteca cliente de C# para integrar la API de noticias externa.

Stack Tecnológico
React JS: Cliente
Net Core 3.1 C#: Servidor
C#: Core
C#: Modelo
C#: Proxy
Instalación y Configuración
Clonar el repositorio:
bash
Copy code
git clone https://github.com/TuUsuario/NewsApp.git
Posicionarse en la carpeta del proyecto API y correr dotnet run para iniciar el servidor:
bash
Copy code
cd NewsApp/Api
dotnet run
Verificar en qué puerto se inició la API.

Posicionarse en la carpeta del proyecto newsapp y editar el archivo .env para configurar la variable de entorno de desarrollo REACT_APP_API_BASE_URL con la URL base del servidor que se inició en el paso anterior. Ejemplo:

javascript
Copy code
REACT_APP_API_BASE_URL=http://localhost:5001
En la carpeta raíz del proyecto newsapp, ejecutar el comando npm i material-ui/core --force para instalar las dependencias necesarias.

Finalmente, iniciar la aplicación con el comando npm start:

bash
Copy code
cd ../newsapp
npm start
La aplicación estará disponible en http://localhost:3000 y podrás probarla.
¡Listo! Con estos sencillos pasos podrás instalar y configurar la solución de NewsApp en tu entorno de desarrollo. Si tienes algún problema o necesitas más ayuda, no dudes en contactarnos.
