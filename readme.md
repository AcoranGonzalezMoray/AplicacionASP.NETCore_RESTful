<h1 align="center">BACKEND ASP.NET CORE </h1>

## Paquetes Nuget implicados:

<ul>
  <li>microsoft.entityframeworkcore\7.0.10\</li>
  <li>microsoft.entityframeworkcore.sqlserver\7.0.10\</li>
  <li>swashbuckle.aspnetcore\6.5.0\</li>
  <li>microsoft.aspnetcore.openapi\7.0.10\</li>
  <li>firebasestorage.net\1.0.3\</li>
  <li>microsoft.entityframeworkcore.tools\7.0.10\</li>
  <li>firebaseauthentication.net\3.7.1\</li>
</ul>

## Ejemplo Petición

```
  post(dog:DogElement, image:File):Observable<void>{

    const formData: FormData = new FormData();
    formData.append('DogData', JSON.stringify(dog)); // Convertir el objeto a JSON y agregarlo al FormData
    formData.append('image', image, image.name); // Agregar la imagen al FormData
   
    // Configurar las cabeceras si es necesario
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'multipart/form-data');

    dog.imageUrl  =''


    return this.http.post<void>(`${this.myApiurl}${this.myAppUrl}`,formData,{ headers: headers });
  }
```






