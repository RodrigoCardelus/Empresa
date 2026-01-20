# 🏢 EmpresaConectado – ADO.NET Conectado en C#

Ejercicio de programación desarrollado en **C# (.NET Framework)** cuyo objetivo es practicar el **acceso a datos utilizando ADO.NET en modo conectado**, aplicando operaciones básicas sobre una base de datos en un contexto empresarial.

El proyecto permite comprender cómo interactuar directamente con la base de datos mediante conexiones activas, comandos y lectores de datos.

---

## 🎯 Objetivo del Ejercicio

- Practicar **ADO.NET en modo conectado**
- Utilizar conexiones activas a base de datos
- Ejecutar comandos SQL desde C#
- Leer datos mediante `DataReader`
- Reforzar la lógica de acceso a datos

---

## 🧱 Conceptos Aplicados

- ADO.NET conectado
- `SqlConnection`
- `SqlCommand`
- `SqlDataReader`
- Programación en C#
- Aplicaciones de consola
- Acceso a bases de datos

## 📂 Estructura del Proyecto

```
EmpresaConectado
├── Program.cs                 # Lógica principal y acceso a datos
├── Properties/
│   └── AssemblyInfo.cs
├── EmpresaConectado.csproj
└── bin/                       # Archivos compilados
```

## ⚙️ Funcionamiento General

- El programa se ejecuta desde la consola
- Se establece una conexión activa con la base de datos
- Se ejecutan consultas SQL mediante comandos
- Los datos se leen usando un `DataReader`
- Los resultados se muestran por pantalla

---

## 🗃️ Base de Datos

El proyecto trabaja con una base de datos de tipo **Empresa**, que debe existir previamente en el motor de base de datos utilizado (por ejemplo, SQL Server).

Es necesario verificar y configurar correctamente la **cadena de conexión** antes de ejecutar el programa.

---

## 🧰 Tecnologías Utilizadas

- C#
- .NET Framework
- ADO.NET (modo conectado)
- SQL Server
- Visual Studio

---

## ▶️ Cómo Ejecutar el Proyecto

1. Abrir el archivo `EmpresaConectado.csproj` en **Visual Studio**
2. Verificar la **cadena de conexión** a la base de datos
3. Compilar la solución
4. Ejecutar el programa (**F5** o `Ctrl + F5`)
5. Observar los resultados en la consola

---

## 📚 Contexto Académico

Este ejercicio forma parte de prácticas de **Acceso a Datos en C#**, orientadas a comprender el funcionamiento del modelo conectado de ADO.NET y su uso en aplicaciones simples.

---

## 👨‍💻 Autor

**Rodrigo Cardelus**  
📍 Uruguay  
🎓 Analista en Programación – Próximo Analista en Sistemas  
🧠 Estudiante de Ciberseguridad  
💬 Apasionado por el desarrollo de software, bases de datos y seguridad informática

---

## 📌 Notas

Este proyecto es un **ejercicio académico**, enfocado en el aprendizaje del acceso a datos en modo conectado.  
Puede extenderse incorporando ABM completos, manejo de excepciones o separación en capas.

