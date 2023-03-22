# Solución de NewsApp
La solución de NewsApp consiste en una aplicación de cliente React JS y una API de servidor Net Core 3.1 C# que utiliza una biblioteca cliente de C# para integrar la API de noticias externa.

## Stack Tecnológico
- React JS: Cliente
- Net Core 3.1 C#: Servidor
- C#: Core
- C#: Modelo
- C#: Proxy

## Proyectos de la solución
La solución NewsApp está compuesta por varios proyectos que se encargan de diferentes tareas:

- **newsapp**: Es el proyecto del cliente React JS que se encarga de presentar la interfaz de usuario de la aplicación.

- **newsapp.API**: Es el proyecto del servidor Net Core 3.1 C# que implementa la API REST utilizada por el cliente para obtener las noticias desde una fuente externa. Este proyecto utiliza la biblioteca cliente de C# para integrar la API de noticias externa.

- **newsapp.Core**: Es un proyecto de biblioteca de clases C# que contiene la lógica de negocio de la aplicación.

- **newsapp.Proxy**: Es un proyecto de biblioteca de clases C# que contiene la implementación de la biblioteca cliente de C# para integrar la API de noticias externa.

- **newsapp.Model**: Es un proyecto de biblioteca de clases C# que contiene las entidades que se utilizan en la solución, como las clases que representan las noticias y los artículos.

## Instalación y Configuración
1. Clonar el repositorio:
```bash
git clone https://github.com/MVelasquez98/NewsApp.git
```

2. Posicionarse en la carpeta del proyecto API y correr dotnet run para iniciar el servidor:
```bash
cd NewsApp/Api
dotnet run
```

3. Verificar en qué puerto se inició la API.

4. Posicionarse en la carpeta del proyecto newsapp y editar el archivo .env para configurar la variable de entorno de desarrollo **REACT_APP_API_BASE_URL** con la URL base del servidor que se inició en el paso anterior. Ejemplo:
```javascript
REACT_APP_API_BASE_URL=http://localhost:5001
```
5. En la carpeta raíz del proyecto newsapp, ejecutar el comando **npm install @material-ui/core --force** y **npm install @material-ui/lab --force** para instalar las dependencias necesarias relacionadas con material-ui.
```bash
npm install @material-ui/core --force
npm install @material-ui/lab --force
```

6. Correr el comando **npm i** para instalar el resto de dependencias necesarias
```bash
npm i
```

6. Finalmente, iniciar la aplicación con el comando npm start:

```bash
cd ../newsapp
npm start
```

7. La aplicación estará disponible en http://localhost:3000 y podrás probarla.

¡Listo! Con estos sencillos pasos podrás instalar y configurar la solución de NewsApp en tu entorno de desarrollo. Si tienes algún problema o necesitas más ayuda, no dudes en contactarme.
