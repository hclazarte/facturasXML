
# Sistema de Facturación Electrónica

## Broward International University
**Maestría en Ciencias de Ingeniería de Software Informático**  
**WEB XML APPLICATIONS (CSE652)**  
**Tarea: Asignación No. 8 (Reformulación del Informe del Caso de Estudio)**  
**Profesor:** PHD Luis Antonio Salvador Ullauri  
**Alumno:** Ing. Héctor Cristóbal Lazarte  

---

## Resumen
Este sistema de facturación electrónica está diseñado para la emisión, validación y consulta de facturas electrónicas en formato XML, cumpliendo con las normativas bolivianas de interoperabilidad fiscal. Se utilizan tecnologías modernas como:
- **Backend:** Ruby on Rails (ver [Repositorio Backend](https://github.com/hclazarte/hclp-be))
- **Frontend:** React.js (ver [Repositorio Frontend](https://github.com/hclazarte/hclp-online))
- **Base de Datos:** Oracle
- **Fachada SOAP:** C#

Este proyecto integra los diferentes componentes para ofrecer una solución completa de facturación electrónica.

---

## Apartados

### 1. Alcance del Proyecto
El sistema permite:  
1. Generar facturas electrónicas en formato XML basadas en transacciones de órdenes.  
2. Exponer las facturas mediante un servicio SOAP para consulta por parte de entidades fiscales.

### 2. Características Clave
- **XML:** Utilizado como lenguaje estándar para estructurar las facturas electrónicas.  
- **SOAP:** Protocolo robusto para la exposición de facturas, garantizando seguridad mediante WS-Security.  
- **Base de Datos Oracle:** Almacena de manera centralizada las órdenes, productos y facturas.  

### 3. Herramientas y Tecnologías
- **Lenguajes:** Ruby (RoR), C#, JavaScript (React.js).  
- **Validación de XML:** Implementación de esquemas XSD para asegurar la integridad de las facturas electrónicas.  
- **Fachada SOAP:** Independiente del backend para facilitar la interoperabilidad.

### 4. Instalación

#### Requisitos
- **Oracle Database:** Configurado con los datos de conexión.
- **Ruby on Rails:** Instalado con las dependencias necesarias.
- **React.js:** Proyecto configurado y empaquetado.
- **Visual Studio:** Para compilar y desplegar la fachada SOAP.

#### Pasos
1. **Clonar Repositorios:**  
   ```bash
   git clone https://github.com/hclazarte/hclp-be.git
   git clone https://github.com/hclazarte/hclp-online.git
   ```

2. **Configurar el Backend:**  
   - Navegar al directorio del backend:
     ```bash
     cd hclp-be
     bundle install
     rails db:setup
     rails s
     ```

3. **Configurar el Frontend:**  
   - Navegar al directorio del frontend:
     ```bash
     cd hclp-online
     npm install
     npm start
     ```

4. **Configurar la Fachada SOAP:**  
   - Abrir el proyecto de Visual Studio disponible en el repositorio de la fachada SOAP.
   - Configurar las credenciales de Oracle en el archivo de configuración de la conexión.
   - Compilar y desplegar el servicio.

5. **Pruebas:**  
   - Asegurarse de que el backend esté escuchando en `http://localhost:3001` y el frontend en `http://localhost:3000`.
   - Probar las rutas del backend y los servicios SOAP.

---

## Referencias
- [Repositorio Backend](https://github.com/hclazarte/hclp-be)
- [Repositorio Frontend](https://github.com/hclazarte/hclp-online)
- Documentación oficial de SOAP y XML.
