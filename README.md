# DummyIceCreamFactoryApi

### Description 
Crafted with the sleek .NET 8, this repository houses a minimal API adorned with a touch of sophistication. Seamlessly integrating dependencies through Docker Compose, the code invites you to dive into the fancy project, all while reminding you to burn those calories after savoring some ice cream! 🍦😄

### Motivation
Explore an elegant minimal API built on .NET 8, seamlessly integrating dependencies through Docker Compose.

### Localhost run 
**docker:**

Navigate to the *.sln directory, launch without dependencies:

```
docker build -f DummyIceCreamFactoryApi/Dockerfile --force-rm -t icecreamfactoryapi . 
docker run -d -p 8080:8080 --name icecreamfactoryapi icecreamfactoryapi
```

**docker-compose:**

Navigate to the *.sln directory, launch with dependencies:
```
docker-compose up
```

### Dependecies 
